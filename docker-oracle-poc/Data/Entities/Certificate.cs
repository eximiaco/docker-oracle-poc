using System;

namespace docker_oracle_poc.Data.Entities
{
    public class Certificate
    {
        public Certificate(Guid id, int number)
        {   
            Id = id;
            Number = number;
        }

        public Certificate()
        {
            
        }

        public Guid Id { get; private set; }

        public int Number { get; private set; }
    }
}