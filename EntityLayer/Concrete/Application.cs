using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
	public class Application
	{
		public int Id { get; set; }
		public int UserId { get; set; }
		public string Adres { get; set; }
		public string BasvuruNedeni { get; set; }
		public string Foto { get; set; }
		public virtual User User { get; set; }

	}
}
