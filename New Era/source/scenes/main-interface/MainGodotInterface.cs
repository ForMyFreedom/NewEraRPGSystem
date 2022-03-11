using Godot;
using Godot.Collections;
using System;
using System.Text;
using System.Linq;

using Entities;
using Statics;
using Statics.Enums;
using Statics.Global;
using Capacities.Interface;


namespace GodotScene
{
    public class MainGodotInterface : Control, MainInterface
    {
        [Export]
        private PackedScene playerScene;
        [Export]
        private NodePath playerNamePath;
        [Export]
        private NodePath customRollButtonPath;
        [Export]
        private NodePath characterNamePath;
        [Export]
        private NodePath bgTexturePath;
        [Export]
        private NodePath shadeColorRectPath;
        [Export]
        private NodePath upFirstColorRectPath;
        [Export]
        private NodePath upSecondColorRectPath;
        [Export]
        private NodePath downFirstColorRectPath;
        [Export]
        private NodePath downSecondColorRectPath;
        [Export]
        private NodePath lifeFactorPath;
        [Export]
        private NodePath surgeFactorPath;
        [Export]
        private NodePath agiDefenseFactorPath;
        [Export]
        private NodePath strDefenseFactorPath;
        [Export]
        private NodePath strAtributePath;
        [Export]
        private NodePath agiAtributePath;
        [Export]
        private NodePath senAtributePath;
        [Export]
        private NodePath minAtributePath;
        [Export]
        private NodePath chaAtributePath;
        [Export]
        private NodePath worksTreePath;
        [Export]
        private NodePath notificationPath;
        [Export]
        private NodePath inspirationSpinPath;
        [Export]
        private NodePath damageSpinPath;
        [Export]
        private NodePath trainingButtonPath;
        [Export]
        private NodePath triviaButtonPath;
        [Export]
        private NodePath equipamentsButtonPath;
        [Export]
        private NodePath tracesButtonPath;
        [Export]
        private NodePath getSaveButtonPath;
        [Export]
        private NodePath reloadSaveButtonPath;
        [Export]
        private NodePath techniquesTreePath;
        [Export]
        private NodePath characterInventoryPath;
        [Export]
        private NodePath triviaDataPath;
        [Export]
        private NodePath defenseBooblePath;
        [Export]
        private NodePath importSaveButtonPath;
        [Export]
        private NodePath versionSaveButtonPath;

        [Export]
        private PackedScene versionSavePackedScene;

        private Player player;
        private Color[] colors = new Color[2];
        private bool alreadyConnectAll = false;
        private bool toSaveOnClose = true;

        public override void _Ready()
        {
            playerScene = GetNode<Global>("/root/Global").GetSelectedPlayerPacked();
            player = playerScene.Instance<Player>();
            player.DoReady();
            RegistryData(player, this);
            MakeConnections();
        }

        private void MakeConnections()
        {
            if (alreadyConnectAll) return;
            ConnectAllButtons();
            SendBooblesData();
            MyStatic.CenterTheWindow();

            Connect("tree_exiting", this, "RegisterAllData");
            alreadyConnectAll = true;
        }


        private void ConnectAllButtons()
        {
            GetNode(customRollButtonPath).Connect("button_up", this, "_OnOpenRoll");
            GetNode(trainingButtonPath).Connect("button_up", this, "_OnTraining");
            GetNode(triviaButtonPath).Connect("button_up", this, "_OnTrivia");
            GetNode(equipamentsButtonPath).Connect("button_up", this, "_OnEquipaments");
            GetNode(tracesButtonPath).Connect("button_up", this, "_OnTraces");
            GetNode(getSaveButtonPath).Connect("button_activate", this, "_OnGetSave");
            GetNode(reloadSaveButtonPath).Connect("button_activate", this, "_OnReload");
            GetNode(importSaveButtonPath).Connect("button_activate", this, "_OnImportSave");
            GetNode(versionSaveButtonPath).Connect("button_activate", this, "_OnVersionSave");
        }

        private void SendBooblesData()
        {
            GetNode<DefenseBooble>(defenseBooblePath).SetDefenseStyle(GetDefenseStyle());
            GetNode<DefenseBooble>(defenseBooblePath).UpdateTexture();
        }


        private void RegistryData(CharacterDataBank sender, CharacterDataBank reciver)
        {
            reciver.SetPlayerName(sender.GetPlayerName());
            reciver.SetCharacterName(sender.GetCharacterName());

            reciver.SetBGTexture(sender.GetBGTexture());
            reciver.SetFirstColor(sender.GetFirstColor());
            reciver.SetSecondColor(sender.GetSecondColor());

            reciver.SetTotalLife(sender.GetTotalLife());
            reciver.SetActualLife(sender.GetActualLife());
            reciver.SetModLife(sender.GetModLife());

            reciver.SetTotalSurge(sender.GetTotalSurge());
            reciver.SetActualSurge(sender.GetActualSurge());
            reciver.SetModSurge(sender.GetModSurge());

            reciver.SetTotalAgiDefense(sender.GetTotalAgiDefense());
            reciver.SetActualAgiDefense(sender.GetActualAgiDefense());
            reciver.SetModAgiDefense(sender.GetModAgiDefense());

            reciver.SetTotalStrDefense(sender.GetTotalStrDefense());
            reciver.SetActualStrDefense(sender.GetActualStrDefense());
            reciver.SetModStrDefense(sender.GetModStrDefense());

            reciver.SetStrength(sender.GetStrength());
            reciver.SetAgility(sender.GetAgility());
            reciver.SetMind(sender.GetMind());
            reciver.SetSenses(sender.GetSenses());
            reciver.SetCharisma(sender.GetCharisma());

            reciver.SetModStrength(sender.GetModStrength());
            reciver.SetModAgility(sender.GetModAgility());
            reciver.SetModMind(sender.GetModMind());
            reciver.SetModSenses(sender.GetModSenses());
            reciver.SetModCharisma(sender.GetModCharisma());

            reciver.SetWorks(sender.GetWorks());
            reciver.SetNotifications(sender.GetNotifications());

            reciver.SetInspiration(sender.GetInspiration());
            reciver.SetExtraDamage(sender.GetExtraDamage());
            reciver.SetTrainingAtributes(sender.GetTrainingAtributes());
            reciver.SetTrivia(sender.GetTrivia());

            reciver.SetCriticUses(sender.GetCriticUses());
            reciver.SetTechniques(sender.GetTechniques());

            reciver.SetItens(sender.GetItens());
            reciver.SetWeaponIndex(sender.GetWeaponIndex());
            reciver.SetGuard(sender.GetGuard());
            reciver.SetDefenseStyle(sender.GetDefenseStyle());
        }

        private void RegisterAllData()
        {
            if (!toSaveOnClose) return;
            RegistryData(this, player);
            ResourceSaver.Save(player.GetCurrentSavePath(), (Resource)player);
        }




        public void _OnOpenRoll()
        {
            GetNode<GeneralButton>(customRollButtonPath).CreatePopup(this);
        }

        public void _OnTrivia()
        {
            GetNode<GeneralButton>(triviaButtonPath).CreatePopup(this);
        }

        public void _OnTraining()
        {
            GD.Print("Issue #5");
        }

        public void _OnEquipaments()
        {
            GetNode<GeneralButton>(equipamentsButtonPath).CreatePopup(this);
        }

        public void _OnTraces()
        {
            GD.Print("Issue #6");
        }

        public void _OnGetSave()
        {
            OS.ShellOpen($"{MyStatic.savePath}/{player.GetFileName()}");
        }

        public void _OnReload()
        {
            _Ready();
        }

        public void _OnImportSave()
        {
            toSaveOnClose = false;
            _OnGetSave();
        }


        public void _OnVersionSave()
        {
            toSaveOnClose = false;
            GetTree().ChangeSceneTo(versionSavePackedScene);
        }



        public Atributo GetAtributeNodeByEnum(MyEnum.Atribute atribute)
        {
            switch (atribute)
            {
                case MyEnum.Atribute.STR:
                    return GetNode<Atributo>(strAtributePath);
                case MyEnum.Atribute.AGI:
                    return GetNode<Atributo>(agiAtributePath);
                case MyEnum.Atribute.SEN:
                    return GetNode<Atributo>(senAtributePath);
                case MyEnum.Atribute.MIN:
                    return GetNode<Atributo>(minAtributePath);
                case MyEnum.Atribute.CHA:
                    return GetNode<Atributo>(chaAtributePath);
            }
            return null;
        }

        public WorkInterface GetWorkNodeByEnum(MyEnum.Work workEnum)
        {
            foreach (WorkInterface work in GetWorks())
            {
                if (work.GetEnumWork() == workEnum)
                {
                    return work;
                }
            }
            return null;
        }

        public void CreateNewNotification(String message, Texture texture = null)
        {
            GetNode<NotificationArea>(notificationPath).CreateNewNotification(message, texture);
        }


        public String GetPlayerName() { return GetNode<MyLabel>(playerNamePath).GetTextData(); }
        public void SetPlayerName(String str) { GetNode<MyLabel>(playerNamePath).SetText(str); }

        public String GetCharacterName() { return GetNode<MyLabel>(characterNamePath).GetTextData(); }
        public void SetCharacterName(String str) { GetNode<MyLabel>(characterNamePath).SetText(str); }

        public Texture GetBGTexture() { return GetNode<TextureRect>(bgTexturePath).Texture; }
        public void SetBGTexture(Texture text) { GetNode<TextureRect>(bgTexturePath).Texture = text; }

        public Color GetFirstColor() { return colors[0]; }

        public void SetFirstColor(Color color)
        {
            colors[0] = color;
            SetShadeColor(color); SetFirstColorInRect(color);
        }


        public Color GetSecondColor() { return colors[1]; }

        public void SetSecondColor(Color color)
        {
            colors[1] = color;
            SetSecondColorInRect(color);
        }




        public int GetActualLife()
        {
            return (int)GetFactorActualSpin(lifeFactorPath).Value;
        }

        public void SetActualLife(int value)
        {
            GetFactorActualSpin(lifeFactorPath).Value = value;
        }

        public void AddActualLife(int sum)
        {
            GetFactorActualSpin(lifeFactorPath).Value += sum;
        }



        public int GetTotalLife()
        {
            return (int)GetFactorTotalSpin(lifeFactorPath).Value;
        }

        public void SetTotalLife(int value)
        {
            GetFactorTotalSpin(lifeFactorPath).Value = value;
        }

        public void AddTotalLife(int sum)
        {
            GetFactorTotalSpin(lifeFactorPath).Value += sum;
        }



        public int GetModLife()
        {
            return (int)GetFactorModSpin(lifeFactorPath).Value;
        }

        public void SetModLife(int value)
        {
            SetFactorModValue(lifeFactorPath, value);
        }

        public void AddModLife(int sum)
        {
            GetFactorModSpin(lifeFactorPath).Value += sum;
        }




        public int GetActualSurge()
        {
            return (int)GetFactorActualSpin(surgeFactorPath).Value;
        }

        public void SetActualSurge(int value)
        {
            GetFactorActualSpin(surgeFactorPath).Value = value;
        }

        public void AddActualSurge(int sum)
        {
            GetFactorActualSpin(surgeFactorPath).Value += sum;
        }



        public int GetTotalSurge()
        {
            return (int)GetFactorTotalSpin(surgeFactorPath).Value;
        }

        public void SetTotalSurge(int value)
        {
            GetFactorTotalSpin(surgeFactorPath).Value = value;
        }

        public void AddTotalSurge(int sum)
        {
            GetFactorTotalSpin(surgeFactorPath).Value += sum;
        }



        public int GetModSurge()
        {
            return (int)GetFactorModSpin(surgeFactorPath).Value;
        }

        public void SetModSurge(int value)
        {
            SetFactorModValue(surgeFactorPath, value);
        }

        public void AddModSurge(int sum)
        {
            GetFactorModSpin(surgeFactorPath).Value += sum;
        }




        public int GetActualAgiDefense()
        {
            return (int)GetFactorActualSpin(agiDefenseFactorPath).Value;
        }

        public void SetActualAgiDefense(int value)
        {
            GetFactorActualSpin(agiDefenseFactorPath).Value = value;
        }

        public void AddActualAgiDefense(int sum)
        {
            GetFactorActualSpin(agiDefenseFactorPath).Value += sum;
        }



        public int GetTotalAgiDefense()
        {
            return (int)GetFactorTotalSpin(agiDefenseFactorPath).Value;
        }

        public void SetTotalAgiDefense(int value)
        {
            GetFactorTotalSpin(agiDefenseFactorPath).Value = value;
        }

        public void AddTotalAgiDefense(int sum)
        {
            GetFactorTotalSpin(agiDefenseFactorPath).Value += sum;
        }



        public int GetModAgiDefense()
        {
            return (int)GetFactorModSpin(agiDefenseFactorPath).Value;
        }

        public void SetModAgiDefense(int value)
        {
            SetFactorModValue(strDefenseFactorPath, value);
        }

        public void AddModAgiDefense(int sum)
        {
            GetFactorModSpin(agiDefenseFactorPath).Value += sum;
        }




        public int GetActualStrDefense()
        {
            return (int)GetFactorActualSpin(strDefenseFactorPath).Value;
        }

        public void SetActualStrDefense(int value)
        {
            GetFactorActualSpin(strDefenseFactorPath).Value = value;
        }

        public void AddActualStrDefense(int sum)
        {
            GetFactorActualSpin(strDefenseFactorPath).Value += sum;
        }



        public int GetTotalStrDefense()
        {
            return (int)GetFactorTotalSpin(strDefenseFactorPath).Value;
        }

        public void SetTotalStrDefense(int value)
        {
            GetFactorTotalSpin(strDefenseFactorPath).Value = value;
        }

        public void AddTotalStrDefense(int sum)
        {
            GetFactorTotalSpin(strDefenseFactorPath).Value += sum;
        }



        public int GetModStrDefense()
        {
            return (int)GetFactorModSpin(strDefenseFactorPath).Value;
        }

        public void SetModStrDefense(int value)
        {
            SetFactorModValue(strDefenseFactorPath, value);
        }

        public void AddModStrDefense(int sum)
        {
            GetFactorModSpin(strDefenseFactorPath).Value += sum;
        }





        public int GetStrength()
        {
            return GetAtributeMajor(strAtributePath);
        }

        public void SetStrength(int value)
        {
            player.SetStrength(value);
            SetAtributeMajor(strAtributePath, value);
        }

        public void AddStrength(int sum)
        {
            player.SetStrength(player.GetStrength() + sum);
            AddAtributeMajor(strAtributePath, sum);
        }



        public int GetAgility()
        {
            return GetAtributeMajor(agiAtributePath);
        }

        public void SetAgility(int value)
        {
            player.SetAgility(value);
            SetAtributeMajor(agiAtributePath, value);
        }

        public void AddAgility(int sum)
        {
            player.SetAgility(player.GetAgility() + sum);
            AddAtributeMajor(agiAtributePath, sum);
        }



        public int GetSenses()
        {
            return GetAtributeMajor(senAtributePath);
        }

        public void SetSenses(int value)
        {
            player.SetSenses(value);
            SetAtributeMajor(senAtributePath, value);
        }

        public void AddSenses(int sum)
        {
            player.SetSenses(player.GetSenses() + sum);
            AddAtributeMajor(senAtributePath, sum);
        }



        public int GetMind()
        {
            return GetAtributeMajor(minAtributePath);
        }

        public void SetMind(int value)
        {
            player.SetMind(value);
            SetAtributeMajor(minAtributePath, value);
        }

        public void AddMind(int sum)
        {
            player.SetMind(player.GetMind() + sum);
            AddAtributeMajor(minAtributePath, sum);
        }



        public int GetCharisma()
        {
            return GetAtributeMajor(chaAtributePath);
        }

        public void SetCharisma(int value)
        {
            player.SetCharisma(value);
            SetAtributeMajor(chaAtributePath, value);
        }

        public void AddCharisma(int sum)
        {
            player.SetCharisma(player.GetCharisma() + sum);
            AddAtributeMajor(chaAtributePath, sum);
        }





        public int GetModStrength()
        {
            return GetAtributeMod(strAtributePath);
        }

        public void SetModStrength(int value)
        {
            player.SetModStrength(value);
            SetAtributeMod(strAtributePath, value);
        }

        public void AddModStrength(int sum)
        {
            player.SetModStrength(player.GetModStrength() + sum);
            AddAtributeMod(strAtributePath, sum);
        }



        public int GetModAgility()
        {
            return GetAtributeMod(agiAtributePath);
        }

        public void SetModAgility(int value)
        {
            player.SetModAgility(value);
            SetAtributeMod(agiAtributePath, value);
        }

        public void AddModAgility(int sum)
        {
            player.SetModAgility(player.GetModAgility() + sum);
            AddAtributeMod(agiAtributePath, sum);
        }



        public int GetModSenses()
        {
            return GetAtributeMod(senAtributePath);
        }

        public void SetModSenses(int value)
        {
            player.SetModSenses(value);
            SetAtributeMod(senAtributePath, value);
        }

        public void AddModSenses(int sum)
        {
            player.SetModSenses(player.GetModSenses() + sum);
            AddAtributeMod(senAtributePath, sum);
        }



        public int GetModMind()
        {
            return GetAtributeMod(minAtributePath);
        }

        public void SetModMind(int value)
        {
            player.SetModMind(value);
            SetAtributeMod(minAtributePath, value);
        }

        public void AddModMind(int sum)
        {
            player.SetModMind(player.GetModMind() + sum);
            AddAtributeMod(minAtributePath, sum);
        }



        public int GetModCharisma()
        {
            return GetAtributeMod(chaAtributePath);
        }

        public void SetModCharisma(int value)
        {
            player.SetModCharisma(value);
            SetAtributeMod(chaAtributePath, value);
        }

        public void AddModCharisma(int sum)
        {
            player.SetModCharisma(player.GetModCharisma() + sum);
            AddAtributeMod(chaAtributePath, sum);
        }


        public Array<WorkInterface> GetWorks()
        {
            return GetNode<WorkTree>(worksTreePath).GetWorks();
        }

        public void SetWorks(Array<WorkInterface> _works)
        {
            GetNode<WorkTree>(worksTreePath).SetWorks(_works);
        }

        public void AddAnSkillLevel(MyEnum.Work enumWork, int skillIndex, int levelAdd)
        {
            GetWorkByEnum(enumWork).GetSkillList()[skillIndex].AddLevel(levelAdd);
        }

        public void AddAnAtributeLevel(MyEnum.Atribute enumAtribute, int levelAdd)
        {
            GetAtributeNodeByEnum(enumAtribute).SetAtributeValue(
                GetAtributeNodeByEnum(enumAtribute).GetAtributeValue() + levelAdd
            );
        }


        public int[] GetTrainingAtributes()
        {
            GD.Print("Issue #5");
            return new int[] { };
        }

        public void SetTrainingAtributes(int[] value)
        {
            GD.Print("Issue #5");
        }

        public string GetTrivia()
        {
            return GetNode<TriviaData>(triviaDataPath).GetTrivia();
        }

        public void SetTrivia(string text)
        {
            GetNode<TriviaData>(triviaDataPath).SetTrivia(text);
        }


        public int GetInspiration()
        {
            return (int)GetNode<SpinBox>(inspirationSpinPath).Value;
        }

        public void SetInspiration(int value)
        {
            GetNode<SpinBox>(inspirationSpinPath).Value = value;
        }

        public int GetExtraDamage()
        {
            return (int)GetNode<SpinBox>(damageSpinPath).Value;
        }

        public void SetExtraDamage(int value)
        {
            GetNode<SpinBox>(damageSpinPath).Value = value;
        }

        public void AddExtraDamage(int value)
        {
            GetNode<SpinBox>(damageSpinPath).Value += value;
        }

        public int GetSelectedWeaponDamage()
        {
            return GetNode<CharacterInventory>(characterInventoryPath).GetSelectedWeaponDamage();
        }



        public Godot.Collections.Array GetNotifications()
        {
            return GetNode<NotificationArea>(notificationPath).GetNotifications();
        }

        public void SetNotifications(Godot.Collections.Array notifications)
        {
            GetNode<NotificationArea>(notificationPath).SetNotifications(notifications);
        }

        public Array<Array<CriticUseInterface>> GetCriticUses()
        {
            return GetNode<WorkTree>(worksTreePath).GetCriticUses();
        }

        public Array<CriticUseInterface> GetCriticUseFromWork(MyEnum.Work we)
        {
            Array<Array<CriticUseInterface>> allUses = GetCriticUses();
            int workIndex = GetWorkIndex(we);
            if (workIndex > -1)
                return allUses[workIndex];
            else
                return null;
        }

        public void SetCriticUses(Array<Array<CriticUseInterface>> uses)
        {
            GetNode<WorkTree>(worksTreePath).SetCriticUses(uses);
        }

        public Array<TechniqueInterface> GetTechniques()
        {
            return GetNode<TechniquesTree>(techniquesTreePath).GetTechniques();
        }

        public void SetTechniques(Array<TechniqueInterface> tech)
        {
            GetNode<TechniquesTree>(techniquesTreePath).SetTechniques(tech);
        }

        public Array<InventoryItem> GetItens()
        {
            return GetNode<CharacterInventory>(characterInventoryPath).GetItens();
        }

        public void SetItens(Array<InventoryItem> itens)
        {
            GetNode<CharacterInventory>(characterInventoryPath).SetItens(itens);
        }

        public int GetWeaponIndex()
        {
            return GetNode<CharacterInventory>(characterInventoryPath).GetSelectedWeaponIndex();
        }

        public void SetWeaponIndex(int index)
        {
            GetNode<CharacterInventory>(characterInventoryPath).SetSelectedWeaponIndex(index);
        }

        public int GetGuard()
        {
            return (int)GetNode<Factor>(lifeFactorPath).GetGuardSpin().Value;
        }

        public void SetGuard(int guard)
        {
            GetNode<Factor>(lifeFactorPath).GetGuardSpin().Value = guard;
        }

        public void AddGuard(int addGuard)
        {
            GetNode<Factor>(lifeFactorPath).GetGuardSpin().Value += addGuard;
        }

        public MyEnum.DefenseStyle GetDefenseStyle()
        {
            return GetNode<DefenseBooble>(defenseBooblePath).GetDefenseStyle();
        }

        public void SetDefenseStyle(MyEnum.DefenseStyle style)
        {
            GetNode<DefenseBooble>(defenseBooblePath).SetDefenseStyle(style);
        }







        public int RequestSkillRoll(String skillName, int modValue = 0)
        {
            return GetNode<WorkTree>(worksTreePath).RequestSkillRoll(skillName, modValue);
        }

        public void RequestSkillMechanic(MyEnum.Work work, int skillIndex, int modValue = 0, int actionIndex = 0)
        {
            Skill skill = GetWorkNodeByEnum(work).GetSkillList()[skillIndex];
            skill.DoMechanic(this, actionIndex, modValue);
        }

        public int RequestWorkRoll(MyEnum.Work we, int modValue = 0)
        {
            return GetNode<WorkTree>(worksTreePath).RequestWorkRoll(we, modValue);
        }

        public int RequestWorkRollWithNotification(MyEnum.Work we, int modValue = 0)
        {
            int result = RequestWorkRoll(we, modValue);
            CreateNewNotification($"Teste de {we}: {result}");
            return result;
        }

        public int RequestAtributeRoll(MyEnum.Atribute ae, int modValue = 0)
        {
            return GetAtributeNodeByEnum(ae).RequestRoll(modValue);
        }

        public int RequestAtributeRollWithNotification(MyEnum.Atribute ae, int modValue = 0)
        {
            int result = RequestAtributeRoll(ae, modValue);
            CreateNewNotification($"Teste de {ae}: {result}");
            return result;
        }

        public void ConnectToLastNotification(Godot.Object obj, String funcName)
        {
            GetNode<NotificationArea>(notificationPath).ConnectToLastNotification(obj, funcName);
        }



        public void SetShadeColor(Color color)
        {
            GetNode<Control>(shadeColorRectPath).Modulate = color;
        }

        public void SetFirstColorInRect(Color color)
        {
            GetNode<Control>(upFirstColorRectPath).Modulate = color;
            GetNode<Control>(downFirstColorRectPath).Modulate = color;
        }

        public void SetSecondColorInRect(Color color)
        {
            GetNode<Control>(upSecondColorRectPath).Modulate = color;
            GetNode<Control>(downSecondColorRectPath).Modulate = color;
        }



        private SpinBox GetFactorActualSpin(NodePath path)
        {
            return GetNode<Factor>(path).GetActualSpin();
        }

        private SpinBox GetFactorTotalSpin(NodePath path)
        {
            return GetNode<Factor>(path).GetTotalSpin();
        }

        private SpinBox GetFactorModSpin(NodePath path)
        {
            return GetNode<Factor>(path).GetModSpin();
        }

        private void SetFactorModValue(NodePath path, int value)
        {
            GetNode<Factor>(path).GetModSpin().Value = value;
            GetNode<Factor>(path).SetActualMod(value);
        }



        private void SetAtributeMajor(NodePath path, int value)
        {
            GetNode<Atributo>(path).SetAtributeValue(value);
        }

        private void SetAtributeMod(NodePath path, int value)
        {
            GetNode<Atributo>(path).SetModValue(value);
        }

        private void AddAtributeMajor(NodePath path, int value)
        {
            SetAtributeMajor(path, value + GetAtributeMajor(path));
        }

        private void AddAtributeMod(NodePath path, int value)
        {
            SetAtributeMod(path, value + GetAtributeMod(path));
        }

        private int GetAtributeMajor(NodePath path)
        {
            return GetNode<Atributo>(path).GetAtributeValue();
        }

        private int GetAtributeMod(NodePath path)
        {
            return GetNode<Atributo>(path).GetModValue();
        }

        private WorkInterface GetWorkByEnum(MyEnum.Work we)
        {
            foreach (WorkInterface work in GetWorks())
            {
                if (work.GetEnumWork() == we)
                    return work;
            }
            return null;
        }


        private int GetWorkIndex(MyEnum.Work we)
        {
            Array<WorkInterface> works = GetWorks();
            for (int i = 0; i < works.Count; i++)
            {
                if (works[i].GetEnumWork() == we)
                    return i;
            }
            return -1;
        }



        public SkillInterface GetSkillByWorkAndName(MyEnum.Work workEnum, String name)
        {
            WorkInterface work = GetWorks().Where(w => w.GetEnumWork() == workEnum).ToArray()[0];
            return work.GetSkillList().Where(s => s.GetSkillName() == name).ToArray()[0];
        }

        public SkillInterface GetSkillByWorkAndIndex(MyEnum.Work workEnum, int index)
        {
            WorkInterface work = GetWorks().Where(w => w.GetEnumWork() == workEnum).ToArray()[0];
            return work.GetSkillList()[index];
        }

        public void UpdateInventory()
        {
            foreach (Node child in GetChildren())
            {
                if (child is InventoryPopup)
                    ((InventoryPopup)child).UpdateItensText();
            }
        }
    }
}