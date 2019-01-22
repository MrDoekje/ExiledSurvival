using System.Collections;
using System.Collections.Generic;
using UnityEngine;

class Job
{
    private string jobTitle;
            
    public Job(string jobToDo)
    {
        jobTitle = jobToDo;
    }

    public string getJobTitle => jobTitle;
}

