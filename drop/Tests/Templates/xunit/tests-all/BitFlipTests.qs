// Copyright (c) Microsoft Corporation. All rights reserved. Licensed under the
// Microsoft Software License Terms for Microsoft Quantum Development Kit Libraries
// and Samples. See LICENSE in the project root for license information.
namespace tests_all {
    
    open BitFlipCode;
    
    
    operation BitFlipSampleParityTest () : Unit {
        
        CheckBitFlipCodeStateParity();
    }
    
    
    operation BitFlipSampleWt1CorrectionTest () : Unit {
        
        CheckBitFlipCodeCorrectsBitFlipErrors();
    }
    
    
    operation BitFlipSampleWCanonTest () : Unit {
        
        CheckCanonBitFlipCodeCorrectsBitFlipErrors();
    }
    
}


