#region Using directives
using FTOptix.NetLogic;
using FTOptix.UI;
using UAManagedCore;
#endregion

public class UserEditorPanelLoaderLogic : BaseNetLogic {
    [ExportMethod]
    public void GoToUserDetailsPanel() {
        var userCountVariable = LogicObject.GetVariable("UserCount");
        if (userCountVariable == null)
            return;

        var noUsersPanelVariable = LogicObject.GetVariable("NoUsersPanel");
        if (noUsersPanelVariable == null)
            return;

        var userDetailPanelVariable = LogicObject.GetVariable("UserDetailPanel");
        if (userDetailPanelVariable == null)
            return;

        var panelLoader = (PanelLoader)Owner;

        NodeId newPanelNode = userCountVariable.Value > 0 ? userDetailPanelVariable.Value : noUsersPanelVariable.Value;
        NodeId userAlias = userCountVariable.Value > 0 ? Owner.Owner.Get<ListBox>("UsersList").SelectedItem : NodeId.Empty;

        panelLoader.ChangePanel(newPanelNode, userAlias);
    }
}
