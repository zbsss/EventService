namespace Organizer
{
    // klasa bazowa
    public class Entity
    {
        private static int _counter = 0;

        // unikalny identyfikator 
        public int Id { get; protected set; }

        // ctor
        public Entity()
        {
            Id = ++_counter;
        }
    }
}



