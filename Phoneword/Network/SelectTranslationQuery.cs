using System;
using Newtonsoft.Json;

namespace Phoneword
{
	public class SelectTranslationQuery
	{
		[JsonProperty("type")]
		string type = "select";

		[JsonProperty("args")]
		Args args = new Args();

		class Args
		{
			[JsonProperty("table")]
			string table = "phoneword_translation";

			[JsonProperty("columns")]
			string[] columns = {
				"character","number"
			};

		}
	}
}


