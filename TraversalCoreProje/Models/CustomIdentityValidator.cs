using Microsoft.AspNetCore.Identity;

namespace TraversalCoreProje.Models
{
    public class CustomIdentityValidator : IdentityErrorDescriber
    {
        public override IdentityError PasswordTooShort(int length)
        {
            return new IdentityError()
            {
                Code = "PasswordTooShort",
                Description = $"Parolo Minimum {length} karakter olmalıdır"
            };
        }
        public override IdentityError PasswordRequiresUpper()
        {
            return new IdentityError()
            {
                Code = "PasswordRequiresUpper",
                Description = "Parolo en az 1 büyük karaterden oluşmalıdır."
            };
        }
        public override IdentityError PasswordRequiresLower()
        {
            return new IdentityError()
            {
                Code = "PasswordRequiresUpper",
                Description = "Parolo en az 1 küçük karaterden oluşmalıdır."
            };
        }
        public override IdentityError PasswordRequiresNonAlphanumeric()
        {
            return new IdentityError()
            {
                Code = "PasswordRequiresNonAlphanumeric",
                Description = "Parolo en az 1 küçük karaterden oluşmalıdır."
            };
        }
        public override IdentityError PasswordRequiresDigit()
        {
            return new IdentityError()
            {
                Code = "passwordRequiredDigit",
                Description = "parolo en az 1 rakam içermelidir"
            };
        }

    }
}
