#region Using directives
using FTOptix.Core;
using FTOptix.NetLogic;
using System;
using UAManagedCore;
#endregion

public class LoginButtonLogic : BaseNetLogic {
    [ExportMethod]
    public void PerformLogin(string username, string password, out bool loginResult) {
        var usersAlias = LogicObject.GetAlias("Users");
        if (usersAlias == null || usersAlias.NodeId == NodeId.Empty) {
            Log.Error("LoginButtonLogic", "Missing Users alias");
            loginResult = false;
            return;
        }

        var user = usersAlias.Get<User>(username);
        if (user == null) {
            Log.Error("LoginButtonLogic", "Could not find user " + username);
            loginResult = false;
            return;
        }

        try {
            user.PasswordVariable.RemoteRead();
            loginResult = Session.ChangeUser(username, password);
        } catch (Exception e) {
            Log.Error("LoginButtonLogic", e.Message);
            loginResult = false;
        }
    }

}
