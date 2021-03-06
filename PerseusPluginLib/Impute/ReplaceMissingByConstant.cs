using System.Drawing;
using BaseLib.Param;
using BaseLibS.Param;
using PerseusApi.Document;
using PerseusApi.Generic;
using PerseusApi.Matrix;

namespace PerseusPluginLib.Impute{
	public class ReplaceMissingByConstant : IMatrixProcessing{
		public bool HasButton { get { return false; } }
		public Bitmap DisplayImage { get { return null; } }
		public string Description { get { return "Replaces all missing values in expression columns with a constant."; } }
		public string HelpOutput { get { return "Same matrix but with missing values replaced."; } }
		public string[] HelpSupplTables { get { return new string[0]; } }
		public int NumSupplTables { get { return 0; } }
		public string Name { get { return "Replace missing values by constant"; } }
		public string Heading { get { return "Imputation"; } }
		public bool IsActive { get { return true; } }
		public float DisplayRank { get { return 1; } }
		public string[] HelpDocuments { get { return new string[0]; } }
		public int NumDocuments { get { return 0; } }

		public string Url{
			get{
				return
					"http://141.61.102.17/perseus_doku/doku.php?id=perseus:activities:MatrixProcessing:Imputation:ReplaceMissingByConstant";
			}
		}

		public int GetMaxThreads(Parameters parameters) { return 1; }

		public void ProcessData(IMatrixData mdata, Parameters param, ref IMatrixData[] supplTables,
			ref IDocumentData[] documents, ProcessInfo processInfo){
			float value = (float) param.GetParam<double>("Value").Value;
			ReplaceMissingsByVal(value, mdata);
		}

		public Parameters GetParameters(IMatrixData mdata, ref string errorString){
			return
				new Parameters(new Parameter[]
				{new DoubleParam("Value", 0){Help = "The value that is going to be filled in for missing values."}});
		}

		public static void ReplaceMissingsByVal(float value, IMatrixData data){
			for (int i = 0; i < data.RowCount; i++){
				for (int j = 0; j < data.ColumnCount; j++){
					if (float.IsNaN(data.Values[i, j])){
						data.Values[i, j] = value;
						data.IsImputed[i, j] = true;
					}
				}
			}
		}
	}
}