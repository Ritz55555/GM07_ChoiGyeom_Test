using Day18;
using Total;
using Item;
using System;
using static System.Net.Mime.MediaTypeNames;

namespace Player
{
    class PlayerStat
    {
        SkillTotal skillTotal = new SkillTotal();
        List<SkillDes> skillList = new List<SkillDes>();
        public int Hp { get; set; } = 50;
        public int Mp { get; set; } = 20;
        public int Atk { get; set; } = 10;
        public int Matk { get; set; } = 10;
        public int Def { get; set; } = 0;
        public int TotalHp { get; set; } = 0;
        public int NowHp { get; set; } = 0;
        public int TotalMp { get; set; } = 0;
        public int NowMp { get; set; } = 0;
        public int TotalAtk { get; set; } = 0;
        public int TotalMatk { get; set; } = 0;
        public int TotalDef { get; set; } = 0;
        public int Level { get; set; } = 1;
        public int Exp { get; set; } = 0;
        public int Gold { get; set; } = 5000;


        public void LevelTotal(int exp)
        {
            int needExp = Level * 50 + (Level - 1 * 20);

            Exp += exp;
            Console.WriteLine($"{exp}만큼의 경험치를 획득했다.");
            if (Exp >= needExp)
            {
                Exp -= needExp;
                Level += 1;
                Hp += 10;
                Mp += 5;
                Atk += 1;
                Matk += 1;
                TotalHp = Hp;
                NowHp = TotalHp;
                TotalMp = Mp;
                NowMp = TotalMp;
                TotalAtk = Atk;
                TotalMatk = Matk;
                TotalDef = Def;
                Console.WriteLine($"레벨 업 ! 현재 레벨 : {Level}");
            }
        }
        public void GoldTotal(int gold)
        {
            Gold += gold;
            Console.WriteLine($"{gold}만큼의 골드를 획득했다.");
        }
        public void SetTotalHp(int hp, int value)
        {
            TotalHp = hp + value;
        }
        public void SetTotalMp(int mp, int value)
        {
            TotalMp = mp + value;
        }
        public void TakeDamage(int damage)
        {
            NowHp = NowHp - damage;
        }
        public void TakeHeal(int heal)
        {
            NowHp = NowHp + heal;
        }
        public bool UseMp(int cost)
        {
            if (NowMp < cost)
            {
                Console.WriteLine("MP부족, 스킬 혹은 마법을 사용할 수 없습니다.");
                return false;
            }
            else
            {
                NowMp = NowMp - cost;
                return true;
            }
        }
        public void TakeMpHeal(int heal)
        {
            NowMp = NowMp + heal;
        }
        public void SetTotalAtk(int atk, int value, bool equ)
        {
            if (equ == true)
            {
                TotalAtk = atk + value;
            }
            else if (equ == false)
            {
                TotalAtk = atk;
            }
        }
        public void SetTotalMAtk(int matk, int value, bool equ)
        {
            if (equ == true)
            {
                TotalMatk = matk + value;
            }
            else if (equ == false)
            {
                TotalMatk = matk;
            }
        }
        public void SetTotalDef(int def, int value, bool equ)
        {
            if (equ == true)
            {
                TotalDef = def + value;
            }
            else if (equ == false)
            {
                TotalDef = def;
            }
        }
        
        public void AllStatView()
        {
            Console.WriteLine($"레벨 : {Level}");
            Console.WriteLine($"현재 경험치 : {Exp}");
            Console.WriteLine($"최대 체력 : {TotalHp}");
            Console.WriteLine($"최대 마나 : {TotalMp}");
            Console.WriteLine($"공격력 : {TotalAtk}");
            Console.WriteLine($"주문력 : {TotalMatk}");
            Console.WriteLine($"방어력 : {TotalDef}");

        }
        
        
        


    }
}
