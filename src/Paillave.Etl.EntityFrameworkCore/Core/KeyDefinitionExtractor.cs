using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Reflection;

namespace Paillave.Etl.EntityFrameworkCore.Core
{
    public class KeyDefinitionExtractor
    {
        public static List<PropertyInfo> GetKeys<T>(Expression<Func<T, object>> getKey)
        {
            var vis = new KeyVisitor();
            vis.Visit(getKey);
            return vis.PropertyInfos;
        }
        private class KeyVisitor : ExpressionVisitor
        {
            public List<PropertyInfo> PropertyInfos { get; } = new List<PropertyInfo>();
            protected override Expression VisitMember(MemberExpression node)
            {
                PropertyInfos.Add((PropertyInfo)node.Member);
                return base.VisitMember(node);
            }
        }

    }
}