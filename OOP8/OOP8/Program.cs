using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP8
{
    class Program
    {
        static void Main(string[] args)
        {
            const string FastAgent = "fastAgent";
            const string HeavyAgent = "heavyAgent";
            const string AverageAgent = "averageAgent";
            const string BadlyAgent = "badlyAgent";
            const string DonationAgent = "donationAgent";

            List<Agent> agents = new List<Agent>() { new FastAgent(110, 40, 20, FastAgent), new AvarageAgent(160, 35, 30, AverageAgent), new HeavyAgent(210, 30, 40, HeavyAgent), new Badlyagent(100, 30, 10, BadlyAgent), new DonationAgent(200, 40, 40, DonationAgent) };

            Console.WriteLine($"Введите номер первого агента:\n1.быстрый агент - {FastAgent}\n2.обычный агент - {AverageAgent}\n3.тяжёлый агент - {HeavyAgent}\n4.слабый агент - {BadlyAgent}\n5.премиум агент - {DonationAgent}");
            int indexFirstAgent = Convert.ToInt32(Console.ReadLine()) - 1;

            Console.WriteLine($"Введите номер второго агента:\n1.быстрый агент - {FastAgent}\n2.обычный агент - {AverageAgent}\n3.тяжёлый агент - {HeavyAgent}\n4.слабый агент - {BadlyAgent}\n5.премиум агент - {DonationAgent}");
            int indexSecondAgent = Convert.ToInt32(Console.ReadLine()) - 1;

            if (indexFirstAgent > 4 || indexFirstAgent < 0 || indexSecondAgent > 4 || indexSecondAgent < 0 || indexSecondAgent == indexFirstAgent)
                Console.WriteLine("Некорректный ввод");
            else
            {
                Agent firstAgent = agents[indexFirstAgent];
                Agent secondAgent = agents[indexSecondAgent];

                while (secondAgent.HP > 0 && firstAgent.HP > 0)
                {
                    firstAgent.TakeDamage(secondAgent.Damage);
                    secondAgent.TakeDamage(firstAgent.Damage);

                    firstAgent.Ability();
                    secondAgent.Ability();

                    Console.WriteLine($"Здоровье первого агента - {firstAgent.HP}, здоровье второго агента - {secondAgent.HP}");
                }

                Console.WriteLine("---------------------");

                if (secondAgent.HP <= 0 && firstAgent.HP <= 0)
                    Console.WriteLine("Ничья");
                else if (secondAgent.HP <= 0)
                    Console.WriteLine(firstAgent.TypeAgent + " выиграл");
                else
                    Console.WriteLine(secondAgent.TypeAgent + " выиграл");
            }

            Console.ReadKey();
        }
    }

    abstract class Agent
    {
        public int HP { get; set; }
        public int Damage { get; set; }
        public int Armor { get; set; }
        public string TypeAgent { get; private set; }

        public Agent(int hp, int damage, int armor, string typeAgent)
        {
            HP = hp;
            Damage = damage;
            Armor = armor;
            TypeAgent = typeAgent;
        }

        public void TakeDamage(int enemyAgentDamage)
        {
            HP -= enemyAgentDamage * (1 - Armor / 100);
        }

        public abstract void Ability();
    }

    class FastAgent : Agent
    {
        public FastAgent(int hp, int damage, int armor, string typeAgent) : base(hp, damage, armor, typeAgent)
        {
        }

        private bool _canHelhealing = true;

        public override void Ability()
        {
            if (HP < 50 && _canHelhealing)
            {
                Damage *= 2;

                _canHelhealing = false;

                Console.WriteLine("Урон увеличен в 2 раза");
            }
        }
    }

    class HeavyAgent : Agent
    {
        public HeavyAgent(int hp, int damage, int armor, string typeAgent) : base(hp, damage, armor, typeAgent) 
        {
        }

        private bool _canHelhealing = true;

        public override void Ability()
        {
            if (HP < 75 && _canHelhealing)
            {
                HP += 40;
                _canHelhealing = false;

                Console.WriteLine("Аптечка восстановила 40 HP");
            }
        }
    }

    class AvarageAgent : Agent
    {
        public AvarageAgent(int hp, int damage, int armor, string typeAgent) : base(hp, damage, armor, typeAgent)
        {
        }

        private bool _canHelhealing = true;

        public override void Ability()
        {
            if (HP < 75 && _canHelhealing)
            {
                Armor += 15;
                _canHelhealing = false;

                Console.WriteLine("Довавлена бронеплита");
            }
        }
    }

    class DonationAgent : Agent
    {
        public DonationAgent(int hp, int damage, int armor, string typeAgent) : base(hp, damage, armor, typeAgent)
        {
        }

        private bool _canHelhealing = true;

        public override void Ability()
        {
            if (HP < 75 && _canHelhealing)
            {
                Armor += 15;
                HP += 40;
                Damage *= 2;

                Console.WriteLine("Всё увеличено");
            }
        }
    }

    class Badlyagent : Agent
    {
        public Badlyagent(int hp, int damage, int armor, string typeAgent) : base(hp, damage, armor, typeAgent)
        {
        }

        private bool _canHelhealing = true;

        public override void Ability()
        {
            if (HP < 50 && _canHelhealing)
            {
                _canHelhealing = false;
                HP += 15;

                Console.WriteLine("Бинт восстановила 15 HP");
            }
        }
    }
}
