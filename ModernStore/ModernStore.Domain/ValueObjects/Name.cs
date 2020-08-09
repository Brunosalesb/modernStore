using FluentValidator;

namespace ModernStore.Domain.ValueObjects
{
    public class Name : Notifiable
    {
        public Name(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;

            new ValidationContract<Name>(this)
                .IsRequired(x => x.FirstName, "Nome é obrigatório")
                .HasMaxLenght(x => x.FirstName, 60, "Nome possuí um máximo de 60 caracteres")
                .HasMinLenght(x => x.FirstName, 3, "Nome possuí um mínimo de 3 caracteres")
                .IsRequired(x => x.LastName, "Sobrenome é obrigatório")
                .HasMaxLenght(x => x.LastName, 60, "Sobrenome possuí um máximo de 60 caracteres")
                .HasMinLenght(x => x.LastName, 3, "Sobrenome possuí um mínimo de 3 caracteres");
        }

        public string FirstName { get; private set; }
        public string LastName { get; private set; }

        public override string ToString()
        {
            return FirstName + " " + LastName;
        }
    }
}
