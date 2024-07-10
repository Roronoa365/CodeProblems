namespace CodeProblems.Services
{
    public class CrawlFolderStructureService: ICrawlFolderStructureService
    {
        //https://leetcode.com/problems/crawler-log-folder/description/
        public int MinOperations(string[] logs)
        {
            List<string> folders = new List<string>();

            foreach (string folder in logs)
            {
                if (folder == "../")
                {
                    if (folders.Count > 0)
                    {
                        folders.RemoveAt(folders.Count - 1);
                    }
                }
                else if (folder == "./")
                {

                }
                else
                {
                    folders.Add(folder);
                }
            }

            return folders.Count;
        }
    }
}
