﻿using System.Drawing;
using BaseLibS.Param;
using PerseusApi.Document;
using PerseusApi.Generic;
using PerseusApi.Matrix;

namespace PerseusPluginLib.Impute{
	public class ReplaceImputedByNan : IMatrixProcessing{
		public bool HasButton { get { return false; } }
		public Bitmap DisplayImage { get { return null; } }
		public string Description { get { return "Replaces all values that have been imputed with NaN."; } }
		public string HelpOutput { get { return "Same matrix but with imputed values deleted."; } }
		public string[] HelpSupplTables { get { return new string[0]; } }
		public int NumSupplTables { get { return 0; } }
		public string Name { get { return "Replace imputed values by NaN"; } }
		public string Heading { get { return "Imputation"; } }
		public bool IsActive { get { return true; } }
		public float DisplayRank { get { return 1; } }
		public string[] HelpDocuments { get { return new string[0]; } }
		public int NumDocuments { get { return 0; } }
		public string Url { get { return "http://141.61.102.17/perseus_doku/doku.php?id=perseus:activities:MatrixProcessing:Imputation:ReplaceImputedByNan"; } }

		public int GetMaxThreads(Parameters parameters) {
			return 1;
		}

		public Parameters GetParameters(IMatrixData mdata, ref string errorString) {
			return new Parameters(new Parameter[] { });
		}

		public void ProcessData(IMatrixData mdata, Parameters param, ref IMatrixData[] supplTables,
			ref IDocumentData[] documents, ProcessInfo processInfo){
			Replace(mdata);
		}

		public static void Replace(IMatrixData data){
			for (int i = 0; i < data.RowCount; i++){
				for (int j = 0; j < data.ColumnCount; j++){
					if (data.IsImputed[i, j]){
						data.Values[i, j] = float.NaN;
					}
				}
			}
		}
	}
}