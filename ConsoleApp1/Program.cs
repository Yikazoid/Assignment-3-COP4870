using Program.Library.Models;
using System;
using System.Security.Cryptography.X509Certificates;
using System.Xml.Serialization;

namespace Program.CLI
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Client> clientList = new List<Client>();
            List<Project> projectList = new List<Project>();

            while (true)
            {
                Console.WriteLine("C. ClientMenu");
                Console.WriteLine("P. ProjectMenu");
                Console.WriteLine("E. Exit Program\n");

                var mInput = Console.ReadLine() ?? "N";
                if (mInput.Equals("C", StringComparison.InvariantCultureIgnoreCase))
                {
                    ClientMenu(clientList);
                }
                else if (mInput.Equals("P", StringComparison.InvariantCultureIgnoreCase))
                {
                    ProjectMenu(projectList, clientList);
                }
                else if (mInput.Equals("E", StringComparison.InvariantCultureIgnoreCase))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("\n[Invalid Command]");
                }
            }
        }

        static void ClientMenu(List<Client> clientList)
        {
            while (true)
            {
                Console.WriteLine("\nC. Create a Client");
                Console.WriteLine("R. List a Client");
                Console.WriteLine("U. Update a Client");
                Console.WriteLine("D. Delete a Client");
                Console.WriteLine("E. Exit Menu\n");

                var input = Console.ReadLine() ?? string.Empty;

                if (input.Equals("C", StringComparison.InvariantCultureIgnoreCase))
                {
                    Console.WriteLine("Id: ");
                    var id = int.Parse(Console.ReadLine() ?? "0");

                    Console.WriteLine("\nOpen Date (m/d/0000): ");
                    var open = DateTime.Parse(Console.ReadLine() ?? DateTime.Today.ToString());

                    Console.WriteLine("\nClose Date (m/d/0000): ");
                    var close = DateTime.Parse(Console.ReadLine() ?? DateTime.Today.ToString());

                    Console.WriteLine("\nIs Active (true/false): ");
                    var active = bool.Parse(Console.ReadLine() ?? "false");

                    Console.WriteLine("\nName: ");
                    var name = Console.ReadLine() ?? "NoName";

                    Console.WriteLine("\nNotes: ");
                    var note = Console.ReadLine() ?? "NoNotes";


                    clientList.Add(new Client
                    {
                        Id = id,
                        OpenDate = open,
                        ClosedDate = close,
                        IsActive = active,
                        Name = name,
                        Notes = note
                    }
                    );


                }
                else if (input.Equals("R", StringComparison.InvariantCultureIgnoreCase))
                {
                    clientList.ForEach(Console.WriteLine);
                }
                else if (input.Equals("U", StringComparison.InvariantCultureIgnoreCase))
                {
                    Console.WriteLine("\nChoose ID of Client to update");
                    clientList.ForEach(Console.WriteLine);
                    var upInput = int.Parse(Console.ReadLine() ?? "0");

                    var upClient = clientList.FirstOrDefault(c => c.Id == upInput);
                    if (upClient != null)
                    {
                        Console.WriteLine("\nUpdated Open Date");
                        upClient.OpenDate = DateTime.Parse(Console.ReadLine() ?? DateTime.Today.ToString());

                        Console.WriteLine("\nUpdated Close Date");
                        upClient.ClosedDate = DateTime.Parse(Console.ReadLine() ?? DateTime.Today.ToString());

                        Console.WriteLine("\nUpdated Active State (true/false)");
                        upClient.IsActive = bool.Parse(Console.ReadLine() ?? "false");

                        Console.WriteLine("\nUpdated Name");
                        upClient.Name = Console.ReadLine() ?? "NoName";

                        Console.WriteLine("\nUpdated Notes");
                        upClient.Notes = Console.ReadLine() ?? "NoNotes";
                    }
                }
                else if (input.Equals("D", StringComparison.InvariantCultureIgnoreCase))
                {
                    Console.WriteLine("\nChoose ID of Client to remove");
                    clientList.ForEach(Console.WriteLine);
                    var delInput = int.Parse(Console.ReadLine() ?? "0");

                    var remClient = clientList.FirstOrDefault(c => c.Id == delInput);
                    if (remClient != null)
                    {
                        clientList.Remove(remClient);
                    }
                }
                else if (input.Equals("E", StringComparison.InvariantCultureIgnoreCase))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("\n[Invalid Command]\n");
                }
            }
        }

        static void ProjectMenu(List<Project> projectList, List<Client> clientList)
        {
            while (true)
            {
                Console.WriteLine("\nC. Create a Project");
                Console.WriteLine("R. List a Project");
                Console.WriteLine("U. Update a Project");
                Console.WriteLine("D. Delete a Project");
                Console.WriteLine("E. Exit Menu\n");

                var input = Console.ReadLine() ?? string.Empty;

                if (input.Equals("C", StringComparison.InvariantCultureIgnoreCase))
                {
                    Console.WriteLine("Id: ");
                    var id = int.Parse(Console.ReadLine() ?? "0");

                    Console.WriteLine("\nOpen Date (m/d/0000): ");
                    var open = DateTime.Parse(Console.ReadLine() ?? DateTime.Today.ToString());

                    Console.WriteLine("\nClose Date (m/d/0000): ");
                    var close = DateTime.Parse(Console.ReadLine() ?? DateTime.Today.ToString());

                    Console.WriteLine("\nShortName: ");
                    var sName = Console.ReadLine() ?? "NoName";

                    Console.WriteLine("\nLongName: ");
                    var lName = Console.ReadLine() ?? "NoName";

                    Console.WriteLine("ClientId: ");
                    var clientid = int.Parse(Console.ReadLine() ?? "0");

                    var pClient = new Client();
                    for (int i = 0; i < clientList.Count; i++)
                    {
                        if (clientList[i].Id == clientid)
                        {
                            pClient.Id = clientList[i].Id;
                            pClient.OpenDate = clientList[i].OpenDate;
                            pClient.ClosedDate = clientList[i].ClosedDate;
                            pClient.IsActive = clientList[i].IsActive;
                            pClient.Name = clientList[i].Name;
                            pClient.Notes = clientList[i].Notes;

                            break;
                        }
                        else
                        {
                            pClient.Id = 0;
                            pClient.OpenDate = new DateTime(2001, 01, 01);
                            pClient.ClosedDate = new DateTime(2001, 01, 01);
                            pClient.IsActive = false;
                            pClient.Name = "NoName";
                            pClient.Notes = "NoNotes";
                        }
                    }

                    projectList.Add(new Project
                    {
                        Id = id,
                        OpenDate = open,
                        ClosedDate = close,
                        ShortName = sName,
                        LongName = lName,
                        ClientId = clientid,
                        client = pClient
                    }
                    );


                }
                else if (input.Equals("R", StringComparison.InvariantCultureIgnoreCase))
                {
                    projectList.ForEach(Console.WriteLine);
                }
                else if (input.Equals("U", StringComparison.InvariantCultureIgnoreCase))
                {
                    Console.WriteLine("\nChoose ID of Project to update");
                    projectList.ForEach(Console.WriteLine);
                    var upInput = int.Parse(Console.ReadLine() ?? "0");

                    var upProject = projectList.FirstOrDefault(c => c.Id == upInput);
                    if (upProject != null)
                    {
                        Console.WriteLine("\nUpdated Open Date");
                        upProject.OpenDate = DateTime.Parse(Console.ReadLine() ?? DateTime.Today.ToString());

                        Console.WriteLine("\nUpdated Close Date");
                        upProject.ClosedDate = DateTime.Parse(Console.ReadLine() ?? DateTime.Today.ToString());

                        Console.WriteLine("\nUpdated ShortName");
                        upProject.ShortName = Console.ReadLine() ?? "NoName";

                        Console.WriteLine("\nUpdated LongName");
                        upProject.LongName = Console.ReadLine() ?? "NoName";

                        Console.WriteLine("\nUpdated ClientId");
                        upProject.ClientId = int.Parse(Console.ReadLine() ?? "0");

                        var pClient = new Client();
                        for (int i = 0; i < clientList.Count; i++)
                        {
                            if (clientList[i].Id == upProject.ClientId)
                            {
                                pClient.Id = clientList[i].Id;
                                pClient.OpenDate = clientList[i].OpenDate;
                                pClient.ClosedDate = clientList[i].ClosedDate;
                                pClient.IsActive = clientList[i].IsActive;
                                pClient.Name = clientList[i].Name;
                                pClient.Notes = clientList[i].Notes;

                                break;
                            }
                            else
                            {
                                pClient.Id = 0;
                                pClient.OpenDate = new DateTime(2001, 01, 01);
                                pClient.ClosedDate = new DateTime(2001, 01, 01);
                                pClient.IsActive = false;
                                pClient.Name = "NoName";
                                pClient.Notes = "NoNotes";
                            }
                        }
                        upProject.client = pClient;
                    }
                }
                else if (input.Equals("D", StringComparison.InvariantCultureIgnoreCase))
                {
                    Console.WriteLine("\nChoose ID of Project to remove");
                    projectList.ForEach(Console.WriteLine);
                    var delInput = int.Parse(Console.ReadLine() ?? "0");

                    var remProject = projectList.FirstOrDefault(p => p.Id == delInput);
                    if (remProject != null)
                    {
                        projectList.Remove(remProject);
                    }
                }
                else if (input.Equals("E", StringComparison.InvariantCultureIgnoreCase))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("\n[Invalid Command]\n");
                }
            }
        }

    }
}




