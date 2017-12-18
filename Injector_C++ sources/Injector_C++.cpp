// Injector_C++.cpp : Defines the entry point for the console application.
//

#include "stdafx.h"
#include <windows.h>
#include <iostream>
#include <fstream>

using namespace std;
int main(int argc, char *argv[])
{
	/*
		arg0 should be == the process id,
		arg1 should be == the dll location.
	*/

	if (argc < 2) {
		printf ("-Error -- You cannot execute this EXE without supplying two arguments-");
		printf ("\nIf you are attempting to execute this program without Jolly Pop (idk why you would do that), then argument 1 should be the id of the target process, and argument 2 should be the path to the DLL to inject.");
		printf ("\nNote without Jolly Pop: if an error happens, ya aint gonna get any information about it. Just run Jolly Pop. Why are you doing this?");
		printf ("\n\nPress enter to continue.");
		std::getchar ();
		return 1;
	}

	int pID = atoi(argv[1]);
	const char* DLL = argv[2];

	HANDLE pHandle = OpenProcess (PROCESS_CREATE_THREAD | PROCESS_QUERY_INFORMATION | PROCESS_VM_OPERATION
		| PROCESS_VM_WRITE | PROCESS_VM_READ, FALSE, pID);
	if (pHandle == INVALID_HANDLE_VALUE) {
		//Not gonna close the handles since the process is closing anyway.
		return GetLastError();
	}


	LPVOID loadLibrary = (LPVOID)GetProcAddress (GetModuleHandle ("kernel32.dll"), "LoadLibraryA");
	if (loadLibrary == INVALID_HANDLE_VALUE || loadLibrary == NULL) {
		return GetLastError ();
	}



	LPVOID locationToWrite = (LPVOID)VirtualAllocEx (pHandle, NULL, strlen(DLL), MEM_RESERVE | MEM_COMMIT, PAGE_READWRITE);
	if (locationToWrite == NULL) {
		return GetLastError ();
	}



	if (!WriteProcessMemory (pHandle, locationToWrite, DLL, strlen(DLL), 0)) {
		return GetLastError ();
	}

	HANDLE remoteThread = CreateRemoteThread (pHandle, NULL, 0, (LPTHREAD_START_ROUTINE)loadLibrary, locationToWrite, 0, NULL);
	if (remoteThread == INVALID_HANDLE_VALUE) {
		return GetLastError ();
	}

    return 0; //Success
}

