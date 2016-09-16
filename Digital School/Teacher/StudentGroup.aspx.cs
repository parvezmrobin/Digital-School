using AspNet.Identity.MySQL;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Digital_School.Teacher
{
	public partial class StudentGroup : System.Web.UI.Page
	{
		protected void Page_Init(object sender, EventArgs e) {
			MySQLDatabase db = new MySQLDatabase();
			if (!IsPostBack) {
				BindDLL();
				LoadCBAdd(sender, e);
				LoadCBRemove(sender, e);
			}
		}

		private void BindDLL() {
			MySQLDatabase db = new MySQLDatabase();
			var yearId = db.QueryValue("getYearId", new Dictionary<string, object>() { { "@pyear", DateTime.Now.Year } }, true);
			var teacherId = Context.GetOwinContext().GetUserManager<ApplicationUserManager>().FindByName(User.Identity.Name).Id;
			ReloadDDLGroup();

			ddlClass.DataSource = db.Query(
					"getClassByTUIdYId",
					new Dictionary<string, object>() {
						{ "@TUId", teacherId },
						{ "@YId", yearId } },
					true)
					.Select(x => new {
						Text = x["class"],
						Value = x["classid"]
					}).ToList();
			ddlClass.DataBind();

			ReloadDDLSection(teacherId, yearId);
		}

		protected void btnCreateGroup_Click(object sender, EventArgs e) {
			MySQLDatabase db = new MySQLDatabase();
			var teacherId = db.QueryValue("getTIdByTUN", new Dictionary<string, object>() { { "@TUN", User.Identity.Name } }, true);
			//string query = "INSERT INTO `group` VALUES(null, '" + teacherId + "', '" + txtGroupName.Text + "';";
			db.Execute("addGroup", new Dictionary<string, object>() {
				{"@TId", teacherId },
				{"@name", txtGroupName.Text }
			}, true);
			BindDLL();
		}

		protected void LoadCBRemove(object obj, EventArgs e) {
			MySQLDatabase db = new MySQLDatabase();
			cbRemove.DataSource = db.Query("getAllGroupMemberByGId",
				new Dictionary<string, object>() {
					{"@Gid", ddlGroup.SelectedValue }
				}, true).Select(x => new {
					Text = x["student"],
					Value = x["studentid"]
				}).ToList();
			cbRemove.DataBind();
		}
		protected void LoadCBAdd(object obj, EventArgs e) {
			//TODO remove students who are already in the group
			MySQLDatabase db = new MySQLDatabase();
			var yearId = db.QueryValue("getYearId", new Dictionary<string, object>() { { "@pyear", DateTime.Now.Year } }, true);
			var YCSId = db.QueryValue("getYearClassSectionId",
				new Dictionary<string, object>() {
					{"@pyearid", yearId },
					{"@pclassid", ddlClass.SelectedValue },
					{"@psectionid", ddlSection.SelectedValue }
				}, true);
			cbAdd.DataSource = db.Query("getStudentByTUNYCSId",
				new Dictionary<string, object>() {
					{"@TUN", User.Identity.Name },
					{"@YCSId", YCSId }
				}, true).Select(x => new {
					Text = x["student"],
					Value = x["studentid"]
				}).ToList();
			cbAdd.DataBind();
		}

		protected void ddlClass_SelectedIndexChanged(object sender, EventArgs e) {
			MySQLDatabase db = new MySQLDatabase();
			var yearId = db.QueryValue("getYearId", new Dictionary<string, object>() { { "@pyear", DateTime.Now.Year } }, true);
			var teacherId = db.QueryValue("getTIdByTUN", new Dictionary<string, object>() { { "@TUN", User.Identity.Name } }, true);

			ReloadDDLSection(teacherId, yearId);
			LoadCBAdd(sender, e);
		}

		private void ReloadDDLSection(object teacherId, object yearId) {
			MySQLDatabase db = new MySQLDatabase();
			ddlSection.DataSource = db.Query(
					"getSectionByTUIdYIdCId",
					new Dictionary<string, object>() {
						{"@TUId", teacherId },
						{"@YId", yearId },
						{"@CId", ddlClass.SelectedValue }
					}, true)
					.Select(x => new {
						Text = x["section"],
						Value = x["sectionid"]
					}).ToList();
			ddlSection.DataBind();
		}

		private void ReloadDDLGroup() {
			MySQLDatabase db = new MySQLDatabase();
			ddlGroup.DataSource = db.Query(
				"getGroupByTUN",
				new Dictionary<string, object>() {
						{"@TUN", User.Identity.Name }
				}, true).Select(x =>
					new {
						Text = x["group"],
						Value = x["id"]
					}).ToList();
			ddlGroup.DataBind();
		}

		protected void btnAdd_Click(object sender, EventArgs e) {
			MySQLDatabase db = new MySQLDatabase();
			foreach (ListItem item in cbAdd.Items) {
				if (item.Selected) {
					db.Execute("addGroupMember", new Dictionary<string, object>() {
						{"@groupid", ddlGroup.SelectedValue },
						{"@studentId", item.Value }
					}, true);
				}
			}
			LoadCBRemove(sender, e);
			LoadCBAdd(sender, e);
		}

		protected void btnRemove_Click(object sender, EventArgs e) {
			//removeGroupMember
			MySQLDatabase db = new MySQLDatabase();
			foreach (ListItem item in cbRemove.Items) {
				if (item.Selected) {
					db.Execute("removeGroupMember", new Dictionary<string, object>() {
						{"@pgroupid", ddlGroup.SelectedValue },
						{"@pstudentId", item.Value }
					}, true);
				}
			}
			LoadCBRemove(sender, e);
			LoadCBAdd(sender, e);
		}

		protected void btnRemoveGroup_Click(object sender, EventArgs e) {
			new MySQLDatabase().Execute("removeGroup", new Dictionary<string, object>() { { "@pgroupId", ddlGroup.SelectedValue } }, true);
			ReloadDDLGroup();
		}
	}
}