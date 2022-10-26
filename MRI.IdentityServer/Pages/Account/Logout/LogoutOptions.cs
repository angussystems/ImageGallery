
using System.Runtime.CompilerServices;

namespace MRI.IdentityServer.Pages.Logout;

public class LogoutOptions
{
    public static bool ShowLogoutPrompt = true;
    // this property will autmatically redirect to the client login page after logging out from the IDP
    public static bool AutomaticRedirectAfterSignOut = true;
}