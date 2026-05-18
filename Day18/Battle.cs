

using Day18;
using Item;
using Monster;
using Player;
using System.Numerics;
using System.Threading;
using Total;
using static System.Net.Mime.MediaTypeNames;

namespace Battle
{
    class BattleStart
    {
        public void InKey() //화면 안넘어가게 잠시 붙잡아두는 메서드
        {
            Console.WriteLine("확인 할려면 아무 키나 누르기 ");
            Console.ReadKey(true);
        }
        public void AllStat(MonsterStat monster, PlayerStat player)
        {
            Console.Clear();
            Console.WriteLine($"======{monster.Name}======\n체력 : {monster.Hp}\n마나 : {monster.Mp}\n" +
                    $"공격력 : {monster.Atk}\n주문력 : {monster.Matk}\n방어력 : {monster.Def}");
            Console.WriteLine($"======플레이어======\n체력 : {player.NowHp}\n마나 : {player.NowMp}\n" +
                $"공격력 : {player.TotalAtk}\n주문력 : {player.TotalMatk}\n방어력 : {player.TotalDef}");
            Console.WriteLine($"====================");
        }
        public void BattleNow(MonsterStat monster, PlayerStat player, List<SkillDes> skill, List<ItemDes> item, TotalIm total)
        {
            monster.RandomMonster();
            bool dj = false;

            Console.WriteLine("전투 시작!");
            while (true)
            { 
                AllStat(monster, player);
                Console.WriteLine("1. 기본 공격  2. 스킬/마법  3. 아이템");
                ConsoleKeyInfo key = Console.ReadKey(true);
                if(key.Key == ConsoleKey.D1)
                {
                    PlayerAttack(monster, player);
                }
                else if(key.Key == ConsoleKey.D2)
                {
                    PlayerSkill(monster, player, total);
                }
                else if (key.Key == ConsoleKey.D3)
                {
                    PlayerItem(monster, player, total);
                } 
                else
                {
                    continue;
                }
                InKey();
                WinOrDefeat(monster, player, ref dj);
                if(dj == true)
                {
                    AllStat(monster, player);
                    if(monster.Hp == 0)
                    {
                        Console.WriteLine("승리!");
                        player.LevelTotal(monster.Exp);
                        player.GoldTotal(monster.Gold);
                        PlayerHeal(player);
                    }
                    else if(player.NowHp == 0)
                    {
                        Console.WriteLine("패배");
                        PlayerHeal(player);
                    }
                    InKey();
                    break;
                }
                int mobDamage = monster.AttackOrSkill(monster, player ,total);
                if (mobDamage < 0)
                {
                    mobDamage = 0;
                }
                Console.WriteLine($"플레이어는 {mobDamage}만큼의 피해를 받았다!");
                player.NowHp -= mobDamage;
                InKey();
                WinOrDefeat(monster, player, ref dj);
                if (dj == true)
                {
                    AllStat(monster, player);
                    if (monster.Hp == 0)
                    {
                        Console.WriteLine("승리!");
                        player.LevelTotal(monster.Exp);
                        player.GoldTotal(monster.Gold);
                        PlayerHeal(player);
                    }
                    else if (player.NowHp == 0)
                    {
                        Console.WriteLine("패배");
                        PlayerHeal(player);
                    }
                    InKey();
                    break;
                }
            }
        }
        public void PlayerHeal(PlayerStat player)
        {
            player.NowHp = player.TotalHp;
            player.NowMp = player.TotalMp;
        }
        public void PlayerAttack(MonsterStat monster, PlayerStat player)
        {
            Console.WriteLine("플레이어의 공격!");
            int damage = player.TotalAtk - monster.Def;
            if (damage < 0)
            {
                damage = 0;
            }
            Console.WriteLine($"{monster.Name}은(는) {damage}만큼의 피해를 받았다!");
            monster.Hp -= damage;
        }
        public void PlayerSkill(MonsterStat monster, PlayerStat player, TotalIm total)
        {
            while (true)
            {
                List<SkillDes> ski = total.SeeSkill();
                if(ski == null)
                {
                    continue;
                }
                else
                {
                    AllStat(monster, player);
                    Console.WriteLine($"플레이어의 {ski[0].Name}공격!");
                    int damage = ((player.TotalAtk * ski[0].Value)/100) - monster.Def;
                    if(damage < 0)
                    {
                        damage = 0;
                    }
                    Console.WriteLine($"{monster.Name}은(는) {damage}만큼의 피해를 받았다!");
                    monster.Hp -= damage;
                    break;
                }
            }
        }
        public void PlayerItem(MonsterStat monster, PlayerStat player, TotalIm total)
        {
            while (true)
            {
                List<ItemDes> ski = total.SeeInventory(true);
                if (ski == null)
                {
                    continue;
                }
                else
                {
                    AllStat(monster, player);
                    Console.WriteLine($"플레이어는 {ski[0].Name}을 사용하였다!");
                    if (ski[0].Type == "포션")
                    {
                        if (ski[0].SType == "체력회복")
                        {
                            if(player.TotalHp <= ski[0].Value)
                            {
                                player.NowHp = player.TotalHp;
                            }
                            else
                            {
                                player.NowHp += ski[0].Value;
                            }
                            Console.WriteLine($"플레이어는 {ski[0].Value}만큼의 체력을 회복하였다!");
                            break;
                        }
                        else if (ski[0].SType == "마나회복")
                        {
                            if (player.TotalMp <= ski[0].Value)
                            {
                                player.NowMp = player.TotalMp;
                            }
                            else
                            {
                                player.NowMp += ski[0].Value;
                            }
                            Console.WriteLine($"플레이어는 {ski[0].Value}만큼의 마나를 회복하였다!");
                            break;
                        }
                    }
                    else if (ski[0].Type == "스크롤")
                    {
                        if (ski[0].SType == "공격마법")
                        {
                            int damage = ski[0].Value - monster.Def;
                            Console.WriteLine($"{monster.Name}은(는) {damage}만큼의 피해를 받았다!");
                            monster.Hp -= damage;
                            break;
                        }
                    }

                        break;
                }
            }
        }
        public void MonsterAttack(MonsterStat monster, PlayerStat player)
        {

        }
        public void WinOrDefeat(MonsterStat monster, PlayerStat player, ref bool dj)
        {
            if (monster.Hp <= 0)
            {
                monster.Hp = 0;             
                dj = true;
            }
            else if (player.NowHp <= 0)
            {
                player.NowHp = 0;
                dj = true;
            }
        }
    }
}
