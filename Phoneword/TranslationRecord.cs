using Newtonsoft.Json;
namespace Phoneword
{
	public class TranslationRecord
	{

		[JsonProperty("character")]
		public string character;

		[JsonProperty("number")]
		public string number;
	}
}
