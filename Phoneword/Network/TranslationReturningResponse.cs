using Newtonsoft.Json;
using System.Collections.Generic;

namespace Phoneword
{
	public class TranslationReturningResponse
	{
		[JsonProperty("affected_rows")]
		public int affectedRows;

		[JsonProperty("returning")]
		public List<TranslationRecord> todoRecords;
	}
}

