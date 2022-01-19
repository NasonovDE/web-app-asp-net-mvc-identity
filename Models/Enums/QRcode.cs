using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace web_app_asp_net_mvc_identity.Models.Enums
{
	public enum QRcode
	{
		[Display(Name = "Требуется наличие QR кода")]
		QRcodeYes = 1,

		[Display(Name = "QR код не требуется")]
		QRcodeNo = 2,
	}
}