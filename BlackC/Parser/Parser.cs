﻿/* ----------------------------------------------------------------------------
Black C - a frontend C parser
Copyright (C) 1997-2019  George E Greaney

This program is free software; you can redistribute it and/or
modify it under the terms of the GNU General Public License
as published by the Free Software Foundation; either version 2
of the License, or (at your [opt]ion) any later version.

This program is distributed in the hope that it will be useful,
but WITHOUT ANY WARRANTY; without even the implied warranty of
MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
GNU General Public License for more details.

You should have received a copy of the GNU General Public License
along with this program; if not, write to the Free Software
Foundation, Inc., 51 Franklin Street, Fifth Floor, Boston, MA  02110-1301, USA.
----------------------------------------------------------------------------*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Origami.AST;

// the grammar this parser is pased on:
//https://en.wikipedia.org/wiki/C99
//http://www.open-std.org/jtc1/sc22/WG14/www/docs/n1256.pdf

namespace BlackC
{
    public class Parser
    {
        public Options options;
        public Preprocessor prep;
        public Arbor arbor;
        public ParseDeclar pdeclar;
        public ParseExpr pexpr;
        public ParseStmt pstmt;

        public List<String> includePaths;

        public Parser(Options _options)
        {
            options = _options;

            prep = new Preprocessor(this);
            arbor = new Arbor(this);

            //create sub parsers
            pdeclar = new ParseDeclar(prep, arbor);
            pexpr = new ParseExpr(prep, arbor);            
            pstmt = new ParseStmt(prep, arbor);

            pdeclar.pexpr = pexpr;
            pexpr.pdeclar = pdeclar;
            pstmt.pexpr = pexpr;
            pstmt.pdeclar = pdeclar;

            includePaths = new List<string>() { "." };          //start with current dir
            includePaths.AddRange(options.includePaths);        //add search paths from command line
        }

        //---------------------------------------------------------------------

        public void parseFile(String filename)
        {
            prep.setMainSourceFile(filename);

            Token token = null;
            int indent = 0;
            do
            {
                //dump token stream from input file for testing purposes
                //to be removed
                token = prep.getToken();
                prep.next();
                if (token.type == TokenType.tLBRACE)
                {
                    indent++;
                }
                if (token.type == TokenType.tRBRACE)
                {
                    indent--;
                }
                if (token.type == TokenType.tEOLN)
                {
                    Console.WriteLine();
                    for (int i = 0; i < indent; i++)
                    {
                        Console.Write("  ");
                    }
                }
                else
                {
                    if (token.LeadingSpace) Console.Write(" ");
                    Console.Write(token.chars);
                }
            }
            while (token.type != TokenType.tEOF);

            //TranslationUnit unit = parseTranslationUnit();
            //unit.write();
            Console.WriteLine("parsed " + filename);
        }

        //- external definitions ----------------------------------------------

        /*(6.9) 
         translation-unit:
            external-declaration
            translation-unit external-declaration 
        */

        public TranslationUnit parseTranslationUnit()
        {
            TranslationUnit unit = new TranslationUnit(arbor);
            while (prep.getToken().type != TokenType.tEOF)
            {
                parseExternalDef();
            }
            return unit;
        }

        /* (6.9)     
         external-declaration:
            declaration
            function-definition

         (6.7) 
         declaration:
            declaration-specifiers init-declarator-list[opt] ;

         (6.9.1)
         function-definition:
            declaration-specifiers declarator declaration-list[opt] compound-statement          
        */
        public void parseExternalDef()
        {
            FunctionDefNode funcDef = null;
            int cuepoint = prep.record();
            DeclarationNode declars = pdeclar.parseDeclaration();
            if (declars.isFuncDef)
            {
                funcDef = new FunctionDefNode(declars);
                List<DeclarationNode> oldparamlist = parseDeclarationList();
                funcDef.setOldParams(oldparamlist);
                StatementNode block = pstmt.parseCompoundStatement();
                funcDef.setFuncBody(block);
            }
        }

        /*(6.9.1) 
         declaration-list:
            declaration
            declaration-list declaration
        */
        //old-style function parameter defs - here for completeness
        public List<DeclarationNode> parseDeclarationList()
        {
            List<DeclarationNode> declarList = null;
            DeclarationNode declar = pdeclar.parseDeclaration();
            if (declar != null)
            {
                declarList = new List<DeclarationNode>();
                declarList.Add(declar);
            }
            while (declar != null)
            {
                declar = pdeclar.parseDeclaration();
                declarList.Add(declar);
            }
            return declarList;
        }
    }
}

//Console.WriteLine("There's no sun in the shadow of the wizard");