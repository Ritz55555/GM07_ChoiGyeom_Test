using Player;
using System.Reflection.Emit;
using System.Xml.Linq;
using Total;

namespace Monster
{
    abstract class MonsterStat
    {
        public virtual string Name { get; set; } = "";
        public int Hp { get; set; } = 0;
        public int Mp { get; set; } = 0;
        public int Atk { get; set; } = 0;
        public int Matk { get; set; } = 0;
        public int Def { get; set; } = 0;
        public int Exp { get; set; } = 0;
        public int Gold { get; set; } = 0;
        public virtual int Level { get; set; }
        Random ran = new Random();
        public abstract int Attack(MonsterStat monster, PlayerStat player, TotalIm total);
        public abstract int Skill(MonsterStat monster, PlayerStat player, TotalIm total);
        public abstract int AttackOrSkill(MonsterStat monster, PlayerStat player, TotalIm total);

        public void RandomMonster()
        {
            int mobStat = 15;
            int sang = ran.Next(80, 120);
            Hp = (mobStat * 2 + (mobStat / 2 * Level)) * sang / 100;
            Mp = (mobStat + (mobStat / 3 * Level / 2)) * sang / 100;
            Atk = (mobStat / 3 + (Level / 2)) * sang / 100;
            Matk = (mobStat / 3 + Level) * sang / 100;
            Def = (mobStat / 5 + (Level / 4)) * sang / 100;
            Exp = (Level * mobStat + ((Level + Level) * 2)) * sang / 100;
            Gold = Exp * 10;
        }
    }
    class Slime : MonsterStat
    {
        public string name = "슬라임";
        public int level = 1;
        public override string Name => name;
        public override int Level => level;
        public override int Attack(MonsterStat monster, PlayerStat player, TotalIm total)
        {
            Console.WriteLine($"{monster.Name}의 공격!");
            int damage = monster.Atk - player.TotalDef;
            return damage;
        }
        public override int Skill(MonsterStat monster, PlayerStat player, TotalIm total)
        {
            Console.WriteLine($"{monster.Name}의 점액뿌리기!");
            int damage = monster.Matk - player.TotalDef;
            return damage;
        }
        public override int AttackOrSkill(MonsterStat monster, PlayerStat player, TotalIm total)
        {
            Random ran = new Random();
            int mu = ran.Next(1, 100);
            int a;
            if(Mp >= 5)
            {
                if(mu >= 80)
                {
                    a = Skill(monster, player, total);
                }
                else
                {
                    a = Attack(monster, player, total);
                }
            }
            else
            {
                a = Attack(monster, player, total);
            }
            return a;
        }
    }
    class Goblin : MonsterStat
    {
        public string name = "고블린";
        public int level = 5;
        public override string Name => name;
        public override int Level => level;
        public override int Attack(MonsterStat monster, PlayerStat player, TotalIm total)
        {
            Console.WriteLine($"{monster.Name}의 공격!");
            int damage = monster.Atk - player.TotalDef;
            return damage;
        }
        public override int Skill(MonsterStat monster, PlayerStat player, TotalIm total)
        {
            Console.WriteLine($"{monster.Name}의 급소찌르기!");
            int damage = monster.Matk - player.TotalDef;
            return damage;
        }
        public override int AttackOrSkill(MonsterStat monster, PlayerStat player, TotalIm total)
        {
            Random ran = new Random();
            int mu = ran.Next(1, 100);
            int a;
            if (Mp >= 5)
            {
                if (mu >= 80)
                {
                    a = Skill(monster, player, total);
                }
                else
                {
                    a = Attack(monster, player, total);
                }
            }
            else
            {
                a = Attack(monster, player, total);
            }
            return a;
        }
    }
    class Lizard : MonsterStat
    {
        public string name = "리자드맨";
        public int level = 10;
        public override string Name => name;
        public override int Level => level;
        public override int Attack(MonsterStat monster, PlayerStat player, TotalIm total)
        {
            Console.WriteLine($"{monster.Name}의 공격!");
            int damage = monster.Atk - player.TotalDef;
            return damage;
        }
        public override int Skill(MonsterStat monster, PlayerStat player, TotalIm total)
        {
            Console.WriteLine($"{monster.Name}의 물 마법!");
            int damage = monster.Matk - player.TotalDef;
            return damage;
        }
        public override int AttackOrSkill(MonsterStat monster, PlayerStat player, TotalIm total)
        {
            Random ran = new Random();
            int mu = ran.Next(1, 100);
            int a;
            if (Mp >= 5)
            {
                if (mu >= 80)
                {
                    a =Skill(monster, player, total);
                }
                else
                {
                    a = Attack(monster, player, total);
                }
            }
            else
            {
                a = Attack(monster, player, total);
            }
            return a;
        }
    }
    class Orc : MonsterStat
    {
        public string name = "오크";
        public int level = 15;
        public override string Name => name;
        public override int Level => level;
        public override int Attack(MonsterStat monster, PlayerStat player, TotalIm total)
        {
            Console.WriteLine($"{monster.Name}의 공격!");
            int damage = monster.Atk - player.TotalDef;
            return damage;
        }
        public override int Skill(MonsterStat monster, PlayerStat player, TotalIm total)
        {
            Console.WriteLine($"{monster.Name}의 강력한 공격!");
            int damage = monster.Matk - player.TotalDef;
            return damage;
        }
        public override int AttackOrSkill(MonsterStat monster, PlayerStat player, TotalIm total)
        {
            Random ran = new Random();
            int mu = ran.Next(1, 100);
            int a;
            if (Mp >= 5)
            {
                if (mu >= 80)
                {
                    a =Skill(monster, player, total);
                }
                else
                {
                    a = Attack(monster, player, total);
                }
            }
            else
            {
                a = Attack(monster, player, total);
            }
            return a;
        }
    }
    class Oger : MonsterStat
    {
        public string name = "오우거";
        public int level = 20;
        public override string Name => name;
        public override int Level => level;
        public override int Attack(MonsterStat monster, PlayerStat player, TotalIm total)
        {
            Console.WriteLine($"{monster.Name}의 공격!");
            int damage = monster.Atk - player.TotalDef;
            return damage;
        }
        public override int Skill(MonsterStat monster, PlayerStat player, TotalIm total)
        {
            Console.WriteLine($"{monster.Name}의 지진강타!");
            int damage = monster.Matk - player.TotalDef;
            return damage;
        }
        public override int AttackOrSkill(MonsterStat monster, PlayerStat player, TotalIm total)
        {
            Random ran = new Random();
            int mu = ran.Next(1, 100);
            int a;
            if (Mp >= 5)
            {
                if (mu >= 80)
                {
                    a = Skill(monster, player, total);
                }
                else
                {
                    a = Attack(monster, player, total);
                }
            }
            else
            {
                a = Attack(monster, player, total);
            }
            return a;
        }
    }
}
