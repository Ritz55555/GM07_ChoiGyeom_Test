using Battle;
using Day18;
using Item;
using Monster;
using Player;
using Shop;
using System.Numerics;
namespace Total
{
    class TotalIm//총괄 클래스
    {
        ItemTotal item = new ItemTotal();
        PlayerStat playerStat = new PlayerStat();
        BattleStart battle = new BattleStart();
        SkillTotal skill = new SkillTotal();
        AllShop allShop = new AllShop();
        bool weaponEq = false;
        bool armorEq = false;
        List<SkillDes> skillList = new List<SkillDes>(); //플레이어의 스킬
        List<ItemDes> itemList = new List<ItemDes>(); //플레이어의 인벤토리
        MonsterStat slime = new Slime();
        MonsterStat goblin = new Goblin();
        MonsterStat lizard = new Lizard();
        MonsterStat orc = new Orc();
        MonsterStat oger = new Oger();
        int a = 10;
        int b = 10;
        
        public void BattleStart(MonsterStat monster)
        {
            battle.BattleNow(monster, playerStat, skillList, itemList, this);
        }
        public void ItemArrSet() //모든 아이템 불러오기
        {
            item.ItemArr();
            playerStat.TotalHp = playerStat.Hp;
            playerStat.NowHp = playerStat.TotalHp;
            playerStat.TotalMp = playerStat.Mp;
            playerStat.NowMp = playerStat.TotalMp;
            playerStat.TotalAtk = playerStat.Atk;
            playerStat.TotalMatk = playerStat.Matk;
            playerStat.TotalDef = playerStat.Def;
        }       
        public void SkillArrSet()
        {
            skill.SkillArr();
        }
        public void InvenItemAdd(int code) //인벤토리에 아이템 넣기
        {
            itemList.Add(item.GetItem(code));
            if (itemList[itemList.Count - 1].Type == "더미")
            {
                itemList.Remove(itemList[itemList.Count - 1]);
            }
        }
        public void InvenItemBuy(List<ItemDes> code) //인벤토리에 아이템 넣기
        {
            itemList.Add(item.BuyItem(code));
            if(itemList[itemList.Count - 1].Type == "더미")
            {
                itemList.Remove(itemList[itemList.Count - 1]);
            }

        }
        public void SkillAdd(int code) //인벤토리에 아이템 넣기
        {
            skillList.Add(skill.GetSkill(code));
            if (skillList[skillList.Count - 1].Type == "더미")
            {
                skillList.Remove(skillList[skillList.Count - 1]);
            }
        }
        public void SkillBuy(List<SkillDes> code) //인벤토리에 아이템 넣기
        {
            skillList.Add(skill.BuySkill(code));
            if (skillList[skillList.Count - 1].Type == "더미")
            {
                skillList.Remove(skillList[skillList.Count - 1]);
            }
        }
        public void AllStatSetting(int k) //아이템 장착/해제 감지
        {
            if (itemList[k].Type == "무기")
            {
                if (itemList[k].SType == "검")
                {
                    playerStat.SetTotalAtk(playerStat.Atk, itemList[k].Value, weaponEq);
                }
                else if (itemList[k].SType == "스태프")
                {
                    playerStat.SetTotalMAtk(playerStat.Matk, itemList[k].Value, weaponEq);
                }
            }
            if (itemList[k].Type == "갑옷")
            {
                playerStat.SetTotalDef(playerStat.Def, itemList[k].Value, armorEq);
            } 
        }
        
        public void SeeItemDes(int k) //아이템 상세정보
        {
            if (itemList[k].Type == "무기")
            {
                Console.WriteLine("=================================================================");
                Console.WriteLine($"{itemList[k].Name}\n정보 : {itemList[k].Des}\n가격 : {itemList[k].Price}\n공격력 : {itemList[k].Value}");
                Console.WriteLine("=================================================================");
            }
            else if (itemList[k].Type == "갑옷")
            {
                Console.WriteLine("=================================================================");
                Console.WriteLine($"{itemList[k].Name}\n정보 : {itemList[k].Des}\n가격 : {itemList[k].Price}\n방어력 : {itemList[k].Value}");
                Console.WriteLine("=================================================================");
            }
            else if (itemList[k].Type == "포션")
            {
                Console.WriteLine("=================================================================");
                Console.WriteLine($"{itemList[k].Name}\n정보 : {itemList[k].Des}\n가격 : {itemList[k].Price}\n효능 : {itemList[k].Value}");
                Console.WriteLine("=================================================================");
            }
            else if (itemList[k].Type == "스크롤")
            {
                Console.WriteLine("=================================================================");
                Console.WriteLine($"{itemList[k].Name}\n정보 : {itemList[k].Des}\n가격 : {itemList[k].Price}\n원소력 : {itemList[k].Value}");
                Console.WriteLine("=================================================================");
            }

        }
        public void AllStatView()
        {
            playerStat.AllStatView();
        }
        public void InKey() //화면 안넘어가게 잠시 붙잡아두는 메서드
        {
            Console.WriteLine("확인 할려면 아무 키나 누르기 ");
            Console.ReadKey(true);
        }
        public List<ItemDes> SeeInventory(bool battle) //인벤토리 확인
        {
            int page = 0;
            int k = 0;
            List<ItemDes> dlrj = new List<ItemDes> ();
            while (true)
            {
                Console.Clear();
                Console.WriteLine("플레이어의 인벤토리");
                Console.WriteLine("=================================================================");
                for (int i = 0+page; i < itemList.Count;)
                {   
                    if (itemList[i].Equ == true)
                    {
                        Console.Write($"{i - page}. ");
                        Console.WriteLine($"{itemList[i].Name} (E)");
                    }
                    else
                    {
                        Console.Write($"{i - page}. ");
                        Console.WriteLine($"{itemList[i].Name}");
                    }
                    i++;
                    if (i % 10 == 0)
                    {
                        break;
                    }
                }
                Console.WriteLine("=================================================================");
                Console.WriteLine($"현재 가지고 있는 돈 : {playerStat.Gold}");
                Console.WriteLine("숫자를 입력하여 아이템 확인. ( ESC 입력시 이전 화면으로 )");
                Console.WriteLine("       <- 양쪽 방향키를 눌러 페이지 넘기기 ->");
                ConsoleKeyInfo key = Console.ReadKey(true);
                if(key.Key == ConsoleKey.LeftArrow)
                {
                    if(page != 0)
                    {
                    page -= 10;
                    }
                }
                else if(key.Key == ConsoleKey.RightArrow)
                {
                    page += 10;
                    if (itemList.Count < page)
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
                    if (k < itemList.Count && itemList[k].Type == "무기" && itemList[k].Equ == false) // 무기 장착한 상태가 아닐시
                    {
                        Console.Clear();
                        SeeItemDes(k);
                        Console.WriteLine($"1. 장착하기, 2. 버리기  다른키를 눌러 뒤로가기");
                        key = Console.ReadKey(true);
                        if (key.Key == ConsoleKey.D1)
                        {
                            if(weaponEq == false){
                                Console.WriteLine($"{itemList[k].Name}을(를) 장착하였다!");
                                var p = itemList[k];
                                p.Equ = true;
                                itemList[k] = p;
                                weaponEq = true;
                                AllStatSetting(k);
                                a = k;
                                InKey();
                            }
                            else if(weaponEq == true)
                            {
                                Console.WriteLine("이미 다른 장비를 장착중입니다!");
                                InKey();
                            }
                        }
                        else if (key.Key == ConsoleKey.D2)
                        {
                            Console.WriteLine($"{itemList[k].Name}을(를) 진짜로 버리시겠습니까?");
                            Console.WriteLine($"1. 진짜 버리기  2. 취소하기");
                            key = Console.ReadKey(true);
                            if (key.Key == ConsoleKey.D1)
                            {
                                Console.WriteLine($"{itemList[k].Name}을(를) 버렸다!");
                                var p = itemList[k];
                                p.Equ = false;
                                itemList[k] = p;
                                weaponEq = false;
                                AllStatSetting(k);
                                itemList.Remove(itemList[k]);
                                a = -1;
                                InKey();
                            }
                            else if (key.Key == ConsoleKey.D2)
                            {
                                Console.WriteLine($"{itemList[k].Name}을(를) 버리는걸 취소하셨습니다.");
                                InKey();
                            }
                        }
                    }
                    else if (k < itemList.Count && itemList[k].Type == "무기" && itemList[k].Equ == true) // 무기를 장착한 상태일시
                    {
                        Console.Clear();
                        SeeItemDes(k);
                        Console.WriteLine($"1. 장착 해제하기, 2. 버리기  다른키를 눌러 뒤로가기");
                        key = Console.ReadKey(true);
                        if (key.Key == ConsoleKey.D1)
                        {
                            Console.WriteLine($"{itemList[k].Name}을(를) 장착 해제하였다!");
                            var p = itemList[k];
                            p.Equ = false;
                            itemList[k] = p;
                            weaponEq = false;
                            AllStatSetting(k);
                            a = -1;
                            InKey();
                        }
                        else if (key.Key == ConsoleKey.D2)
                        {
                            Console.WriteLine($"{itemList[k].Name}을(를) 진짜로 버리시겠습니까?");
                            Console.WriteLine($"1. 진짜 버리기  2. 취소하기");
                            key = Console.ReadKey(true);
                            if (key.Key == ConsoleKey.D1)
                            {
                                Console.WriteLine($"{itemList[k].Name}을(를) 버렸다!");
                                var p = itemList[k];
                                p.Equ = false;
                                itemList[k] = p;
                                weaponEq = false;
                                AllStatSetting(k);
                                itemList.Remove(itemList[k]);
                                a = 10;
                                InKey();
                            }
                            else if (key.Key == ConsoleKey.D2)
                            {
                                Console.WriteLine($"{itemList[k].Name}을(를) 버리는걸 취소하셨습니다.");
                                InKey();
                            }
                        }
                    }
                    else if (k < itemList.Count && itemList[k].Type == "갑옷" && itemList[k].Equ == false) //갑옷을 장착한 상태가 아닐시
                    {
                        Console.Clear();
                        SeeItemDes(k);
                        Console.WriteLine($"1. 장착하기, 2. 버리기  다른키를 눌러 뒤로가기");
                        key = Console.ReadKey(true);
                        if (key.Key == ConsoleKey.D1)
                        {
                            if (armorEq == false)
                            {
                                Console.WriteLine($"{itemList[k].Name}을(를) 장착하였다!");
                                var p = itemList[k];
                                p.Equ = true;
                                itemList[k] = p;
                                armorEq = true;
                                AllStatSetting(k);
                                b = k;
                                InKey();
                            }
                            else if (armorEq == true)
                            {
                                Console.WriteLine("이미 다른 장비를 장착중입니다!");
                                InKey();
                            }
                        }
                        else if (key.Key == ConsoleKey.D2)
                        {
                            Console.WriteLine($"{itemList[k].Name}을(를) 진짜로 버리시겠습니까?");
                            Console.WriteLine($"1. 진짜 버리기  2. 취소하기");
                            key = Console.ReadKey(true);
                            if (key.Key == ConsoleKey.D1)
                            {
                                Console.WriteLine($"{itemList[k].Name}을(를) 버렸다!");
                                var p = itemList[k];
                                p.Equ = false;
                                itemList[k] = p;
                                armorEq = false;
                                AllStatSetting(k);
                                itemList.Remove(itemList[k]);
                                b = -1;
                                InKey();
                            }
                            else if (key.Key == ConsoleKey.D2)
                            {
                                Console.WriteLine($"{itemList[k].Name}을(를) 버리는걸 취소하셨습니다.");
                                InKey();
                            }
                        }
                    }
                    else if (k < itemList.Count && itemList[k].Type == "갑옷" && itemList[k].Equ == true) //갑옷을 장착한 상태일시
                    {
                        Console.Clear();
                        SeeItemDes(k);
                        Console.WriteLine($"1. 장착 해제하기, 2. 버리기  다른키를 눌러 뒤로가기");
                        key = Console.ReadKey(true);
                        if (key.Key == ConsoleKey.D1)
                        {
                            Console.WriteLine($"{itemList[k].Name}을(를) 장착 해제하였다!");
                            var p = itemList[k];
                            p.Equ = false;
                            itemList[k] = p;
                            armorEq = false;
                            AllStatSetting(k);
                            b = -1;
                            InKey();
                        }
                        else if (key.Key == ConsoleKey.D2)
                        {
                            Console.WriteLine($"{itemList[k].Name}을(를) 진짜로 버리시겠습니까?");
                            Console.WriteLine($"1. 진짜 버리기  2. 취소하기");
                            key = Console.ReadKey(true);
                            if (key.Key == ConsoleKey.D1)
                            {
                                Console.WriteLine($"{itemList[k].Name}을(를) 버렸다!");
                                var p = itemList[k];
                                p.Equ = false;
                                itemList[k] = p;
                                armorEq = false;
                                AllStatSetting(k);
                                itemList.Remove(itemList[k]);
                                b = -1;
                                InKey();
                            }
                            else if (key.Key == ConsoleKey.D2)
                            {
                                Console.WriteLine($"{itemList[k].Name}을(를) 버리는걸 취소하셨습니다.");
                                InKey();
                            }
                        }
                    }
                    else if (k < itemList.Count && itemList[k].Type == "포션") //포션을 선택할 시
                    {
                        Console.Clear();
                        SeeItemDes(k);
                        Console.WriteLine($"1. 사용하기, 2. 버리기  다른키를 눌러 뒤로가기");
                        key = Console.ReadKey(true);
                        if (key.Key == ConsoleKey.D1)
                        {
                            if (battle == false)
                            {
                                Console.WriteLine($"전투중에만 사용 가능합니다.");
                                InKey();
                            }
                            else if (battle == true)
                            {
                                dlrj.Add(itemList[k]);
                                itemList.Remove(itemList[k]);
                            }
                            break;   
                        }
                        else if (key.Key == ConsoleKey.D2)
                        {
                            Console.WriteLine($"{itemList[k].Name}을(를) 진짜로 버리시겠습니까?");
                            Console.WriteLine($"1. 진짜 버리기  2. 취소하기");
                            key = Console.ReadKey(true);
                            if(key.Key == ConsoleKey.D1)
                            {
                                Console.WriteLine($"{itemList[k].Name}을(를) 버렸다!");
                                itemList.Remove(itemList[k]);
                                InKey();
                            }
                            else if (key.Key == ConsoleKey.D2)
                            {
                                Console.WriteLine($"{itemList[k].Name}을(를) 버리는걸 취소하셨습니다.");
                                InKey();
                            }
                        }
                    }
                    else if (k < itemList.Count && itemList[k].Type == "스크롤") //스크롤을 선택할 시
                    {
                        Console.Clear();
                        SeeItemDes(k);
                        Console.WriteLine($"1. 사용하기, 2. 버리기  다른키를 눌러 뒤로가기");
                        key = Console.ReadKey(true);
                        if (key.Key == ConsoleKey.D1)
                        {
                            if(battle == false)
                            {
                                Console.WriteLine($"전투중에만 사용 가능합니다.");
                                InKey();
                            }
                            else if(battle == true)
                            {
                                dlrj.Add(itemList[k]);
                                itemList.Remove(itemList[k]);
                            }
                            break;
                        }
                        else if (key.Key == ConsoleKey.D2)
                        {
                            Console.WriteLine($"{itemList[k].Name}을(를) 진짜로 버리시겠습니까?");
                            Console.WriteLine($"1. 진짜 버리기  2. 취소하기");
                            key = Console.ReadKey(true);
                            if (key.Key == ConsoleKey.D1)
                            {
                                Console.WriteLine($"{itemList[k].Name}을(를) 버렸다!");
                                itemList.Remove(itemList[k]);
                                InKey();
                            }
                            else if (key.Key == ConsoleKey.D2)
                            {
                                Console.WriteLine($"{itemList[k].Name}을(를) 버리는걸 취소하셨습니다.");
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
            if (dlrj.Count == 0)
            {
                return null;
            }
            else
            {

                return dlrj;
            }
        }
        public List<SkillDes> SeeSkill()
        {
            int page = 0;
            int k = 0;
            List<SkillDes> dlrj = new List<SkillDes>();
            while (true)
            {
                Console.Clear();
                Console.WriteLine("플레이어의 스킬들");
                Console.WriteLine("=================================================================");
                for (int i = 0 + page; i < skillList.Count;)
                {
                    Console.Write($"{i - page}. ");
                    Console.WriteLine($"{skillList[i].Name} 위력 : {skillList[i].Value} 필요 마나 : {skillList[i].Cost}");
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
                    if (skillList.Count < page)
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
                    if (k < skillList.Count && skillList[k].Type == "스킬")
                    {
                        if (playerStat.UseMp(skillList[k].Cost) == true)
                        {
                            dlrj.Add(skillList[k]);
                            break;
                        }
                    }
                    else if (k < skillList.Count && skillList[k].Type == "마법")
                    {
                        if (playerStat.UseMp(skillList[k].Cost))
                        {
                            dlrj.Add(skillList[k]);
                            break;
                        }
                    }
                    else
                    {
                        Console.WriteLine("입력하신 번호에 스킬이 없습니다.");
                        InKey();
                        
                    }
                }
            }
            if (dlrj.Count == 0)
            {
                return null;
            }
            else
            {
                
                return dlrj;
            }
        }
        public void playStart()
        {
            ItemArrSet();
            SkillArrSet();
            SkillAdd(1);
            
            while (true)
            {
                Console.Clear();
                for(int i = 0; i < itemList.Count; i++)
                {
                    AllStatSetting(i);
                }
                Console.WriteLine($"==================");
                Console.WriteLine($"=====메인화면=====");
                Console.WriteLine($"==================");
                Console.WriteLine($"1. 적을 찾기  2. 인벤토리 확인  3. 스킬 확인  4. 마을로 가기");
                ConsoleKeyInfo key = Console.ReadKey(true);
                if(key.Key == ConsoleKey.D1)
                {
                    Random ran = new Random();
                    Console.WriteLine("사냥터 선택하기");
                    Console.WriteLine("1. 초원  2. 숲  3. 호수  4. 동굴  5. 동굴 깊은곳");
                    key = Console.ReadKey(true);
                    if(key.Key == ConsoleKey.D1)
                    {
                        Console.WriteLine("=====초원=====");
                        Console.WriteLine("1. 적을 찾기");
                        Console.WriteLine("아무 키나 눌러 돌아가기");
                        key = Console.ReadKey(true);
                        if (key.Key == ConsoleKey.D1)
                        {
                            BattleStart(slime);
                        }
                    }
                    else if(key.Key == ConsoleKey.D2)
                    {
                        Console.WriteLine("=====숲=====");
                        Console.WriteLine("1. 적을 찾기");
                        Console.WriteLine("아무 키나 눌러 돌아가기");
                        key = Console.ReadKey(true);
                        if (key.Key == ConsoleKey.D1)
                        {
                            BattleStart(goblin);
                        }
                    }
                    else if (key.Key == ConsoleKey.D3)
                    {
                        Console.WriteLine("=====호수=====");
                        Console.WriteLine("1. 적을 찾기");
                        Console.WriteLine("아무 키나 눌러 돌아가기");
                        key = Console.ReadKey(true);
                        if (key.Key == ConsoleKey.D1)
                        {
                            BattleStart(lizard);
                        }
                    }
                    else if (key.Key == ConsoleKey.D4)
                    {
                        Console.WriteLine("=====동굴=====");
                        Console.WriteLine("1. 적을 찾기");
                        Console.WriteLine("아무 키나 눌러 돌아가기");
                        key = Console.ReadKey(true);
                        if (key.Key == ConsoleKey.D1)
                        {
                            BattleStart(orc);
                        }
                    }
                    else if (key.Key == ConsoleKey.D5)
                    {
                        Console.WriteLine("=====동굴 깊은곳=====");
                        Console.WriteLine("1. 적을 찾기");
                        Console.WriteLine("아무 키나 눌러 돌아가기");
                        key = Console.ReadKey(true);
                        if (key.Key == ConsoleKey.D1)
                        {
                            BattleStart(oger);
                        }
                    }
                }
                else if(key.Key == ConsoleKey.D2)
                {
                    SeeInventory(false);
                }
                else if (key.Key == ConsoleKey.D3)
                {
                    SeeSkill();
                }
                else if (key.Key == ConsoleKey.D4)
                {
                    while (true)
                    {
                        Console.Clear();
                        Console.WriteLine($"=====초류 마을=====");
                        Console.WriteLine($"1. 잡화상점  2. 훈련장");
                        key = Console.ReadKey(true);
                        if(key.Key == ConsoleKey.D1)
                        {
                            List<ItemDes> buy = allShop.Market(playerStat);
                            if (buy != null)
                            {
                                InvenItemBuy(buy);
                            }
                        }
                        else if(key.Key == ConsoleKey.D2)
                        {
                            List<SkillDes> buy = allShop.Traing(playerStat);
                            List<SkillDes> check = skillList;
                            bool checkCheck = true;
                            check.Add(buy[0]);
                            for(int i = 0; i < check.Count; i++)
                            {
                                if (check[i].Name == check[check.Count - 1].Name)
                                {
                                    Console.WriteLine("중복된 스킬입니다. 구매가 불가능합니다.");
                                    InKey();
                                    playerStat.Gold += 1000;
                                    checkCheck = false;
                                    break;
                                }
                            }
                            if (checkCheck == true)
                            {
                                SkillBuy(buy);
                            }
                        }
                        else if(key.Key == ConsoleKey.Escape)
                        {
                            break;
                        }
                    }
                }
            }
        }
    }
    
}
