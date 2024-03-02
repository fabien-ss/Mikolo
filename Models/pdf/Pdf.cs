using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;

public class Pdf
{
    private String name;
    private String path;
    private String title;
    private PdfDocument _document;
    
    public void Generate()
    {
        Header();
        Content();
        Footer();
    }

    public void Header()
    {
        
    }
    public void Content(){}
    public void Footer(){}
}