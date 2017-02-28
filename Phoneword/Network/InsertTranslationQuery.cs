using Newtonsoft.Json;
using System.Collections.Generic;

namespace Phoneword
{
	public class InsertTranslationQuery
	{
		[JsonProperty("type")]
		string type = "insert";

		[JsonProperty("args")]
		Args args { get; set; }

		public InsertTranslationQuery(TranslationRecord record)
		{
			args = new Args();
			args.objects = new List<TranslationRecord>();
			args.objects.Add(record);
		}

		class Args
		{
			[JsonProperty("table")]
			string table = "phoneword_translation";

			[JsonProperty("returning")]
			string[] returning = {
				"id","character","number"
			};

			[JsonProperty("objects")]
			public List<TranslationRecord> objects { get; set; }
		}
	}
}
