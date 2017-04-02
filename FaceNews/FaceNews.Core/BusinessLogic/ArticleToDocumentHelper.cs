using System.Collections.Generic;


namespace FaceNews.Core.BusinessLogic
{
    static class ArticleToDocumentHelper
    {
        public static List<Document> toDocList(List<Article> articles)
        {
            var docs = new List<Document>();

            foreach (Article a in articles)
            {
                var newDoc = new Document();
                newDoc.text = a.name;
                newDoc.id = a.id;
                newDoc.language = Constants.languages;
                docs.Add(newDoc);
            }

            return docs;
        }
    }
}
