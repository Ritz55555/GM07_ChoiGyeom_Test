using System.ComponentModel;
using System.Reflection.Metadata;
using System.Runtime.InteropServices;

namespace Item
{ 
    struct ItemDes
    {   
        public string Name { get; private set; } = null;
        public string Des { get; private set; } = null;
        public int Price { get; private set; } = 0;
        public string Type { get; private set; } = null;
        public string SType { get; private set; } = null;
        public int Value { get; private set; } = 0;
        public string EleType { get; private set; } = null;
        public bool Equ { get; set; } = false;
        public ItemDes(string name, string des, int price, string type, string sType, int value)
        {
            Name = name;
            Price = price;
            Des = des;
            Type = type;
            SType = sType;
            Value = value;
            Equ = false;
        }
        public ItemDes(string name, string des, int price, string type, string sType, int value, string eleType)
        {
            Name = name;
            Price = price;
            Des = des;
            Type = type;
            SType = sType;
            Value = value;
            EleType = eleType;
            Equ = false;
        }
    }
    class ItemTotal
    {
        SortedDictionary<int, ItemDes> itemDes = new SortedDictionary<int, ItemDes>();        
        public void ItemAdd(int code, string name,  string des, int price, string type, string sType, int value)
        {
            ItemDes item = new ItemDes(name, des, price, type, sType, value);
            itemDes.TryAdd(code, item);
        }
        public void ItemAdd(int code, string name, string des, int price, string type, string sType, int value, string eleType)
        {
            ItemDes item = new ItemDes(name, des, price, type, sType, value, eleType);
            itemDes.TryAdd(code, item);
        }

        public ItemDes GetItem(int code)
        {
            if(itemDes.TryGetValue(code, out var value)){
                
                return value;
            }
            else
            {
                ItemDes item = new ItemDes("", "", 0, "더미","", 0);
                return item;
            }
            
        }
        public ItemDes BuyItem(List<ItemDes> item)
        {
            return item[0];
        }
        
        public void ItemArr()
        {
            ItemAdd(1, "목검", "수련생들이 사용하는 나무 검, 은근히  튼튼하다.", 50, "무기","검", 2);
            ItemAdd(2, "돌검", "누군가가 만든 돌 검, 어떻게 만들었는지는 아무도 모른다.", 200, "무기","검", 5);
            ItemAdd(11, "나무 스태프", "수련생들이 사용하는 나무 스태프, 기초적인 마법을 사용할때에는 충분하다.", 50, "무기", "스태프", 2);
            ItemAdd(12, "돌 스태프", "누군가가 만든 돌 스태프, 돌로 스태프를 만들었지만 어째서인지 마법 감응력이 높다.", 200, "무기", "스태프", 5);

            ItemAdd(101, "천 갑옷", "수련생들이 사용하는 천 갑옷, 신축성이 뛰어나다.", 50, "갑옷","경장갑", 2);
            ItemAdd(102, "돌 갑옷", "누군가가 만든 돌 갑옷, 어떻게 만들었는지는 아무도 모른다.", 200, "갑옷","중장갑", 5);

            ItemAdd(201, "최하급 체력 포션", "신입 연금술사들이 처음 만드는 포션, 효과는 미약하나 없는것보다는 낮다.", 20, "포션","체력회복", 10);
            ItemAdd(202, "하급 체력 포션", "신입 연금술사들이 신입 딱지를 땔떼 만드는 포션, 효과가 눈에 보일정도로 회복이 된다.", 100, "포션","체력회복", 40);
            ItemAdd(211, "최하급 마나 포션", "최하급이지만 중급 연금술사들이 주로 만드는 포션, 근원적인 기운인 마나를 회복시켜주기 때문에 비싸다.", 500, "포션", "마나회복", 50);

            ItemAdd(301, "불붙이기 스크롤", "스크롤 제작자들이 처음 만드는 스크롤, 사용할 대상에게 붙이고 찢으면 불이 붙는다.", 50, "스크롤","공격마법", 5, "화염");
            ItemAdd(302, "파이어볼 스크롤", "가장 대중적인 마법인 파이어볼이 담겨 있는 스크롤, 그 어느때나 유용하다.", 500, "스크롤","공격마법", 30, "화염");
            Console.WriteLine("아이템 세팅 끝!");
        }
    }
    
}
