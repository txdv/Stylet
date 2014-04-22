﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Stylet
{
    /// <summary>
    /// Useful extension methods on Expressions
    /// </summary>
    public static class ExpressionExtensions
    {
        /// <summary>
        /// Given a MemberExpression (or MemberExpression wrapped in a UnaryExpression), get the name of the property
        /// </summary>
        /// <returns>Name of the property referenced by the expression</returns>
        public static string NameForProperty<TDelegate>(this Expression<TDelegate> propertyExpression)
        {
            Expression body;
            if (propertyExpression.Body is UnaryExpression)
                body = ((UnaryExpression)propertyExpression.Body).Operand;
            else
                body = propertyExpression.Body;

            var member = body as MemberExpression;
            if (member == null)
                throw new ArgumentException("Property must be a MemberExpression");

            return member.Member.Name;
        }
    }
}
