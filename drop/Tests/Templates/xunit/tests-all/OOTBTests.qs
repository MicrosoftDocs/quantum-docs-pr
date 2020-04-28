// Copyright (c) Microsoft Corporation. All rights reserved. Licensed under the
// Microsoft Software License Terms for Microsoft Quantum Development Kit Libraries
// and Samples. See LICENSE in the project root for license information.
namespace tests_all {
    
    operation ClasslibOperationTest () : Unit {
        
        classlib_ootb.HelloQ();
    }
    
    
    operation BitFlipCodeOperationTest () : Unit {
        
        BitFlipCode.HelloQ();
    }
    
    
    operation ConsoleOperationTest () : Unit {
        
        console_ootb.HelloQ();
    }
    
    
    operation ClasslibOOTBTest () : Unit {
        
        classlib_ootb.HelloQ();
    }
    
    
    operation SamplesOperationTest () : Unit {
        
        Samples.HelloQ();
    }
    
    
    operation TestsOOTBAllocateQubitTest () : Unit {
        
        tests_ootb.AllocateQubit();
    }
    
    
    operation BlankSpaceOperationTest () : Unit {
        
        blank_space.HelloQ();
    }
}


