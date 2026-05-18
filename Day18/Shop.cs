using Day18;
using Item;
using Player;
using Total;

namespace Shop
{
    class AllShop
    {
        ItemTotal itemTotal = new ItemTotal();
        SkillTotal skillTotal = new SkillTotal();
        public void InKey() //화면 안넘어가게 잠시 붙잡아두는 메서드
        {
            Console.WriteLine("확인 할려면 아무 키나 누르기 ");
            Console.ReadKey(true);
        }
        public List<ItemDes> Market(PlayerStat player)
        {
            itemTotal.ItemArr();
            int page = 0;
            int k = 0;
            List<ItemDes> shopList = new List<ItemDes>();
            List<ItemDes> value = new List<ItemDes>();
            ItemDes valueVal = new ItemDes("", "", 0, "더미", "", 0);
            value.Add(valueVal);
            for(int i = 1; i < 400; i++)
            {
                shopList.Add(itemTotal.GetItem(i));
                if (shopList[shopList.Count - 1].Type == "더미")
                {
                    shopList.Remove(shopList[shopList.Count - 1]);
                }
                
            }
            while (true)
            {
                Console.Clear();
                Console.WriteLine("상점 물품 목록");
                Console.WriteLine("=================================================================");
                for (int i = 0 + page; i < shopList.Count;)
                {                   
                     Console.Write($"{i - page}. ");
                     Console.WriteLine($"{shopList[i].Name} \t\t\t가격 : {shopList[i].Price}");
                    i++;
                    if (i % 10 == 0)
                    {
                        break;
                    }
                }
                Console.WriteLine("=================================================================");
                Console.WriteLine("숫자를 입력하여 아이템 확인. ( ESC 입력시 이전 화면으로 )");
                Console.WriteLine("       <- 양쪽 방향키를 눌러 페이지 넘기기 ->");
                ConsoleKeyInfo key = Console.ReadKey(true);
                if (key.Key == ConsoleKey.LeftArrow)
                {
                    if (page != 0)
                    {
                        page -= 10;
                    }
                }
                else if (key.Key == ConsoleKey.RightArrow)
                {
                    page += 10;
                    if (shopList.Count < page)
                    {
                        page -= 10;
                    }
                }
                else if (key.Key == ConsoleKey.Escape)
                {
                    break;
                }
                if (char.IsDigit(key.KeyChar) == true)
                {
                    k = int.Parse(key.KeyChar.ToString()) + page;
                    if (k < shopList.Count)
                    {
                        Console.WriteLine($"이름 : {shopList[k].Name}\n가격 : {shopList[k].Price}\n아이템을 구매하시겠습니까?\n1. 구매 (아무 키나 눌러 취소하기)");
                        key = Console.ReadKey(true);
                        if (key.Key == ConsoleKey.D1)
                        {
                            if(player.Gold >= shopList[k].Price)
                            {
                                Console.WriteLine($"{shopList[k].Name}을 구매하셨습니다!");
                                player.Gold -= shopList[k].Price;
                                value.Clear();
                                value.Add(shopList[k]);
                                InKey();
                                break;
                            }
                            else
                            {
                                Console.WriteLine($"살 돈이 없습니다.");
                                InKey();
                            }
                        }
                        
                    }
                    else
                    {
                        Console.WriteLine("입력하신 번호에 아이템이 없습니다.");
                        InKey();

                    }
                }
            }
            return value;
        }
        public (List<SkillDes>, bool) Traning(PlayerStat player,TotalIm total)
        {
            skillTotal.SkillArr();
            int page = 0;
            int k = 0;
            List<SkillDes> shopList = new List<SkillDes>();
            bool value = true;
            List<SkillDes> nowSkillList = total.NowSkill();    
            List<SkillDes> check = new List<SkillDes>();
            for (int i = 1; i < 400; i++)
            {
                shopList.Add(skillTotal.GetSkill(i));
                if (shopList[shopList.Count - 1].Type == "더미")
                {
                    shopList.Remove(shopList[shopList.Count - 1]);
                }

            }
            while (true)
            {
                Console.Clear();
                Console.WriteLine("스킬 목록");
                Console.WriteLine("=================================================================");
                for (int i = 0 + page; i < shopList.Count;)
                { 
                    Console.Write($"{i - page}. ");
                    Console.WriteLine($"{shopList[i].Name} \t\t\t가격 : 1000");
                    i++;
                    if (i % 10 == 0)
                    {
                        break;
                    }
                }
                Console.WriteLine("=================================================================");
                Console.WriteLine("숫자를 입력하여 스킬 확인. ( ESC 입력시 이전 화면으로 )");
                Console.WriteLine("       <- 양쪽 방향키를 눌러 페이지 넘기기 ->");
                ConsoleKeyInfo key = Console.ReadKey(true);
                if (key.Key == ConsoleKey.LeftArrow)
                {
                    if (page != 0)
                    {
                        page -= 10;
                    }
                }
                else if (key.Key == ConsoleKey.RightArrow)
                {
                    page += 10;
                    if (shopList.Count < page)
                    {
                        page -= 10;
                    }
                }
                else if (key.Key == ConsoleKey.Escape)
                {
                    break;
                }
                if (char.IsDigit(key.KeyChar) == true)
                {
                    k = int.Parse(key.KeyChar.ToString()) + page;
                    if (k < shopList.Count)
                    {    
                        Console.WriteLine($"이름 : {shopList[k].Name}\n가격 : 1000\n스킬을 배우시겠습니까?\n1. 배우기 (아무 키나 눌러 취소하기)");
                        key = Console.ReadKey(true);
                        if (key.Key == ConsoleKey.D1)
                        {
                            if (player.Gold >= 1000)
                            {
                                value = true;
                                for (int i = 0; i < nowSkillList.Count; i++)
                                {
                                    if (shopList[k].Name == nowSkillList[i].Name)
                                    {
                                        Console.WriteLine("중복된 스킬입니다. 구매가 불가능합니다.");
                                        InKey();
                                        value = false;
                                        break;
                                    }
                                }
                                if(value == true)
                                {
                                    Console.WriteLine($"{shopList[k].Name}을 배우셨습니다!");
                                    check.Clear();
                                    check.Add(shopList[k]);
                                    player.Gold -= 1000;
                                    InKey();
                                    break;
                                }  
                            }
                            else
                            {
                                Console.WriteLine($"배울 돈이 없습니다.");
                                InKey();
                            }
                        }

                    }
                    else
                    {
                        Console.WriteLine("입력하신 번호에 스킬이 없습니다.");
                        InKey();

                    }
                }
            }

            return (check,value);
        }
    }
}
