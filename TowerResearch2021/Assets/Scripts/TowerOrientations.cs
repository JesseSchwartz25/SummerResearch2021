using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerOrientations : MonoBehaviour
{
    // Start is called before the first frame update

    public float[,] blocksPos = new float[300, 2];
    public int[,] orientation = new int[300, 2];
    void Start()
    {
        blocksPos[0, 0] = 0;
        blocksPos[0, 1] = 0;

        blocksPos[1, 0] = 0;
        blocksPos[1, 1] = 0;

        blocksPos[2, 0] = 0;
        blocksPos[2, 1] = 0;

        blocksPos[3, 0] = 0;
        blocksPos[3, 1] = 0;

        blocksPos[4, 0] = 0;
        blocksPos[4, 1] = 0;

        blocksPos[5, 0] = 0;
        blocksPos[5, 1] = 0;

        blocksPos[6, 0] = -.2f;
        blocksPos[6, 1] = -.2f;

        blocksPos[7, 0] = 0;
        blocksPos[7, 1] = 0;

        blocksPos[8, 0] = .2f;
        blocksPos[8, 1] = .2f;

        blocksPos[9, 0] = -.2f;
        blocksPos[9, 1] = -.2f;

        blocksPos[10, 0] = 0;
        blocksPos[10, 1] = 0;

        blocksPos[11, 0] = .2f;
        blocksPos[11, 1] = .2f;

        //blocksPos[12, 0] =
        //blocksPos[12, 1] =

        //blocksPos[13, 0] =
        //blocksPos[13, 1] =

        //blocksPos[14, 0] =
        //blocksPos[14, 1] =

        //blocksPos[15, 0] =
        //blocksPos[15, 1] =

        //blocksPos[16, 0] =
        //blocksPos[16, 1] =

        //blocksPos[17, 0] =
        //blocksPos[17, 1] =

        //blocksPos[18, 0] =
        //blocksPos[18, 1] =

        //blocksPos[19, 0] =
        //blocksPos[19, 1] =

        //blocksPos[20, 0] =
        //blocksPos[20, 1] =

        //blocksPos[21, 0] =
        //blocksPos[21, 1] =

        //blocksPos[22, 0] =
        //blocksPos[22, 1] =

        //blocksPos[23, 0] =
        //blocksPos[23, 1] =

        //blocksPos[24, 0] =
        //blocksPos[24, 1] =

        //blocksPos[25, 0] =
        //blocksPos[25, 1] =

        //blocksPos[26, 0] =
        //blocksPos[26, 1] =

        //blocksPos[27, 0] =
        //blocksPos[27, 1] =

        //blocksPos[28, 0] =
        //blocksPos[28, 1] =

        //blocksPos[29, 0] =
        //blocksPos[29, 1] =

        //blocksPos[30, 0] =
        //blocksPos[30, 1] =

        //blocksPos[31, 0] =
        //blocksPos[31, 1] =

        //blocksPos[32, 0] =
        //blocksPos[32, 1] =

        //blocksPos[33, 0] =
        //blocksPos[33, 1] =

        //blocksPos[34, 0] =
        //blocksPos[34, 1] =

        //blocksPos[35, 0] =
        //blocksPos[35, 1] =

        //blocksPos[36, 0] =
        //blocksPos[36, 1] =

        //blocksPos[37, 0] =
        //blocksPos[37, 1] =

        //blocksPos[38, 0] =
        //blocksPos[38, 1] =

        //blocksPos[39, 0] =
        //blocksPos[39, 1] =

        //blocksPos[40, 0] =
        //blocksPos[40, 1] =

        //blocksPos[41, 0] =
        //blocksPos[41, 1] =

        //blocksPos[42, 0] =
        //blocksPos[42, 1] =

        //blocksPos[43, 0] =
        //blocksPos[43, 1] =

        //blocksPos[44, 0] =
        //blocksPos[44, 1] =

        //blocksPos[45, 0] =
        //blocksPos[45, 1] =

        //blocksPos[46, 0] =
        //blocksPos[46, 1] =

        //blocksPos[47, 0] =
        //blocksPos[47, 1] =

        //blocksPos[48, 0] =
        //blocksPos[48, 1] =

        //blocksPos[49, 0] =
        //blocksPos[49, 1] =

        //blocksPos[50, 0] =
        //blocksPos[50, 1] =

        //blocksPos[51, 0] =
        //blocksPos[51, 1] =

        //blocksPos[52, 0] =
        //blocksPos[52, 1] =

        //blocksPos[53, 0] =
        //blocksPos[53, 1] =

        //blocksPos[54, 0] =
        //blocksPos[54, 1] =

        //blocksPos[55, 0] =
        //blocksPos[55, 1] =

        //blocksPos[56, 0] =
        //blocksPos[56, 1] =

        //blocksPos[57, 0] =
        //blocksPos[57, 1] =

        //blocksPos[58, 0] =
        //blocksPos[58, 1] =

        //blocksPos[59, 0] =
        //blocksPos[59, 1] =

        //blocksPos[60, 0] =
        //blocksPos[60, 1] =

        //blocksPos[61, 0] =
        //blocksPos[61, 1] =

        //blocksPos[62, 0] =
        //blocksPos[62, 1] =

        //blocksPos[63, 0] =
        //blocksPos[63, 1] =

        //blocksPos[64, 0] =
        //blocksPos[64, 1] =

        //blocksPos[65, 0] =
        //blocksPos[65, 1] =

        //blocksPos[66, 0] =
        //blocksPos[66, 1] =

        //blocksPos[67, 0] =
        //blocksPos[67, 1] =

        //blocksPos[68, 0] =
        //blocksPos[68, 1] =

        //blocksPos[69, 0] =
        //blocksPos[69, 1] =

        //blocksPos[70, 0] =
        //blocksPos[70, 1] =

        //blocksPos[71, 0] =
        //blocksPos[71, 1] =

        //blocksPos[72, 0] =
        //blocksPos[72, 1] =

        //blocksPos[73, 0] =
        //blocksPos[73, 1] =

        //blocksPos[74, 0] =
        //blocksPos[74, 1] =

        //blocksPos[75, 0] =
        //blocksPos[75, 1] =

        //blocksPos[76, 0] =
        //blocksPos[76, 1] =

        //blocksPos[77, 0] =
        //blocksPos[77, 1] =

        //blocksPos[78, 0] =
        //blocksPos[78, 1] =

        //blocksPos[79, 0] =
        //blocksPos[79, 1] =

        //blocksPos[80, 0] =
        //blocksPos[80, 1] =

        //blocksPos[81, 0] =
        //blocksPos[81, 1] =

        //blocksPos[82, 0] =
        //blocksPos[82, 1] =

        //blocksPos[83, 0] =
        //blocksPos[83, 1] =

        //blocksPos[84, 0] =
        //blocksPos[84, 1] =

        //blocksPos[85, 0] =
        //blocksPos[85, 1] =

        //blocksPos[86, 0] =
        //blocksPos[86, 1] =

        //blocksPos[87, 0] =
        //blocksPos[87, 1] =

        //blocksPos[88, 0] =
        //blocksPos[88, 1] =

        //blocksPos[89, 0] =
        //blocksPos[89, 1] =

        //blocksPos[90, 0] =
        //blocksPos[90, 1] =

        //blocksPos[91, 0] =
        //blocksPos[91, 1] =

        //blocksPos[92, 0] =
        //blocksPos[92, 1] =

        //blocksPos[93, 0] =
        //blocksPos[93, 1] =

        //blocksPos[94, 0] =
        //blocksPos[94, 1] =

        //blocksPos[95, 0] =
        //blocksPos[95, 1] =

        //blocksPos[96, 0] =
        //blocksPos[96, 1] =

        //blocksPos[97, 0] =
        //blocksPos[97, 1] =

        //blocksPos[98, 0] =
        //blocksPos[98, 1] =

        //blocksPos[99, 0] =
        //blocksPos[99, 1] =

        //blocksPos[100, 0] =
        //blocksPos[100, 1] =

        //blocksPos[101, 0] =
        //blocksPos[101, 1] =

        //blocksPos[102, 0] =
        //blocksPos[102, 1] =

        //blocksPos[103, 0] =
        //blocksPos[103, 1] =

        //blocksPos[104, 0] =
        //blocksPos[104, 1] =

        //blocksPos[105, 0] =
        //blocksPos[105, 1] =

        //blocksPos[106, 0] =
        //blocksPos[106, 1] =

        //blocksPos[107, 0] =
        //blocksPos[107, 1] =

        //blocksPos[108, 0] =
        //blocksPos[108, 1] =

        //blocksPos[109, 0] =
        //blocksPos[109, 1] =

        //blocksPos[110, 0] =
        //blocksPos[110, 1] =

        //blocksPos[111, 0] =
        //blocksPos[111, 1] =

        //blocksPos[112, 0] =
        //blocksPos[112, 1] =

        //blocksPos[113, 0] =
        //blocksPos[113, 1] =

        //blocksPos[114, 0] =
        //blocksPos[114, 1] =

        //blocksPos[115, 0] =
        //blocksPos[115, 1] =

        //blocksPos[116, 0] =
        //blocksPos[116, 1] =

        //blocksPos[117, 0] =
        //blocksPos[117, 1] =

        //blocksPos[118, 0] =
        //blocksPos[118, 1] =

        //blocksPos[119, 0] =
        //blocksPos[119, 1] =

        //blocksPos[120, 0] =
        //blocksPos[120, 1] =

        //blocksPos[121, 0] =
        //blocksPos[121, 1] =

        //blocksPos[122, 0] =
        //blocksPos[122, 1] =

        //blocksPos[123, 0] =
        //blocksPos[123, 1] =

        //blocksPos[124, 0] =
        //blocksPos[124, 1] =

        //blocksPos[125, 0] =
        //blocksPos[125, 1] =

        //blocksPos[126, 0] =
        //blocksPos[126, 1] =

        //blocksPos[127, 0] =
        //blocksPos[127, 1] =

        //blocksPos[128, 0] =
        //blocksPos[128, 1] =

        //blocksPos[129, 0] =
        //blocksPos[129, 1] =

        //blocksPos[130, 0] =
        //blocksPos[130, 1] =

        //blocksPos[131, 0] =
        //blocksPos[131, 1] =

        //blocksPos[132, 0] =
        //blocksPos[132, 1] =

        //blocksPos[133, 0] =
        //blocksPos[133, 1] =

        //blocksPos[134, 0] =
        //blocksPos[134, 1] =

        //blocksPos[135, 0] =
        //blocksPos[135, 1] =

        //blocksPos[136, 0] =
        //blocksPos[136, 1] =

        //blocksPos[137, 0] =
        //blocksPos[137, 1] =

        //blocksPos[138, 0] =
        //blocksPos[138, 1] =

        //blocksPos[139, 0] =
        //blocksPos[139, 1] =

        //blocksPos[140, 0] =
        //blocksPos[140, 1] =

        //blocksPos[141, 0] =
        //blocksPos[141, 1] =

        //blocksPos[142, 0] =
        //blocksPos[142, 1] =

        //blocksPos[143, 0] =
        //blocksPos[143, 1] =

        //blocksPos[144, 0] =
        //blocksPos[144, 1] =

        //blocksPos[145, 0] =
        //blocksPos[145, 1] =

        //blocksPos[146, 0] =
        //blocksPos[146, 1] =

        //blocksPos[147, 0] =
        //blocksPos[147, 1] =

        //blocksPos[148, 0] =
        //blocksPos[148, 1] =

        //blocksPos[149, 0] =
        //blocksPos[149, 1] =

        //blocksPos[150, 0] =
        //blocksPos[150, 1] =

        //blocksPos[151, 0] =
        //blocksPos[151, 1] =

        //blocksPos[152, 0] =
        //blocksPos[152, 1] =

        //blocksPos[153, 0] =
        //blocksPos[153, 1] =

        //blocksPos[154, 0] =
        //blocksPos[154, 1] =

        //blocksPos[155, 0] =
        //blocksPos[155, 1] =

        //blocksPos[156, 0] =
        //blocksPos[156, 1] =

        //blocksPos[157, 0] =
        //blocksPos[157, 1] =

        //blocksPos[158, 0] =
        //blocksPos[158, 1] =

        //blocksPos[159, 0] =
        //blocksPos[159, 1] =

        //blocksPos[160, 0] =
        //blocksPos[160, 1] =

        //blocksPos[161, 0] =
        //blocksPos[161, 1] =

        //blocksPos[162, 0] =
        //blocksPos[162, 1] =

        //blocksPos[163, 0] =
        //blocksPos[163, 1] =

        //blocksPos[164, 0] =
        //blocksPos[164, 1] =

        //blocksPos[165, 0] =
        //blocksPos[165, 1] =

        //blocksPos[166, 0] =
        //blocksPos[166, 1] =

        //blocksPos[167, 0] =
        //blocksPos[167, 1] =

        //blocksPos[168, 0] =
        //blocksPos[168, 1] =

        //blocksPos[169, 0] =
        //blocksPos[169, 1] =

        //blocksPos[170, 0] =
        //blocksPos[170, 1] =

        //blocksPos[171, 0] =
        //blocksPos[171, 1] =

        //blocksPos[172, 0] =
        //blocksPos[172, 1] =

        //blocksPos[173, 0] =
        //blocksPos[173, 1] =

        //blocksPos[174, 0] =
        //blocksPos[174, 1] =

        //blocksPos[175, 0] =
        //blocksPos[175, 1] =

        //blocksPos[176, 0] =
        //blocksPos[176, 1] =

        //blocksPos[177, 0] =
        //blocksPos[177, 1] =

        //blocksPos[178, 0] =
        //blocksPos[178, 1] =

        //blocksPos[179, 0] =
        //blocksPos[179, 1] =

        //blocksPos[180, 0] =
        //blocksPos[180, 1] =

        //blocksPos[181, 0] =
        //blocksPos[181, 1] =

        //blocksPos[182, 0] =
        //blocksPos[182, 1] =

        //blocksPos[183, 0] =
        //blocksPos[183, 1] =

        //blocksPos[184, 0] =
        //blocksPos[184, 1] =

        //blocksPos[185, 0] =
        //blocksPos[185, 1] =

        //blocksPos[186, 0] =
        //blocksPos[186, 1] =

        //blocksPos[187, 0] =
        //blocksPos[187, 1] =

        //blocksPos[188, 0] =
        //blocksPos[188, 1] =

        //blocksPos[189, 0] =
        //blocksPos[189, 1] =

        //blocksPos[190, 0] =
        //blocksPos[190, 1] =

        //blocksPos[191, 0] =
        //blocksPos[191, 1] =

        //blocksPos[192, 0] =
        //blocksPos[192, 1] =

        //blocksPos[193, 0] =
        //blocksPos[193, 1] =

        //blocksPos[194, 0] =
        //blocksPos[194, 1] =

        //blocksPos[195, 0] =
        //blocksPos[195, 1] =

        //blocksPos[196, 0] =
        //blocksPos[196, 1] =

        //blocksPos[197, 0] =
        //blocksPos[197, 1] =

        //blocksPos[198, 0] =
        //blocksPos[198, 1] =

        //blocksPos[199, 0] =
        //blocksPos[199, 1] =

        //blocksPos[200, 0] =
        //blocksPos[200, 1] =

        //blocksPos[201, 0] =
        //blocksPos[201, 1] =

        //blocksPos[202, 0] =
        //blocksPos[202, 1] =

        //blocksPos[203, 0] =
        //blocksPos[203, 1] =

        //blocksPos[204, 0] =
        //blocksPos[204, 1] =

        //blocksPos[205, 0] =
        //blocksPos[205, 1] =

        //blocksPos[206, 0] =
        //blocksPos[206, 1] =

        //blocksPos[207, 0] =
        //blocksPos[207, 1] =

        //blocksPos[208, 0] =
        //blocksPos[208, 1] =

        //blocksPos[209, 0] =
        //blocksPos[209, 1] =

        //blocksPos[210, 0] =
        //blocksPos[210, 1] =

        //blocksPos[211, 0] =
        //blocksPos[211, 1] =

        //blocksPos[212, 0] =
        //blocksPos[212, 1] =

        //blocksPos[213, 0] =
        //blocksPos[213, 1] =

        //blocksPos[214, 0] =
        //blocksPos[214, 1] =

        //blocksPos[215, 0] =
        //blocksPos[215, 1] =

        //blocksPos[216, 0] =
        //blocksPos[216, 1] =

        //blocksPos[217, 0] =
        //blocksPos[217, 1] =

        //blocksPos[218, 0] =
        //blocksPos[218, 1] =

        //blocksPos[219, 0] =
        //blocksPos[219, 1] =

        //blocksPos[220, 0] =
        //blocksPos[220, 1] =

        //blocksPos[221, 0] =
        //blocksPos[221, 1] =

        //blocksPos[222, 0] =
        //blocksPos[222, 1] =

        //blocksPos[223, 0] =
        //blocksPos[223, 1] =

        //blocksPos[224, 0] =
        //blocksPos[224, 1] =

        //blocksPos[225, 0] =
        //blocksPos[225, 1] =

        //blocksPos[226, 0] =
        //blocksPos[226, 1] =

        //blocksPos[227, 0] =
        //blocksPos[227, 1] =

        //blocksPos[228, 0] =
        //blocksPos[228, 1] =

        //blocksPos[229, 0] =
        //blocksPos[229, 1] =

        //blocksPos[230, 0] =
        //blocksPos[230, 1] =

        //blocksPos[231, 0] =
        //blocksPos[231, 1] =

        //blocksPos[232, 0] =
        //blocksPos[232, 1] =

        //blocksPos[233, 0] =
        //blocksPos[233, 1] =

        //blocksPos[234, 0] =
        //blocksPos[234, 1] =

        //blocksPos[235, 0] =
        //blocksPos[235, 1] =

        //blocksPos[236, 0] =
        //blocksPos[236, 1] =

        //blocksPos[237, 0] =
        //blocksPos[237, 1] =

        //blocksPos[238, 0] =
        //blocksPos[238, 1] =

        //blocksPos[239, 0] =
        //blocksPos[239, 1] =

        //blocksPos[240, 0] =
        //blocksPos[240, 1] =

        //blocksPos[241, 0] =
        //blocksPos[241, 1] =

        //blocksPos[242, 0] =
        //blocksPos[242, 1] =

        //blocksPos[243, 0] =
        //blocksPos[243, 1] =

        //blocksPos[244, 0] =
        //blocksPos[244, 1] =

        //blocksPos[245, 0] =
        //blocksPos[245, 1] =

        //blocksPos[246, 0] =
        //blocksPos[246, 1] =

        //blocksPos[247, 0] =
        //blocksPos[247, 1] =

        //blocksPos[248, 0] =
        //blocksPos[248, 1] =

        //blocksPos[249, 0] =
        //blocksPos[249, 1] =

        //blocksPos[250, 0] =
        //blocksPos[250, 1] =

        //blocksPos[251, 0] =
        //blocksPos[251, 1] =

        //blocksPos[252, 0] =
        //blocksPos[252, 1] =

        //blocksPos[253, 0] =
        //blocksPos[253, 1] =

        //blocksPos[254, 0] =
        //blocksPos[254, 1] =

        //blocksPos[255, 0] =
        //blocksPos[255, 1] =

        //blocksPos[256, 0] =
        //blocksPos[256, 1] =

        //blocksPos[257, 0] =
        //blocksPos[257, 1] =

        //blocksPos[258, 0] =
        //blocksPos[258, 1] =

        //blocksPos[259, 0] =
        //blocksPos[259, 1] =

        //blocksPos[260, 0] =
        //blocksPos[260, 1] =

        //blocksPos[261, 0] =
        //blocksPos[261, 1] =

        //blocksPos[262, 0] =
        //blocksPos[262, 1] =

        //blocksPos[263, 0] =
        //blocksPos[263, 1] =

        //blocksPos[264, 0] =
        //blocksPos[264, 1] =

        //blocksPos[265, 0] =
        //blocksPos[265, 1] =

        //blocksPos[266, 0] =
        //blocksPos[266, 1] =

        //blocksPos[267, 0] =
        //blocksPos[267, 1] =

        //blocksPos[268, 0] =
        //blocksPos[268, 1] =

        //blocksPos[269, 0] =
        //blocksPos[269, 1] =

        //blocksPos[270, 0] =
        //blocksPos[270, 1] =

        //blocksPos[271, 0] =
        //blocksPos[271, 1] =

        //blocksPos[272, 0] =
        //blocksPos[272, 1] =

        //blocksPos[273, 0] =
        //blocksPos[273, 1] =

        //blocksPos[274, 0] =
        //blocksPos[274, 1] =

        //blocksPos[275, 0] =
        //blocksPos[275, 1] =

        //blocksPos[276, 0] =
        //blocksPos[276, 1] =

        //blocksPos[277, 0] =
        //blocksPos[277, 1] =

        //blocksPos[278, 0] =
        //blocksPos[278, 1] =

        //blocksPos[279, 0] =
        //blocksPos[279, 1] =

        //blocksPos[280, 0] =
        //blocksPos[280, 1] =

        //blocksPos[281, 0] =
        //blocksPos[281, 1] =

        //blocksPos[282, 0] =
        //blocksPos[282, 1] =

        //blocksPos[283, 0] =
        //blocksPos[283, 1] =

        //blocksPos[284, 0] =
        //blocksPos[284, 1] =

        //blocksPos[285, 0] =
        //blocksPos[285, 1] =

        //blocksPos[286, 0] =
        //blocksPos[286, 1] =

        //blocksPos[287, 0] =
        //blocksPos[287, 1] =

        //blocksPos[288, 0] =
        //blocksPos[288, 1] =

        //blocksPos[289, 0] =
        //blocksPos[289, 1] =

        //blocksPos[290, 0] =
        //blocksPos[290, 1] =

        //blocksPos[291, 0] =
        //blocksPos[291, 1] =

        //blocksPos[292, 0] =
        //blocksPos[292, 1] =

        //blocksPos[293, 0] =
        //blocksPos[293, 1] =

        //blocksPos[294, 0] =
        //blocksPos[294, 1] =

        //blocksPos[295, 0] =
        //blocksPos[295, 1] =

        //blocksPos[296, 0] =
        //blocksPos[296, 1] =

        //blocksPos[297, 0] =
        //blocksPos[297, 1] =

        //blocksPos[298, 0] =
        //blocksPos[298, 1] =

        //blocksPos[299, 0] =
        //blocksPos[299, 1] =










        orientation[225, 1] = 0;

        orientation[226, 0] = 0;
        orientation[226, 1] = 0;

        orientation[227, 0] = 0;
        orientation[227, 1] = 0;

        orientation[228, 0] = 0;
        orientation[228, 1] = 0;

        orientation[229, 0] = 0;
        orientation[229, 1] = 0;

        orientation[230, 0] = 0;
        orientation[230, 1] = 0;

        orientation[231, 0] = 0;
        orientation[231, 1] = 0;

        orientation[232, 0] = 0;
        orientation[232, 1] = 0;

        orientation[233, 0] = 0;
        orientation[233, 1] = 0;

        orientation[234, 0] = 0;
        orientation[234, 1] = 0;

        orientation[235, 0] = 0;
        orientation[235, 1] = 0;

        orientation[236, 0] = 0;
        orientation[236, 1] = 0;

        orientation[237, 0] = 0;
        orientation[237, 1] = 0;

        orientation[238, 0] = 0;
        orientation[238, 1] = 0;

        orientation[239, 0] = 0;
        orientation[239, 1] = 0;

        orientation[240, 0] = 0;
        orientation[240, 1] = 0;

        orientation[241, 0] = 0;
        orientation[241, 1] = 0;

        orientation[242, 0] = 0;
        orientation[242, 1] = 0;

        orientation[243, 0] = 0;
        orientation[243, 1] = 0;

        orientation[244, 0] = 0;
        orientation[244, 1] = 0;

        orientation[245, 0] = 0;
        orientation[245, 1] = 0;

        orientation[246, 0] = 0;
        orientation[246, 1] = 0;

        orientation[247, 0] = 0;
        orientation[247, 1] = 0;

        orientation[248, 0] = 0;
        orientation[248, 1] = 0;

        orientation[249, 0] = 0;
        orientation[249, 1] = 0;

        orientation[250, 0] = 0;
        orientation[250, 1] = 0;

        orientation[251, 0] = 0;
        orientation[251, 1] = 0;

        orientation[252, 0] = 0;
        orientation[252, 1] = 0;

        orientation[253, 0] = 0;
        orientation[253, 1] = 0;

        orientation[254, 0] = 0;
        orientation[254, 1] = 0;

        orientation[255, 0] = 0;
        orientation[255, 1] = 0;

        orientation[256, 0] = 0;
        orientation[256, 1] = 0;

        orientation[257, 0] = 0;
        orientation[257, 1] = 0;

        orientation[258, 0] = 0;
        orientation[258, 1] = 0;

        orientation[259, 0] = 0;
        orientation[259, 1] = 0;

        orientation[260, 0] = 0;
        orientation[260, 1] = 0;

        orientation[261, 0] = 0;
        orientation[261, 1] = 0;

        orientation[262, 0] = 0;
        orientation[262, 1] = 0;

        orientation[263, 0] = 0;
        orientation[263, 1] = 0;

        orientation[264, 0] = 0;
        orientation[264, 1] = 0;

        orientation[265, 0] = 0;
        orientation[265, 1] = 0;

        orientation[266, 0] = 0;
        orientation[266, 1] = 0;

        orientation[267, 0] = 0;
        orientation[267, 1] = 0;

        orientation[268, 0] = 0;
        orientation[268, 1] = 0;

        orientation[269, 0] = 0;
        orientation[269, 1] = 0;

        orientation[270, 0] = 0;
        orientation[270, 1] = 0;

        orientation[271, 0] = 0;
        orientation[271, 1] = 0;

        orientation[272, 0] = 0;
        orientation[272, 1] = 0;

        orientation[273, 0] = 0;
        orientation[273, 1] = 0;

        orientation[274, 0] = 0;
        orientation[274, 1] = 0;

        orientation[275, 0] = 0;
        orientation[275, 1] = 0;

        orientation[276, 0] = 0;
        orientation[276, 1] = 0;

        orientation[277, 0] = 0;
        orientation[277, 1] = 0;

        orientation[278, 0] = 0;
        orientation[278, 1] = 0;

        orientation[279, 0] = 0;
        orientation[279, 1] = 0;

        orientation[280, 0] = 0;
        orientation[280, 1] = 0;

        orientation[281, 0] = 0;
        orientation[281, 1] = 0;

        orientation[282, 0] = 0;
        orientation[282, 1] = 0;

        orientation[283, 0] = 0;
        orientation[283, 1] = 0;

        orientation[284, 0] = 0;
        orientation[284, 1] = 0;

        orientation[285, 0] = 0;
        orientation[285, 1] = 0;

        orientation[286, 0] = 0;
        orientation[286, 1] = 0;

        orientation[287, 0] = 0;
        orientation[287, 1] = 0;

        orientation[288, 0] = 0;
        orientation[288, 1] = 0;

        orientation[289, 0] = 0;
        orientation[289, 1] = 0;

        orientation[290, 0] = 0;
        orientation[290, 1] = 0;

        orientation[291, 0] = 0;
        orientation[291, 1] = 0;

        orientation[292, 0] = 0;
        orientation[292, 1] = 0;

        orientation[293, 0] = 0;
        orientation[293, 1] = 0;

        orientation[294, 0] = 0;
        orientation[294, 1] = 0;

        orientation[295, 0] = 0;
        orientation[295, 1] = 0;

        orientation[296, 0] = 0;
        orientation[296, 1] = 0;

        orientation[297, 0] = 0;
        orientation[297, 1] = 0;

        orientation[298, 0] = 0;
        orientation[298, 1] = 0;

        orientation[299, 0] = 0;
        orientation[299, 1] = 0;



    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
