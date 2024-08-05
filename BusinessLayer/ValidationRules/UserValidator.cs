using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
	public class UserValidator : AbstractValidator<User>
	{
		public UserValidator()
		{
			RuleFor(x => x.Ad).NotEmpty().WithMessage("Adı soyadı kısmı boş geçilemez");
			RuleFor(x => x.Email).NotEmpty().WithMessage("Mail adresi boş geçilemez");
			RuleFor(x => x.Sifre).NotEmpty().WithMessage("Şifre boş geçilemez");
		}
	}
}
