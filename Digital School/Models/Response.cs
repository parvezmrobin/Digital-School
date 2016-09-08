using AspNet.Identity.MySQL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Digital_School.Models
{
	public class Response
	{
		public int Id;
		public int ApplicatoinId;
		public string FirstName;
		public string LastName;
		public string FathersName;
		public string MothersName;
		public int Gender;
		public DateTime BirthDate;
		public string Address;
		public string Email;
		public string PhoneNumber;
		public int DesignationId;
		public string Qualification;
		public int Class;
		public string GaurdianOccupation;
		public string GaurdianOccupationDetail;

		static Response getResponseById(int id) {
			Response response = null;
			MySQLDatabase db = new MySQLDatabase();
			List<Dictionary< string, string>> res = db.Query("getResponseById", new Dictionary<string, object>() { { "@pid", id } }, true);
			if(res.Count > 0) {
				response = new Response() {
					Id = id,
					ApplicatoinId = Convert.ToInt32(res[0]["applicationid"]),
					FirstName = res[0]["firstname"],
					LastName = res[0]["lastname"],
					FathersName = res[0]["fathersname"],
					MothersName = res[0]["mothersname"],
					Gender = Convert.ToInt32(res[0]["gender"]),
					BirthDate = DateTime.Parse(res[0]["birthdate"]),
					Address = res[0]["address"],
					Email = res[0]["email"],
					PhoneNumber = res[0]["phoneNumber"],
					DesignationId = Convert.ToInt32(res[0]["designationId"]),
					Qualification = res[0]["qualification"],
					Class = Convert.ToInt32(res[0]["class"]),
					GaurdianOccupation = res[0]["GaurdianOccupation"],
					GaurdianOccupationDetail = res[0]["GaurdianOccupationDetail"]
				};
			}

			return response;
		}
	}
}