using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Dynamic.Core.Exceptions;


public static class Filter
{
    public static Expression<Func<T, bool>> FromStringExpression<T>(string query, string parameter = "x")
    {
        try
        {
            ParameterExpression parameterExpression = Expression.Parameter(typeof(T), parameter);
            return (Expression<Func<T, bool>>)DynamicExpressionParser.ParseLambda(
                new ParameterExpression[] { parameterExpression }, null, query);
        }
        catch (Exception)
        {
            throw new ArgumentException("La expresión de filtro no es válida.");
        }
    }
}  
    

