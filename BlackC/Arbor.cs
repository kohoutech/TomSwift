﻿/* ----------------------------------------------------------------------------
Black C - a frontend C parser
Copyright (C) 1997-2018  George E Greaney

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
using System.IO;

using Origami.AST;

//arbor - a place where trees are grown

namespace BlackC
{
    class Arbor
    {
        Dictionary<string, int> typepdefids;

        public Arbor()
        {
            typepdefids = new Dictionary<string, int>();
        }

        //temproary kludge to get around ambiguity in C99's grammar between typedef and identifier 
        //see https://en.wikipedia.org/wiki/The_lexer_hack
        //this will be removed once the rest of the semantic analysis is up & running and this is not needed anymore
        //crazy eh?

        public bool isTypedef(String id)
        {
            bool result = false;
            if (typepdefids.ContainsKey(id))
            {
                result = true;
            }
            return result;
        }

        internal void buildFunctionDef()
        {
            throw new NotImplementedException();
        }

        internal void setTypeDef(string typeid)
        {
            typepdefids[typeid] = 0;
        }

        internal void unsetTypeDef(string typeid)
        {
            typepdefids.Remove(typeid);
        }

        internal IdentNode makeIdentifierNode(Token token)
        {
            throw new NotImplementedException();
        }

        internal ExprNode makeIntegerConstantNode(Token token)
        {
            throw new NotImplementedException();
        }

        internal ExprNode makeFloatConstantNode(Token token)
        {
            throw new NotImplementedException();
        }

        internal ExprNode makeCharConstantNode(Token token)
        {
            throw new NotImplementedException();
        }

        internal ExprNode makeStringConstantNode(Token token)
        {
            throw new NotImplementedException();
        }

        internal TypeQualNode makeTypeQualNode(Token token)
        {
            throw new NotImplementedException();
        }

        internal FuncSpecNode makeFuncSpecNode(Token token)
        {
            throw new NotImplementedException();
        }

        //- struct/unions -----------------------------------------------------

        public StructSpecNode makeStructSpec(StructUnionNode tag, IdentNode name, List<StructDeclarationNode> declarList)
        {
            throw new NotImplementedException();
        }

        public StructUnionNode makeStructUnionNode(Token token)
        {
            throw new NotImplementedException();
        }

        public StructDeclarationNode makeStructDeclarationNode(List<DeclarSpecNode> specqual, List<StructDeclaratorNode> fieldnames)
        {
            throw new NotImplementedException();
        }

        public StructDeclaratorNode makeStructDeclaractorNode(DeclaratorNode declarnode, ExprNode constexpr)
        {
            throw new NotImplementedException();
        }

        //- enums -------------------------------------------------------------

        public EnumSpecNode makeEnumSpec(IdentNode idNode, List<EnumeratorNode> enumList)
        {
            throw new NotImplementedException();
        }

        public EnumeratorNode makeEnumeratorNode(EnumConstantNode enumconst, ExprNode constexpr)
        {
            throw new NotImplementedException();
        }

        public EnumConstantNode makeEnumConstNode(Token token)
        {
            throw new NotImplementedException();
        }

        public EnumConstantNode getEnumConstNode(Token token)
        {
            throw new NotImplementedException();
        }

        public BaseTypeSpecNode makeBaseTypeSpec(Token token)
        {
            throw new NotImplementedException();
        }

        internal TypedefNode getTypedefNode(Token token)
        {
            throw new NotImplementedException();
        }

        internal StorageClassNode makeStoreageClassNode(Token token)
        {
            throw new NotImplementedException();
        }

        internal DeclarationNode makeDeclaration(List<DeclarSpecNode> declarspecs, List<InitDeclaratorNode> initdeclarlist)
        {
            throw new NotImplementedException();
        }

        internal InitDeclaratorNode makeInitDeclaratorNode(DeclaratorNode declarnode, InitializerNode initialnode)
        {
            throw new NotImplementedException();
        }

        //- expressions -------------------------------------------------------------


        internal ConstExpressionNode makeConstantExprNode(ExprNode condit)
        {
            throw new NotImplementedException();
        }

        internal AddExprNode makeAddExprNode(ExprNode lhs, ExprNode rhs)
        {
            throw new NotImplementedException();
        }

        internal SubtractExprNode makeSubtractExprNode(ExprNode lhs, ExprNode rhs)
        {
            throw new NotImplementedException();
        }

        internal MultiplyExprNode makeMultiplyExprNode(ExprNode lhs, ExprNode rhs)
        {
            throw new NotImplementedException();
        }

        internal DivideExprNode makeDivideExprNode(ExprNode lhs, ExprNode rhs)
        {
            throw new NotImplementedException();
        }

        internal ModuloExprNode makeModuloExprNode(ExprNode lhs, ExprNode rhs)
        {
            throw new NotImplementedException();
        }

        internal ShiftLeftExprNode makeShiftLeftExprNode(ExprNode lhs, ExprNode rhs)
        {
            throw new NotImplementedException();
        }

        internal ShiftRightExprNode makeShiftRightExprNode(ExprNode lhs, ExprNode rhs)
        {
            throw new NotImplementedException();
        }

        internal LessThanExprNode makeLessThanExprNode(ExprNode lhs, ExprNode rhs)
        {
            throw new NotImplementedException();
        }

        internal GreaterThanExprNode makeGreaterThanExprNode(ExprNode lhs, ExprNode rhs)
        {
            throw new NotImplementedException();
        }

        internal LessEqualExprNode makeLessEqualExprNode(ExprNode lhs, ExprNode rhs)
        {
            throw new NotImplementedException();
        }

        internal GreaterEqualExprNode makeGreaterEqualExprNode(ExprNode lhs, ExprNode rhs)
        {
            throw new NotImplementedException();
        }

        internal EqualsExprNode makeEqualsExprNode(ExprNode lhs, ExprNode rhs)
        {
            throw new NotImplementedException();
        }

        internal NotEqualsExprNode makeNotEqualsExprNode(ExprNode lhs, ExprNode rhs)
        {
            throw new NotImplementedException();
        }

        internal ANDExprNode makeANDExprNode(ExprNode lhs, ExprNode rhs)
        {
            throw new NotImplementedException();
        }

        internal XORExprNode makeXORExprNode(ExprNode lhs, ExprNode rhs)
        {
            throw new NotImplementedException();
        }

        internal ORExprNode makeORExprNode(ExprNode lhs, ExprNode rhs)
        {
            throw new NotImplementedException();
        }

        internal LogicalANDExprNode makeLogicalANDExprNode(ExprNode lhs, ExprNode rhs)
        {
            throw new NotImplementedException();
        }

        internal LogicalORExprNode makeLogicalORExprNode(ExprNode lhs, ExprNode rhs)
        {
            throw new NotImplementedException();
        }

        internal ConditionalExprNode makeConditionalExprNode(ExprNode lhs, ExpressionNode expr, ExprNode condit)
        {
            throw new NotImplementedException();
        }

        internal ExprNode makeAssignExpressionNode(ExprNode lhs, AssignOperatorNode oper, ExprNode rhs)
        {
            throw new NotImplementedException();
        }
    }
}
