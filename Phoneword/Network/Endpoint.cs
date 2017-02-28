using System;
namespace Phoneword
{
	public struct Endpoint
	{
		static string PROJECT_NAME = "armature32";
		static string DATA_URL = "https://data." + PROJECT_NAME + ".hasura-app.io";
		public static string QUERY_URL = DATA_URL + "/v1/query";
	}
}
