namespace mikolo.Models.authentification;

public interface Auth
{
    public void register(Object context);
    public void login(Object context);
    public string getString();
}