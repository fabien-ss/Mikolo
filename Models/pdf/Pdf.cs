using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;
using Syncfusion.Pdf.Tables;
using System;
using System.IO;
using Syncfusion.Drawing;
using Syncfusion.Pdf.Grid;

namespace mikolo.Models.pdf;

public class Pdf
{
    public void generate()
    {
        PdfDocument document = new PdfDocument();
        PdfPage page = document.Pages.Add();

        // Ajouter du texte statique
        PdfFont font = new PdfStandardFont(PdfFontFamily.Helvetica, 12);
        PdfGraphics graphics = page.Graphics;
        graphics.DrawString("Facture", font, PdfBrushes.Black, new PointF(10, 10));

        // Créer un tableau pour les prix
        // Dessiner le tableau sur la page
       
        // Calculer la TVA et le prix total TTC
        double tvaTaux = 0.20; // Taux de TVA à 20%
        double prixHT = 20.00; // Prix HT de l'exemple
        double montantTVA = prixHT * tvaTaux; // Montant de la TVA
        double prixTTC = prixHT + montantTVA; // Prix TTC

        // Convertir le prix total TTC en lettres
        string prixTTCEnLettre = "Vingt euros"; // Exemple simplifié

        // Ajouter les totaux et la TVA
        graphics.DrawString($"TVA: {montantTVA.ToString("C")}", font, PdfBrushes.Black, new PointF(10, 300));
        graphics.DrawString($"Prix Total TTC: {prixTTC.ToString("C")}", font, PdfBrushes.Black, new PointF(10, 320));
        graphics.DrawString($"Prix Total TTC en lettres: {prixTTCEnLettre}", font, PdfBrushes.Black,
            new PointF(10, 340));

        // Enregistrer le document dans un stream
        MemoryStream stream = new MemoryStream();
        document.Save(stream);
        document.Close(true);

        // Renvoyer le PDF généré
        stream.Position = 0;
        stream.Dispose();
        //File(stream, "application/pdf", "Facture.pdf");
    }
}