namespace StrategyPattern
{
    public interface IWeapon
    {
        void UseWeapon();
    }

    public class Sword : IWeapon
    {
        public void UseWeapon()
        {
            Console.WriteLine("Игрок атакует мечом!");
        }
    }

    public class Bow : IWeapon
    {
        public void UseWeapon()
        {
            Console.WriteLine("Игрок натянул тетиву и выпустил стрелу!");
        }
    }

    public class Axe : IWeapon
    {
        public void UseWeapon()
        {
            Console.WriteLine("Игрок размахивает топором!");
        }
    }
        
    public class Player
    {
        private IWeapon weapon;

        public Player(IWeapon weapon)
        {
            this.weapon = weapon;
        }

        public void SetWeapon(IWeapon weapon)
        {
            this.weapon = weapon;
        }

        public void Attack()
        {
            if (weapon != null)
            {
                weapon.UseWeapon();
            }
            else
            {
                Console.WriteLine("У игрока нет оружия!");
            }
        }
    }

    // 4. Класс Game
    public class Game
    {
        private Player player;

        public Game()
        {
            player = new Player(new Sword()); // Начальное оружие - меч
        }

        public void Run()
        {
            bool running = true;
            while (running)
            {
                Console.WriteLine("\nВыберите оружие:");
                Console.WriteLine("1. Меч");
                Console.WriteLine("2. Лук");
                Console.WriteLine("3. Топор");
                Console.WriteLine("4. Выйти");

                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        player.SetWeapon(new Sword());
                        break;
                    case "2":
                        player.SetWeapon(new Bow());
                        break;
                    case "3":
                        player.SetWeapon(new Axe());
                        break;
                    case "4":
                        running = false;
                        break;
                    default:
                        Console.WriteLine("Неверный выбор.");
                        break;
                }

                if (running)
                {
                    Console.WriteLine("\nИгрок атакует:");
                    player.Attack();
                }
            }
        }
    }

    public class Program
    {
        public static void Main(string[] args)
        {
            Game game = new Game();
            game.Run();
        }
    }
}