using Item;

namespace Day18
{
    struct SkillDes
    {
        public string Name { get; set; } = "";
        public string Des { get; set; } = "";
        public string Type { get; set; } = "";
        public int Value { get; set; } = 0;
        public int Cost { get; set; } = 0;

        public SkillDes(string name, string des, string type, int value, int cost)
        {
            Name = name;
            Des = des;
            Type = type;
            Value = value;
            Cost = cost;
        }
    }
    class SkillTotal
    {
        SortedDictionary<int, SkillDes> skillDes = new SortedDictionary<int, SkillDes>();
        public void SkillAdd(int code,string name, string des, string type, int value, int cost)
        {
            SkillDes skill = new SkillDes(name, des, type, value, cost);
            skillDes.TryAdd(code, skill);
        }
        public SkillDes GetSkill(int code)
        {
            if (skillDes.TryGetValue(code, out var value))
            {

                return value;
            }
            else
            {
                SkillDes skill = new SkillDes("", "", "더미", 0, 0);
                return skill;
            }

        }
        public SkillDes BuySkill(List<SkillDes> skill)
        {
            return skill[0];
        }
        public void SkillArr()
        {
            SkillAdd(1, "강한 공격", "강하게 적을 공격한다.", "스킬", 150, 5);
            SkillAdd(101, "불붙이기", "적에게 불을 붙인다.", "마법", 120, 5);
        }
    }
}
