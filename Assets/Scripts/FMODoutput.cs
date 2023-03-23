using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FMODoutput : MonoBehaviour
{

    public void setASIODriver()
    {
        FMOD.Studio.System studioSystem = FMODUnity.RuntimeManager.StudioSystem;
        FMOD.System coreSystem = FMODUnity.RuntimeManager.CoreSystem;
        //studioSystem.release();
        //coreSystem.close();

        int numdrivers;
        int namelen = 128;

        //FMOD.OUTPUTTYPE outputASIO = FMOD_OUTPUTTYPE_ASIO;
        coreSystem.setOutput(FMOD.OUTPUTTYPE.ASIO);

        coreSystem.getOutput(out FMOD.OUTPUTTYPE output);
        Debug.Log(output);

        coreSystem.getNumDrivers(out numdrivers);
        for (int i = 0; i < numdrivers; i++)
        {
            coreSystem.getDriverInfo(
                i,
                out string name,
                namelen,
                out System.Guid guid,
                out int systemrate,
                out FMOD.SPEAKERMODE speakermode,
                out int speakermodechannels
            );
            if (name == "Dante Via (x64)")
            {
                coreSystem.setDriver(i);
                Debug.Log(name + " !!! -> " + i);
                Debug.Log(systemrate + " " + speakermode + " " + speakermodechannels);
            }
            else
            {
                Debug.Log(name);
            }
        }

        coreSystem.getDriver(out int driver);
        Debug.Log(driver);

        //coreSystem.init(512, FMOD.INITFLAGS.NORMAL, System.IntPtr.Zero);
        //studioSystem.initialize(512, FMOD.Studio.INITFLAGS.NORMAL, FMOD.INITFLAGS.NORMAL, System.IntPtr.Zero);
    }
    
    // Start is called before the first frame update
    void Start()
    {
        //setASIODriver();
    }
}
