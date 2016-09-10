using System;
using System.Runtime.Serialization;

namespace Digital_School.User_Control
{
	[Serializable]
	public partial class MarkPortion : System.Web.UI.UserControl
	{
		
		public event EventHandler SubmitClick;

		public string PortionName {
			get { return lbl.Text; }
			set { lbl.Text = value; }
		}

		public float? Mark {
			get { return Convert.ToSingle(txt.Text); }
			set { txt.Text = value?.ToString(); }
		}

		public int? MarkId {
			get { return Convert.ToInt32(hf1.Value); }
			set { hf1.Value = value?.ToString(); }
		}

		public int? MarkPortionId {
			get { return Convert.ToInt32(hf2.Value); }
			set { hf2.Value = value?.ToString(); }
		}
		
		public void OnSubmitClick(EventArgs e) {
			SubmitClick?.Invoke(this, e);
		}

		protected void btnSubmit_Click(object sender, EventArgs e) {
			OnSubmitClick(e);
		}
	}
}