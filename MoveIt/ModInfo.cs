﻿using ICities;

using System;

using ColossalFramework;
using ColossalFramework.UI;

namespace MoveIt
{
    public class ModInfo : IUserMod
    {
        public ModInfo()
        {
            try
            {
                // Creating setting file
                GameSettings.AddSettingsFile(new SettingsFile[] { new SettingsFile() { fileName = MoveItTool.settingsFileName } });
            }
            catch (Exception e)
            {
                DebugUtils.Log("Could load/create the setting file.");
                DebugUtils.LogException(e);
            }
        }

        public string Name
        {
            get { return "Move It! " + version; }
        }

        public string Description
        {
            get { return "Move things"; }
        }

        public const string version = "1.1.1";

        public void OnSettingsUI(UIHelperBase helper)
        {
            try
            {
                UIHelper group = helper.AddGroup(Name) as UIHelper;
                UIPanel panel = group.self as UIPanel;


                UICheckBox checkBox = (UICheckBox)group.AddCheckbox("Use cardinal movements", MoveItTool.useCardinalMoves.value, (b) =>
                {
                    MoveItTool.useCardinalMoves.value = b;
                });
                checkBox.tooltip = "If checked, Up will move in the North direction, Down is South, Left is West, Right is East.\n";

                group.AddSpace(10);

                panel.gameObject.AddComponent<OptionsKeymapping>();

                group.AddSpace(10);
            }
            catch (Exception e)
            {
                DebugUtils.Log("OnSettingsUI failed");
                DebugUtils.LogException(e);
            }
        }

    }
}