using Blackguard.UI.Elements;
using Blackguard.Utilities;

namespace Blackguard.UI.Scenes;

public class MainMenuScene : Scene {
    private static readonly string[] Logo = {
        "██████╗░██╗░░░░░░█████╗░░█████╗░██╗░░██╗░██████╗░██╗░░░██╗░█████╗░██████╗░██████╗░",
        "██╔══██╗██║░░░░░██╔══██╗██╔══██╗██║░██╔╝██╔════╝░██║░░░██║██╔══██╗██╔══██╗██╔══██╗",
        "██████╦╝██║░░░░░███████║██║░░╚═╝█████═╝░██║░░██╗░██║░░░██║███████║██████╔╝██║░░██║",
        "██╔══██╗██║░░░░░██╔══██║██║░░██╗██╔═██╗░██║░░╚██╗██║░░░██║██╔══██║██╔══██╗██║░░██║",
        "██████╦╝███████╗██║░░██║╚█████╔╝██║░╚██╗╚██████╔╝╚██████╔╝██║░░██║██║░░██║██████╔╝",
        "╚═════╝░╚══════╝╚═╝░░╚═╝░╚════╝░╚═╝░░╚═╝░╚═════╝░░╚═════╝░╚═╝░░╚═╝╚═╝░░╚═╝╚═════╝░"
    };

    private bool shouldExit = false;

    public MainMenuScene() {
        UISpace topSpace = new(0, 10);
        UIText logoText = new(Logo);
        UIButton startButton = new("Start".ToLargeText(), (state) => { state.ForwardScene<PlayerSelectionScene>(); }) {
            Norm = Highlight.TextBold,
            Sel = Highlight.TextBoldSel,
            SelLastLine = Highlight.TextBoldSelUnderline,
        };
        UIButton settingsButton = new("Settings".ToLargeText(), (_) => { }) {
            Norm = Highlight.Text,
            Sel = Highlight.TextSel,
            SelLastLine = Highlight.TextSelUnderline,
        };
        UIButton creditsButton = new("Credits".ToLargeText(), (_) => { }) {
            Norm = Highlight.Text,
            Sel = Highlight.TextSel,
            SelLastLine = Highlight.TextSelUnderline,
        };
        UIButton quitButton = new("Quit".ToLargeText(), (_) => { shouldExit = true; }) {
            Norm = Highlight.TextWarning,
            Sel = Highlight.TextWarningSel,
            SelLastLine = Highlight.TextWarningSelUnderline,
        };
        UISpace bottomSpace = new(0, 10);

        container = new UIContainer(Alignment.Center | Alignment.Fill, topSpace, logoText, startButton, settingsButton, creditsButton, quitButton, bottomSpace);

        container.Select();
        container.SelectFirstSelectable();
    }

    public override bool RunTick(Game state) {
        ProcessInput(state);
        return !shouldExit;
    }

    public override void Render(Game state) {
        container.Render(state.CurrentPanel, 0, 0, state.CurrentPanel.w, state.CurrentPanel.h);
    }
}
