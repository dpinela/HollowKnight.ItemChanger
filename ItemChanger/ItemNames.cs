using System.Reflection;

namespace ItemChanger
{
    public static class ItemNames
    {
        public static string[] ToArray()
        {
            return typeof(ItemNames).GetFields(BindingFlags.Public | BindingFlags.Static)
            .Where(f => f.IsLiteral)
            .Select(f => (string)f.GetRawConstantValue())
            .ToArray();
        }

        public const string Lurien = "Lurien";
        public const string Monomon = "Monomon";
        public const string Herrah = "Herrah";
        public const string World_Sense = "World_Sense";
        public const string Dreamer = "Dreamer";
        public const string Mothwing_Cloak = "Mothwing_Cloak";
        public const string Mantis_Claw = "Mantis_Claw";
        public const string Crystal_Heart = "Crystal_Heart";
        public const string Monarch_Wings = "Monarch_Wings";
        public const string Shade_Cloak = "Shade_Cloak";
        public const string Ismas_Tear = "Isma's_Tear";
        public const string Dream_Nail = "Dream_Nail";
        public const string Dream_Gate = "Dream_Gate";
        public const string Awoken_Dream_Nail = "Awoken_Dream_Nail";
        public const string Vengeful_Spirit = "Vengeful_Spirit";
        public const string Shade_Soul = "Shade_Soul";
        public const string Desolate_Dive = "Desolate_Dive";
        public const string Descending_Dark = "Descending_Dark";
        public const string Howling_Wraiths = "Howling_Wraiths";
        public const string Abyss_Shriek = "Abyss_Shriek";
        public const string Cyclone_Slash = "Cyclone_Slash";
        public const string Dash_Slash = "Dash_Slash";
        public const string Great_Slash = "Great_Slash";
        public const string Salubras_Blessing = "Salubra's_Blessing";
        public const string Focus = "Focus";
        public const string Swim = "Swim";
        public const string Gathering_Swarm = "Gathering_Swarm";
        public const string Wayward_Compass = "Wayward_Compass";
        public const string Grubsong = "Grubsong";
        public const string Stalwart_Shell = "Stalwart_Shell";
        public const string Baldur_Shell = "Baldur_Shell";
        public const string Fury_of_the_Fallen = "Fury_of_the_Fallen";
        public const string Quick_Focus = "Quick_Focus";
        public const string Lifeblood_Heart = "Lifeblood_Heart";
        public const string Lifeblood_Core = "Lifeblood_Core";
        public const string Defenders_Crest = "Defender's_Crest";
        public const string Flukenest = "Flukenest";
        public const string Thorns_of_Agony = "Thorns_of_Agony";
        public const string Mark_of_Pride = "Mark_of_Pride";
        public const string Steady_Body = "Steady_Body";
        public const string Heavy_Blow = "Heavy_Blow";
        public const string Sharp_Shadow = "Sharp_Shadow";
        public const string Spore_Shroom = "Spore_Shroom";
        public const string Longnail = "Longnail";
        public const string Shaman_Stone = "Shaman_Stone";
        public const string Soul_Catcher = "Soul_Catcher";
        public const string Soul_Eater = "Soul_Eater";
        public const string Glowing_Womb = "Glowing_Womb";
        public const string Fragile_Heart = "Fragile_Heart";
        public const string Fragile_Heart_Repair = "Fragile_Heart_(Repair)";
        public const string Unbreakable_Heart = "Unbreakable_Heart";
        public const string Fragile_Greed = "Fragile_Greed";
        public const string Fragile_Greed_Repair = "Fragile_Greed_(Repair)";
        public const string Unbreakable_Greed = "Unbreakable_Greed";
        public const string Fragile_Strength = "Fragile_Strength";
        public const string Fragile_Strength_Repair = "Fragile_Strength_(Repair)";
        public const string Unbreakable_Strength = "Unbreakable_Strength";
        public const string Nailmasters_Glory = "Nailmaster's_Glory";
        public const string Jonis_Blessing = "Joni's_Blessing";
        public const string Shape_of_Unn = "Shape_of_Unn";
        public const string Hiveblood = "Hiveblood";
        public const string Dream_Wielder = "Dream_Wielder";
        public const string Dashmaster = "Dashmaster";
        public const string Quick_Slash = "Quick_Slash";
        public const string Spell_Twister = "Spell_Twister";
        public const string Deep_Focus = "Deep_Focus";
        public const string Grubberflys_Elegy = "Grubberfly's_Elegy";
        public const string Queen_Fragment = "Queen_Fragment";
        public const string King_Fragment = "King_Fragment";
        public const string Kingsoul = "Kingsoul";
        public const string Void_Heart = "Void_Heart";
        public const string Sprintmaster = "Sprintmaster";
        public const string Dreamshield = "Dreamshield";
        public const string Weaversong = "Weaversong";
        public const string Grimmchild1 = "Grimmchild1";
        public const string Grimmchild2 = "Grimmchild2";
        public const string City_Crest = "City_Crest";
        public const string Lumafly_Lantern = "Lumafly_Lantern";
        public const string Tram_Pass = "Tram_Pass";
        public const string Simple_Key = "Simple_Key";
        public const string Shopkeepers_Key = "Shopkeeper's_Key";
        public const string Elegant_Key = "Elegant_Key";
        public const string Love_Key = "Love_Key";
        public const string Kings_Brand = "King's_Brand";
        public const string Godtuner = "Godtuner";
        public const string Collectors_Map = "Collector's_Map";
        public const string Mask_Shard = "Mask_Shard";
        public const string Double_Mask_Shard = "Double_Mask_Shard";
        public const string Full_Mask = "Full_Mask";
        public const string Vessel_Fragment = "Vessel_Fragment";
        public const string Double_Vessel_Fragment = "Double_Vessel_Fragment";
        public const string Full_Soul_Vessel = "Full_Soul_Vessel";
        public const string Charm_Notch = "Charm_Notch";
        public const string Pale_Ore = "Pale_Ore";
        public const string Geo_Chest_False_Knight = "Geo_Chest-False_Knight";
        public const string Geo_Chest_Soul_Master = "Geo_Chest-Soul_Master";
        public const string Geo_Chest_Watcher_Knights = "Geo_Chest-Watcher_Knights";
        public const string Geo_Chest_Greenpath = "Geo_Chest-Greenpath";
        public const string Geo_Chest_Mantis_Lords = "Geo_Chest-Mantis_Lords";
        public const string Geo_Chest_Resting_Grounds = "Geo_Chest-Resting_Grounds";
        public const string Geo_Chest_Crystal_Peak = "Geo_Chest-Crystal_Peak";
        public const string Geo_Chest_Weavers_Den = "Geo_Chest-Weavers_Den";
        public const string Geo_Chest_Junk_Pit_1 = "Geo_Chest-Junk_Pit_1";
        public const string Geo_Chest_Junk_Pit_2 = "Geo_Chest-Junk_Pit_2";
        public const string Geo_Chest_Junk_Pit_3 = "Geo_Chest-Junk_Pit_3";
        public const string Geo_Chest_Junk_Pit_5 = "Geo_Chest-Junk_Pit_5";
        public const string Lumafly_Escape = "Lumafly_Escape";
        public const string One_Geo = "One_Geo";
        public const string Rancid_Egg = "Rancid_Egg";
        public const string Wanderers_Journal = "Wanderer's_Journal";
        public const string Hallownest_Seal = "Hallownest_Seal";
        public const string Kings_Idol = "King's_Idol";
        public const string Arcane_Egg = "Arcane_Egg";
        public const string Whispering_Root_Crossroads = "Whispering_Root-Crossroads";
        public const string Whispering_Root_Greenpath = "Whispering_Root-Greenpath";
        public const string Whispering_Root_Leg_Eater = "Whispering_Root-Leg_Eater";
        public const string Whispering_Root_Mantis_Village = "Whispering_Root-Mantis_Village";
        public const string Whispering_Root_Deepnest = "Whispering_Root-Deepnest";
        public const string Whispering_Root_Queens_Gardens = "Whispering_Root-Queens_Gardens";
        public const string Whispering_Root_Kingdoms_Edge = "Whispering_Root-Kingdoms_Edge";
        public const string Whispering_Root_Waterways = "Whispering_Root-Waterways";
        public const string Whispering_Root_City = "Whispering_Root-City";
        public const string Whispering_Root_Resting_Grounds = "Whispering_Root-Resting_Grounds";
        public const string Whispering_Root_Spirits_Glade = "Whispering_Root-Spirits_Glade";
        public const string Whispering_Root_Crystal_Peak = "Whispering_Root-Crystal_Peak";
        public const string Whispering_Root_Howling_Cliffs = "Whispering_Root-Howling_Cliffs";
        public const string Whispering_Root_Ancestral_Mound = "Whispering_Root-Ancestral_Mound";
        public const string Whispering_Root_Hive = "Whispering_Root-Hive";
        public const string Boss_Essence_Elder_Hu = "Boss_Essence-Elder_Hu";
        public const string Boss_Essence_Xero = "Boss_Essence-Xero";
        public const string Boss_Essence_Gorb = "Boss_Essence-Gorb";
        public const string Boss_Essence_Marmu = "Boss_Essence-Marmu";
        public const string Boss_Essence_No_Eyes = "Boss_Essence-No_Eyes";
        public const string Boss_Essence_Galien = "Boss_Essence-Galien";
        public const string Boss_Essence_Markoth = "Boss_Essence-Markoth";
        public const string Boss_Essence_Failed_Champion = "Boss_Essence-Failed_Champion";
        public const string Boss_Essence_Soul_Tyrant = "Boss_Essence-Soul_Tyrant";
        public const string Boss_Essence_Lost_Kin = "Boss_Essence-Lost_Kin";
        public const string Boss_Essence_White_Defender = "Boss_Essence-White_Defender";
        public const string Boss_Essence_Grey_Prince_Zote = "Boss_Essence-Grey_Prince_Zote";
        public const string Grub = "Grub";
        public const string Mimic_Grub = "Mimic_Grub";
        public const string Quill = "Quill";
        public const string Bench_Pin = "Bench_Pin";
        public const string Cocoon_Pin = "Cocoon_Pin";
        public const string Whispering_Root_Pin = "Whispering_Root_Pin";
        public const string Warriors_Grave_Pin = "Warrior's_Grave_Pin";
        public const string Vendor_Pin = "Vendor_Pin";
        public const string Stag_Station_Pin = "Stag_Station_Pin";
        public const string Tram_Pin = "Tram_Pin";
        public const string Hot_Spring_Pin = "Hot_Spring_Pin";
        public const string Scarab_Marker = "Scarab_Marker";
        public const string Shell_Marker = "Shell_Marker";
        public const string Token_Marker = "Token_Marker";
        public const string Gleaming_Marker = "Gleaming_Marker";
        public const string Crossroads_Map = "Crossroads_Map";
        public const string Greenpath_Map = "Greenpath_Map";
        public const string Fog_Canyon_Map = "Fog_Canyon_Map";
        public const string Fungal_Wastes_Map = "Fungal_Wastes_Map";
        public const string Deepnest_Map = "Deepnest_Map";
        public const string Ancient_Basin_Map = "Ancient_Basin_Map";
        public const string Kingdoms_Edge_Map = "Kingdom's_Edge_Map";
        public const string City_of_Tears_Map = "City_of_Tears_Map";
        public const string Royal_Waterways_Map = "Royal_Waterways_Map";
        public const string Howling_Cliffs_Map = "Howling_Cliffs_Map";
        public const string Crystal_Peak_Map = "Crystal_Peak_Map";
        public const string Queens_Gardens_Map = "Queen's_Gardens_Map";
        public const string Resting_Grounds_Map = "Resting_Grounds_Map";
        public const string Dirtmouth_Stag = "Dirtmouth_Stag";
        public const string Crossroads_Stag = "Crossroads_Stag";
        public const string Greenpath_Stag = "Greenpath_Stag";
        public const string Queens_Station_Stag = "Queen's_Station_Stag";
        public const string Queens_Gardens_Stag = "Queen's_Gardens_Stag";
        public const string City_Storerooms_Stag = "City_Storerooms_Stag";
        public const string Kings_Station_Stag = "King's_Station_Stag";
        public const string Resting_Grounds_Stag = "Resting_Grounds_Stag";
        public const string Distant_Village_Stag = "Distant_Village_Stag";
        public const string Hidden_Station_Stag = "Hidden_Station_Stag";
        public const string Stag_Nest_Stag = "Stag_Nest_Stag";
        public const string Lifeblood_Cocoon_Small = "Lifeblood_Cocoon_Small";
        public const string Lifeblood_Cocoon_Large = "Lifeblood_Cocoon_Large";
        public const string Grimmkin_Flame = "Grimmkin_Flame";
        public const string Hunters_Journal = "Hunter's_Journal";
        public const string Journal_Entry_Void_Tendrils = "Journal_Entry-Void_Tendrils";
        public const string Journal_Entry_Charged_Lumafly = "Journal_Entry-Charged_Lumafly";
        public const string Journal_Entry_Goam = "Journal_Entry-Goam";
        public const string Journal_Entry_Garpede = "Journal_Entry-Garpede";
        public const string Journal_Entry_Seal_of_Binding = "Journal_Entry-Seal_of_Binding";
        public const string Elevator_Pass = "Elevator_Pass";
        public const string Left_Mothwing_Cloak = "Left_Mothwing_Cloak";
        public const string Right_Mothwing_Cloak = "Right_Mothwing_Cloak";
        public const string Split_Shade_Cloak = "Split_Shade_Cloak";
        public const string Left_Mantis_Claw = "Left_Mantis_Claw";
        public const string Right_Mantis_Claw = "Right_Mantis_Claw";
        public const string Leftslash = "Leftslash";
        public const string Rightslash = "Rightslash";
        public const string Upslash = "Upslash";
        public const string Downslash = "Downslash";
        public const string Geo_Rock_Default = "Geo_Rock-Default";
        public const string Geo_Rock_Deepnest = "Geo_Rock-Deepnest";
        public const string Geo_Rock_Abyss = "Geo_Rock-Abyss";
        public const string Geo_Rock_GreenPath01 = "Geo_Rock-GreenPath01";
        public const string Geo_Rock_Outskirts = "Geo_Rock-Outskirts";
        public const string Geo_Rock_Outskirts420 = "Geo_Rock-Outskirts420";
        public const string Geo_Rock_GreenPath02 = "Geo_Rock-GreenPath02";
        public const string Geo_Rock_Fung01 = "Geo_Rock-Fung01";
        public const string Geo_Rock_Fung02 = "Geo_Rock-Fung02";
        public const string Geo_Rock_City = "Geo_Rock-City";
        public const string Geo_Rock_Hive = "Geo_Rock-Hive";
        public const string Geo_Rock_Mine = "Geo_Rock-Mine";
        public const string Geo_Rock_Grave02 = "Geo_Rock-Grave02";
        public const string Geo_Rock_Grave01 = "Geo_Rock-Grave01";
        public const string Boss_Geo_Massive_Moss_Charger = "Boss_Geo-Massive_Moss_Charger";
        public const string Boss_Geo_Gorgeous_Husk = "Boss_Geo-Gorgeous_Husk";
        public const string Boss_Geo_Sanctum_Soul_Warrior = "Boss_Geo-Sanctum_Soul_Warrior";
        public const string Boss_Geo_Elegant_Soul_Warrior = "Boss_Geo-Elegant_Soul_Warrior";
        public const string Boss_Geo_Crystal_Guardian = "Boss_Geo-Crystal_Guardian";
        public const string Boss_Geo_Enraged_Guardian = "Boss_Geo-Enraged_Guardian";
        public const string Boss_Geo_Gruz_Mother = "Boss_Geo-Gruz_Mother";
        public const string Boss_Geo_Vengefly_King = "Boss_Geo-Vengefly_King";
        public const string Soul_Refill = "Soul_Refill";
        public const string Soul_Totem_A = "Soul_Totem-A";
        public const string Soul_Totem_B = "Soul_Totem-B";
        public const string Soul_Totem_C = "Soul_Totem-C";
        public const string Soul_Totem_D = "Soul_Totem-D";
        public const string Soul_Totem_E = "Soul_Totem-E";
        public const string Soul_Totem_F = "Soul_Totem-F";
        public const string Soul_Totem_G = "Soul_Totem-G";
        public const string Soul_Totem_Palace = "Soul_Totem-Palace";
        public const string Soul_Totem_Path_of_Pain = "Soul_Totem-Path_of_Pain";
        public const string Lore_Tablet_City_Entrance = "Lore_Tablet-City_Entrance";
        public const string Lore_Tablet_Pleasure_House = "Lore_Tablet-Pleasure_House";
        public const string Lore_Tablet_Sanctum_Entrance = "Lore_Tablet-Sanctum_Entrance";
        public const string Lore_Tablet_Sanctum_Past_Soul_Master = "Lore_Tablet-Sanctum_Past_Soul_Master";
        public const string Lore_Tablet_Watchers_Spire = "Lore_Tablet-Watcher's_Spire";
        public const string Lore_Tablet_Archives_Upper = "Lore_Tablet-Archives_Upper";
        public const string Lore_Tablet_Archives_Left = "Lore_Tablet-Archives_Left";
        public const string Lore_Tablet_Archives_Right = "Lore_Tablet-Archives_Right";
        public const string Lore_Tablet_Pilgrims_Way_1 = "Lore_Tablet-Pilgrim's_Way_1";
        public const string Lore_Tablet_Pilgrims_Way_2 = "Lore_Tablet-Pilgrim's_Way_2";
        public const string Lore_Tablet_Mantis_Outskirts = "Lore_Tablet-Mantis_Outskirts";
        public const string Lore_Tablet_Mantis_Village = "Lore_Tablet-Mantis_Village";
        public const string Lore_Tablet_Greenpath_Upper_Hidden = "Lore_Tablet-Greenpath_Upper_Hidden";
        public const string Lore_Tablet_Greenpath_Below_Toll = "Lore_Tablet-Greenpath_Below_Toll";
        public const string Lore_Tablet_Greenpath_Lifeblood = "Lore_Tablet-Greenpath_Lifeblood";
        public const string Lore_Tablet_Greenpath_Stag = "Lore_Tablet-Greenpath_Stag";
        public const string Lore_Tablet_Greenpath_QG = "Lore_Tablet-Greenpath_QG";
        public const string Lore_Tablet_Greenpath_Lower_Hidden = "Lore_Tablet-Greenpath_Lower_Hidden";
        public const string Lore_Tablet_Dung_Defender = "Lore_Tablet-Dung_Defender";
        public const string Lore_Tablet_Spore_Shroom = "Lore_Tablet-Spore_Shroom";
        public const string Lore_Tablet_Fungal_Wastes_Hidden = "Lore_Tablet-Fungal_Wastes_Hidden";
        public const string Lore_Tablet_Fungal_Wastes_Below_Shrumal_Ogres = "Lore_Tablet-Fungal_Wastes_Below_Shrumal_Ogres";
        public const string Lore_Tablet_Fungal_Core = "Lore_Tablet-Fungal_Core";
        public const string Lore_Tablet_Ancient_Basin = "Lore_Tablet-Ancient_Basin";
        public const string Lore_Tablet_Kings_Pass_Focus = "Lore_Tablet-King's_Pass_Focus";
        public const string Lore_Tablet_Kings_Pass_Fury = "Lore_Tablet-King's_Pass_Fury";
        public const string Lore_Tablet_Kings_Pass_Exit = "Lore_Tablet-King's_Pass_Exit";
        public const string Lore_Tablet_World_Sense = "Lore_Tablet-World_Sense";
        public const string Lore_Tablet_Howling_Cliffs = "Lore_Tablet-Howling_Cliffs";
        public const string Lore_Tablet_Kingdoms_Edge = "Lore_Tablet-Kingdom's_Edge";
        public const string Lore_Tablet_Palace_Workshop = "Lore_Tablet-Palace_Workshop";
        public const string Lore_Tablet_Palace_Throne = "Lore_Tablet-Palace_Throne";
        public const string Lore_Tablet_Path_of_Pain_Entrance = "Lore_Tablet-Path_of_Pain_Entrance";
    }
}
