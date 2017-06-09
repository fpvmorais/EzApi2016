using Microsoft.SqlServer.Dts.Runtime;
using Microsoft.SqlServer.Dts.Tasks.ExecuteSQLTask;

namespace Microsoft.SqlServer.SSIS.EzAPI
{
    public static class EzHelpers
    {
        /// <summary>
        /// Extension method that adds Microsoft.SqlServer.Dts.Runtime.Variable with expression to the Microsoft.SqlServer.Dts.Runtime.Variables
        //     collection.
        /// </summary>
        /// <param name="vars"></param>
        /// <param name="name"></param>
        /// <param name="evaluateasexpression"></param>
        /// <param name="nameSpace"></param>
        /// <param name="expression"></param>
        /// <returns>Variable</returns>
        public static Variable Add(this Variables vars, string name, string nameSpace, string expression)
        {
            Variable x = vars.Add(name, false, nameSpace, string.Empty);
            x.Expression = expression;
            x.EvaluateAsExpression = true;
            x.Name = name;
            x.Namespace = nameSpace;

            return x;
        }

        /// <summary>
        /// Extension method to easily add parameters bindings to ExecSQLTask 
        /// </summary>
        /// <param name="binds"></param>
        /// <param name="parameterName"></param>
        /// <param name="dtsVariableName"></param>
        /// <param name="dataType"></param>
        public static void Add(this IDTSParameterBindings binds, string parameterName, string dtsVariableName, OleDBDataTypes dataType)
        {
            IDTSParameterBinding x = binds.Add();
            x.ParameterName = parameterName;
            x.DtsVariableName = dtsVariableName;
            x.DataType = (int)dataType;
        }

        /// <summary>
        /// Extension method to easily add parameters bindings with direction to ExecSQLTask 
        /// </summary>
        /// <param name="binds"></param>
        /// <param name="parameterName"></param>
        /// <param name="dtsVariableName"></param>
        /// <param name="dataType"></param>
        public static void Add(this IDTSParameterBindings binds, ParameterDirections direction, string parameterName, string dtsVariableName, OleDBDataTypes dataType)
        {
            IDTSParameterBinding x = binds.Add();
            x.ParameterName = parameterName;
            x.DtsVariableName = dtsVariableName;
            x.ParameterDirection = direction;
            x.DataType = (int)dataType;
        }

        /// <summary>
        /// Extension method to easily add result bindings to ExecSQLTask 
        /// </summary>
        /// <param name="binds"></param>
        /// <param name="resultName"></param>
        /// <param name="dtsVariableName"></param>
        public static void Add(this IDTSResultBindings binds, string resultName, string dtsVariableName)
        {
            IDTSResultBinding x = binds.Add();
            x.ResultName = resultName;
            x.DtsVariableName = dtsVariableName;
        }
    }
}
