#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif


#include <cstring>
#include <string.h>
#include <stdio.h>
#include <cmath>
#include <limits>
#include <assert.h>
#include <stdint.h>

#include "il2cpp-class-internals.h"
#include "codegen/il2cpp-codegen.h"
#include "il2cpp-object-internals.h"

template <typename T1, typename T2, typename T3, typename T4>
struct VirtActionInvoker4
{
	typedef void (*Action)(void*, T1, T2, T3, T4, const RuntimeMethod*);

	static inline void Invoke (Il2CppMethodSlot slot, RuntimeObject* obj, T1 p1, T2 p2, T3 p3, T4 p4)
	{
		const VirtualInvokeData& invokeData = il2cpp_codegen_get_virtual_invoke_data(slot, obj);
		((Action)invokeData.methodPtr)(obj, p1, p2, p3, p4, invokeData.method);
	}
};
template <typename R>
struct VirtFuncInvoker0
{
	typedef R (*Func)(void*, const RuntimeMethod*);

	static inline R Invoke (Il2CppMethodSlot slot, RuntimeObject* obj)
	{
		const VirtualInvokeData& invokeData = il2cpp_codegen_get_virtual_invoke_data(slot, obj);
		return ((Func)invokeData.methodPtr)(obj, invokeData.method);
	}
};
template <typename T1, typename T2, typename T3, typename T4>
struct GenericVirtActionInvoker4
{
	typedef void (*Action)(void*, T1, T2, T3, T4, const RuntimeMethod*);

	static inline void Invoke (const RuntimeMethod* method, RuntimeObject* obj, T1 p1, T2 p2, T3 p3, T4 p4)
	{
		VirtualInvokeData invokeData;
		il2cpp_codegen_get_generic_virtual_invoke_data(method, obj, &invokeData);
		((Action)invokeData.methodPtr)(obj, p1, p2, p3, p4, invokeData.method);
	}
};
template <typename T1, typename T2, typename T3, typename T4>
struct InterfaceActionInvoker4
{
	typedef void (*Action)(void*, T1, T2, T3, T4, const RuntimeMethod*);

	static inline void Invoke (Il2CppMethodSlot slot, RuntimeClass* declaringInterface, RuntimeObject* obj, T1 p1, T2 p2, T3 p3, T4 p4)
	{
		const VirtualInvokeData& invokeData = il2cpp_codegen_get_interface_invoke_data(slot, obj, declaringInterface);
		((Action)invokeData.methodPtr)(obj, p1, p2, p3, p4, invokeData.method);
	}
};
template <typename T1, typename T2, typename T3, typename T4>
struct GenericInterfaceActionInvoker4
{
	typedef void (*Action)(void*, T1, T2, T3, T4, const RuntimeMethod*);

	static inline void Invoke (const RuntimeMethod* method, RuntimeObject* obj, T1 p1, T2 p2, T3 p3, T4 p4)
	{
		VirtualInvokeData invokeData;
		il2cpp_codegen_get_generic_interface_invoke_data(method, obj, &invokeData);
		((Action)invokeData.methodPtr)(obj, p1, p2, p3, p4, invokeData.method);
	}
};

// System.AsyncCallback
struct AsyncCallback_t3F3DA3BEDAEE81DD1D24125DF8EB30E85EE14DA4;
// System.Byte[]
struct ByteU5BU5D_tD06FDBE8142446525DF1C40351D523A228373821;
// System.Char[]
struct CharU5BU5D_t4CC6ABF0AD71BEC97E3C2F1E9C5677E46D3A75C2;
// System.Collections.Generic.List`1<System.Byte[]>
struct List_1_t8BE041DC5257EA95B6376B45901D0D957BCF7CEC;
// System.Collections.Generic.List`1<UnityEngine.CanvasGroup>
struct List_1_t64BA96BFC713F221050385E91C868CE455C245D6;
// System.Collections.Generic.List`1<UnityEngine.UI.Selectable>
struct List_1_tC6550F4D86CF67D987B6B46F46941B36D02A9680;
// System.Collections.IDictionary
struct IDictionary_t1BD5C1546718A374EA8122FBD6C6EE45331E8CE7;
// System.Collections.IEnumerator
struct IEnumerator_t8789118187258CC88B77AFAC6315B5AF87D3E18A;
// System.Delegate
struct Delegate_t;
// System.DelegateData
struct DelegateData_t1BF9F691B56DAE5F8C28C5E084FDE94F15F27BBE;
// System.Delegate[]
struct DelegateU5BU5D_tDFCDEE2A6322F96C0FE49AF47E9ADB8C4B294E86;
// System.Diagnostics.StackTrace[]
struct StackTraceU5BU5D_t855F09649EA34DEE7C1B6F088E0538E3CCC3F196;
// System.IAsyncResult
struct IAsyncResult_t8E194308510B375B42432981AE5E7488C458D598;
// System.IO.DirectoryInfo
struct DirectoryInfo_t432CD06DF148701E930708371CB985BC0E8EF87F;
// System.Int32[]
struct Int32U5BU5D_t2B9E4FDDDB9F0A00EC0AC631BA2DA915EB1ECF83;
// System.IntPtr[]
struct IntPtrU5BU5D_t4DC01DCB9A6DF6C9792A6513595D7A11E637DCDD;
// System.NotSupportedException
struct NotSupportedException_tE75B318D6590A02A5D9B29FD97409B1750FA0010;
// System.Object[]
struct ObjectU5BU5D_t3C9242B5C88A48B2A5BD9FDA6CD0024E792AF08A;
// System.Reflection.MethodInfo
struct MethodInfo_t;
// System.Runtime.Serialization.SafeSerializationManager
struct SafeSerializationManager_t4A754D86B0F784B18CBC36C073BA564BED109770;
// System.String
struct String_t;
// System.Void
struct Void_t22962CB4C05B1D89B55A6E1139F0E87A90987017;
// UnityEngine.Camera
struct Camera_t48B2B9ECB3CE6108A98BF949A1CECF0FE3421F34;
// UnityEngine.Component
struct Component_t05064EF382ABCAF4B8C94F8A350EA85184C26621;
// UnityEngine.Coroutine
struct Coroutine_tAE7DB2FC70A0AE6477F896F852057CB0754F06EC;
// UnityEngine.EventSystems.EventSystem
struct EventSystem_t06ACEF1C8D95D44D3A7F57ED4BAA577101B4EA77;
// UnityEngine.Events.InvokableCallList
struct InvokableCallList_t18AA4F473C7B295216B7D4B9723B4F3DFCCC9A3F;
// UnityEngine.Events.PersistentCallGroup
struct PersistentCallGroup_t6E5DF2EBDA42794B5FE0C6DAA97DF65F0BFF571F;
// UnityEngine.Events.UnityAction`1<System.Boolean>
struct UnityAction_1_tB994D127B02789CE2010397AEF756615E5F84FDC;
// UnityEngine.Events.UnityEvent`1<System.Boolean>
struct UnityEvent_1_t6FE5C79FD433599728A9AA732E588823AB88FDB5;
// UnityEngine.GUIText
struct GUIText_t1AAED515CF7E63F24B55C5FC988555DA14DA10F1;
// UnityEngine.GUITexture
struct GUITexture_t2A2F300B0F9D542DADB532DEC861D1711B5C46F3;
// UnityEngine.GameObject
struct GameObject_tBD1244AD56B4E59AAD76E5E7C9282EC5CE434F0F;
// UnityEngine.LineRenderer
struct LineRenderer_tD225C480F28F28A4D737866474F21001B803B7C3;
// UnityEngine.Mesh
struct Mesh_t6106B8D8E4C691321581AB0445552EC78B947B8C;
// UnityEngine.MonoBehaviour
struct MonoBehaviour_t4A60845CF505405AF8BE8C61CC07F75CADEF6429;
// UnityEngine.Networking.UnityWebRequest
struct UnityWebRequest_t9120F5A2C7D43B936B49C0B7E4CA54C822689129;
// UnityEngine.Object
struct Object_tAE11E5E46CD5C37C9F3E8950C00CD8B45666A2D0;
// UnityEngine.RectTransform
struct RectTransform_t285CBD8775B25174B75164F10618F8B9728E1B20;
// UnityEngine.Renderer
struct Renderer_t0556D67DD582620D1F495627EDE30D03284151F4;
// UnityEngine.Sprite
struct Sprite_tCA09498D612D08DE668653AF1E9C12BF53434198;
// UnityEngine.Texture2D
struct Texture2D_tBBF96AC337723E2EF156DF17E09D4379FD05DE1C;
// UnityEngine.Texture2D[]
struct Texture2DU5BU5D_tCAC03055C735C020BAFC218D55183CF03E74C1C9;
// UnityEngine.Transform
struct Transform_tBB9E78A2766C3C83599A8F66EDE7D1FCAFC66EDA;
// UnityEngine.UI.AnimationTriggers
struct AnimationTriggers_t164EF8B310E294B7D0F6BF1A87376731EBD06DC5;
// UnityEngine.UI.Graphic
struct Graphic_tBA2C3EF11D3DAEBB57F6879AB0BB4F8BD40D00D8;
// UnityEngine.UI.Selectable
struct Selectable_tAA9065030FE0468018DEC880302F95FEA9C0133A;
// UnityEngine.UI.Toggle
struct Toggle_t9ADD572046F831945ED0E48A01B50FEA1CA52106;
// UnityEngine.UI.Toggle/ToggleEvent
struct ToggleEvent_t50D925F8E220FB47DA738411CEF9C57FF7E1DC43;
// UnityEngine.UI.ToggleGroup
struct ToggleGroup_t11E2B254D3C968C7D0DA11C606CC06D7D7F0D786;
// UnityEngine.Vector2[]
struct Vector2U5BU5D_tA065A07DFC060C1B8786BBAA5F3A6577CCEB27D6;
// UnityEngine.Vector3[]
struct Vector3U5BU5D_tB9EC3346CC4A0EA5447D968E84A9AC1F6F372C28;
// UnityEngine.Vector4[]
struct Vector4U5BU5D_t51402C154FFFCF7217A9BEC4B834F0B726C10F66;
// UnityEngine.WWW
struct WWW_tA50AFB5DE276783409B4CE88FE9B772322EE5664;
// UnityEngine.WaitForEndOfFrame
struct WaitForEndOfFrame_t75980FB3F246D6AD36A85CA2BFDF8474E5EEBCCA;
// unitycoder_MobilePaint.MobilePaint
struct MobilePaint_tC25928758E48181B341DE30F410E3EA407D005E5;
// unitycoder_MobilePaint.MobilePaint/AreaWasPainted
struct AreaWasPainted_t537D2557735149202851C1AF691D54AA43D52E57;
// unitycoder_MobilePaint.OverrideTestForUI
struct OverrideTestForUI_tBE0191B652C971AB79ED3E133FEF14489D422394;
// unitycoder_MobilePaint.PaintManager
struct PaintManager_t8C7F3BD113E1D28F982A05D0397A369E09266BEE;
// unitycoder_MobilePaint.SetNewCanvasImageExample
struct SetNewCanvasImageExample_tABE5A79B521E9F4F1676A55FC042C693FB2647D7;
// unitycoder_MobilePaint.SetNewMaskImage
struct SetNewMaskImage_t27DC57C9D9F2DC004D6F077B092BC52CE8D0AE8A;
// unitycoder_MobilePaint.ToggleBrushModeUI
struct ToggleBrushModeUI_t4B6DF517F8B4743603417CD2EB16093A8DE0758B;
// unitycoder_MobilePaint.ToggleCustomPatternModeUI
struct ToggleCustomPatternModeUI_tF5121E1792E8D86FB425CACACF9513D2B6E470AA;
// unitycoder_MobilePaint.ToggleCustomShapeModeUI
struct ToggleCustomShapeModeUI_t5DABF74118B1166FDBB31E08F25358F0FC907BF2;
// unitycoder_MobilePaint.ToggleEraserModeUI
struct ToggleEraserModeUI_t12A48F99C7CA25B41997882C81CCF6274E6B09D2;
// unitycoder_MobilePaint.ToggleFloodFillModeUI
struct ToggleFloodFillModeUI_tF40BA330FD9EEC86BEA5CD7943EC4599BAD93095;
// unitycoder_MobilePaint.ToggleLineModeUI
struct ToggleLineModeUI_tB4F725C4D6DD648C397DB3AC4AAB347EC4AA94C4;
// unitycoder_MobilePaint.ToggleMode
struct ToggleMode_t93881258140C0924B93E76F32A64D736B08607F9;
// unitycoder_MobilePaint.TogglePanZoomModeUI
struct TogglePanZoomModeUI_t7EA98A500D67F4E63FCA50307325D99362E30F00;
// unitycoder_MobilePaint_samples.GUIScaler
struct GUIScaler_t6D470D8BFC2F4807DA1811C43EB35472B4D0C13F;
// unitycoder_MobilePaint_samples.LoadImageFromDisk
struct LoadImageFromDisk_t25E1AF3A9B41761AA5B2368589B30DE107BB0DFD;
// unitycoder_MobilePaint_samples.LoadTextureFromWeb
struct LoadTextureFromWeb_tFC746A6E41B9DB9A0D76CE18D58637FA36CA3F18;
// unitycoder_MobilePaint_samples.LoadTextureFromWeb/<Start>d__2
struct U3CStartU3Ed__2_tEC4FB974F881789E25ED33C9CC1420A5662BF176;
// unitycoder_MobilePaint_samples.ObjectRotator
struct ObjectRotator_t95B32158CE027C61B581320C3C6D806CC68AC258;
// unitycoder_MobilePaint_samples.RandomPainter
struct RandomPainter_t2FDDE913E008D1D01B3534CE3173C7E05EFD3D10;
// unitycoder_MobilePaint_samples.SaveImageToFile
struct SaveImageToFile_tA64B2DAC4D2AF5B3E183119D7B8EB1C53770B018;
// unitycoder_MobilePaint_samples.SaveImageToFile/<TakeScreenShot>d__4
struct U3CTakeScreenShotU3Ed__4_t64EC1BB46F6C5F44D6231D42AF034F669E966DE7;
// unitycoder_MobilePaint_samples.SetSortingOrderAndLayer
struct SetSortingOrderAndLayer_tBB2A36BC15162AB6518A830659C7B4623AE6B8D2;
// unitycoder_MobilePaint_samples.TangentSolver
struct TangentSolver_t655698722F48FC1DDDB372D35BC32042835C9FE8;

extern RuntimeClass* Debug_t7B5FCB117E2FD63B6838BC52821B252E2BFB61C4_il2cpp_TypeInfo_var;
extern RuntimeClass* Int32_t585191389E07734F19F3156FF88FB3EF4800D102_il2cpp_TypeInfo_var;
extern RuntimeClass* NotSupportedException_tE75B318D6590A02A5D9B29FD97409B1750FA0010_il2cpp_TypeInfo_var;
extern RuntimeClass* Object_tAE11E5E46CD5C37C9F3E8950C00CD8B45666A2D0_il2cpp_TypeInfo_var;
extern RuntimeClass* PaintManager_t8C7F3BD113E1D28F982A05D0397A369E09266BEE_il2cpp_TypeInfo_var;
extern RuntimeClass* Single_tDDDA9169C4E4E308AC6D7A824F9B28DC82204AE1_il2cpp_TypeInfo_var;
extern RuntimeClass* Texture2D_tBBF96AC337723E2EF156DF17E09D4379FD05DE1C_il2cpp_TypeInfo_var;
extern RuntimeClass* U3CStartU3Ed__2_tEC4FB974F881789E25ED33C9CC1420A5662BF176_il2cpp_TypeInfo_var;
extern RuntimeClass* U3CTakeScreenShotU3Ed__4_t64EC1BB46F6C5F44D6231D42AF034F669E966DE7_il2cpp_TypeInfo_var;
extern RuntimeClass* UnityAction_1_tB994D127B02789CE2010397AEF756615E5F84FDC_il2cpp_TypeInfo_var;
extern RuntimeClass* Vector3U5BU5D_tB9EC3346CC4A0EA5447D968E84A9AC1F6F372C28_il2cpp_TypeInfo_var;
extern RuntimeClass* Vector3_tDCF05E21F632FE2BA260C06E0D10CA81513E6720_il2cpp_TypeInfo_var;
extern RuntimeClass* Vector4U5BU5D_t51402C154FFFCF7217A9BEC4B834F0B726C10F66_il2cpp_TypeInfo_var;
extern RuntimeClass* Vector4_tD148D6428C3F8FF6CD998F82090113C2B490B76E_il2cpp_TypeInfo_var;
extern RuntimeClass* WWW_tA50AFB5DE276783409B4CE88FE9B772322EE5664_il2cpp_TypeInfo_var;
extern RuntimeClass* WaitForEndOfFrame_t75980FB3F246D6AD36A85CA2BFDF8474E5EEBCCA_il2cpp_TypeInfo_var;
extern String_t* _stringLiteral0E21ACCF4B52FBCAC31706043FCB375D33FBE946;
extern String_t* _stringLiteral18D7B45DCCC374DAC64758C817E1917534D16F3F;
extern String_t* _stringLiteral3F663A634BF9364321DB1AB11E3F43060097BF04;
extern String_t* _stringLiteral42099B4AF021E53FD8FD4E056C2568D7C2E3FFA8;
extern String_t* _stringLiteral48B34F43F564D41B959300B7677B4FFA92E6DF9A;
extern String_t* _stringLiteral771F138D9C7A926E5BE4BA01840663EE8D31F54E;
extern String_t* _stringLiteral786E544BB06C3ABF1CB01BDA08D7D3131DBD8599;
extern String_t* _stringLiteral808D7DCA8A74D84AF27A2D6602C3D786DE45FE1E;
extern String_t* _stringLiteral821B5DB5E92E7BF3D748D2268C2C912DE1019557;
extern String_t* _stringLiteral87D0177B26480EC93071EC19F377958DE8FCF405;
extern String_t* _stringLiteral9FCBAD1C07A47FCE95E02D55974D5730506273DC;
extern String_t* _stringLiteralA2C598E208B87F5295AAA4420CC533C4028BE345;
extern String_t* _stringLiteralC91A3B0927A7298D2B845FB524A9A00216F7CD7F;
extern String_t* _stringLiteralCC679B8F680542478E3C9C80547777A0EED3B432;
extern String_t* _stringLiteralD583746F12022FBC88293CCA2619D6B8A9B6472A;
extern String_t* _stringLiteralEDE796F19952CB1FC543E86FFB96733DFA0E0870;
extern String_t* _stringLiteralF4088DDD15F0018ADED2993A916DD07CDBA5D439;
extern String_t* _stringLiteralFFB3B317C519BDE283D8101D0B219BD8A4A161FE;
extern const RuntimeMethod* Component_GetComponent_TisGUIText_t1AAED515CF7E63F24B55C5FC988555DA14DA10F1_m051AF02F5332F75F23DAD7A0E8AFA3DC70A92E62_RuntimeMethod_var;
extern const RuntimeMethod* Component_GetComponent_TisGUITexture_t2A2F300B0F9D542DADB532DEC861D1711B5C46F3_m8BBADD3541C0470568F03947E759412155A68210_RuntimeMethod_var;
extern const RuntimeMethod* Component_GetComponent_TisRenderer_t0556D67DD582620D1F495627EDE30D03284151F4_m3E0C8F08ADF98436AEF5AE9F4C56A51FF7D0A892_RuntimeMethod_var;
extern const RuntimeMethod* Component_GetComponent_TisToggle_t9ADD572046F831945ED0E48A01B50FEA1CA52106_m89C4B9EA41130113FE63C1D06704BB4B91AD779B_RuntimeMethod_var;
extern const RuntimeMethod* GameObject_GetComponent_TisGUITexture_t2A2F300B0F9D542DADB532DEC861D1711B5C46F3_m100DA46881E26B04E4A5E2906D85B4C3C7A71E94_RuntimeMethod_var;
extern const RuntimeMethod* GameObject_GetComponent_TisMobilePaint_tC25928758E48181B341DE30F410E3EA407D005E5_mEC9B744C4448971CB528E3CFAB3EC41F435E2944_RuntimeMethod_var;
extern const RuntimeMethod* ToggleBrushModeUI_U3CStartU3Eb__1_0_m05A85D28E9E9DEE9FE480EDD51389D9CA2182F93_RuntimeMethod_var;
extern const RuntimeMethod* ToggleCustomPatternModeUI_U3CStartU3Eb__2_0_m9D320741A979A9DEF8309511B626F4B37C5B3825_RuntimeMethod_var;
extern const RuntimeMethod* ToggleCustomShapeModeUI_U3CStartU3Eb__2_0_m5ED189BC7474A70EB98ADAECCED64CD95CA5B82C_RuntimeMethod_var;
extern const RuntimeMethod* ToggleEraserModeUI_U3CStartU3Eb__1_0_m3C573D215A9FDCDF3A8EDE5F15A03DCD22B05C85_RuntimeMethod_var;
extern const RuntimeMethod* ToggleFloodFillModeUI_U3CStartU3Eb__1_0_m9AB4739F25B0D0FCBACC931E811631A42A77D865_RuntimeMethod_var;
extern const RuntimeMethod* ToggleLineModeUI_U3CStartU3Eb__1_0_m021522DF62D5036FE9A056B7A05262FF7C8D5495_RuntimeMethod_var;
extern const RuntimeMethod* TogglePanZoomModeUI_U3CStartU3Eb__1_0_m46CBE507BE800CCE3438034C32DAA0B562214D7D_RuntimeMethod_var;
extern const RuntimeMethod* U3CStartU3Ed__2_System_Collections_IEnumerator_Reset_mF33C48CFBA65054D9C7C2E59048671B782426CA8_RuntimeMethod_var;
extern const RuntimeMethod* U3CTakeScreenShotU3Ed__4_System_Collections_IEnumerator_Reset_m3E894B69319934EECAC34BACC0EC47DD267CEBE6_RuntimeMethod_var;
extern const RuntimeMethod* UnityAction_1__ctor_m846CC5F9F2FD2F58CD1E78E7A4EB55DC5D6CA696_RuntimeMethod_var;
extern const RuntimeMethod* UnityEvent_1_AddListener_mBCA646AF6B22F9F8190175F6AFF5195A9BED3FCA_RuntimeMethod_var;
extern const uint32_t AreaWasPainted_BeginInvoke_mA2B880190BEE6835AE27468ED77E7499F241A1E3_MetadataUsageId;
extern const uint32_t GUIScaler_Awake_mF7325223C09C36114F1439CC72664B4DDF407EAC_MetadataUsageId;
extern const uint32_t LoadImageFromDisk_LoadImageAsCanvas_m14529C87F9A3E52E4E057DCC3AE2FA5A543C965B_MetadataUsageId;
extern const uint32_t LoadImageFromDisk_Start_m59F8793B7043932EA36CBA5D37E499FD1A8CCEFF_MetadataUsageId;
extern const uint32_t LoadImageFromDisk__ctor_m7F09557FF989BF261ED0BC85C6835B9B6D0F61BA_MetadataUsageId;
extern const uint32_t LoadTextureFromWeb_Start_mF463CA246EEB425450E0D50A89468619102E1F68_MetadataUsageId;
extern const uint32_t LoadTextureFromWeb__ctor_m86E12CD93A8D0041C153347DC90AB5C880479C91_MetadataUsageId;
extern const uint32_t OverrideTestForUI_HideUI_m4ED010136011E0659730150E484E1BFAAB7F2285_MetadataUsageId;
extern const uint32_t OverrideTestForUI_ShowUI_mE1C8705850FFE69AB7B1F4C0E3FC2F9AB99E2F25_MetadataUsageId;
extern const uint32_t PaintManager_Awake_mB6E861990500DDA4510DAC23C2AFCB3E2C156AA9_MetadataUsageId;
extern const uint32_t RandomPainter_Start_mB2753D21050D108CE78F5FA44F3F7E4A4D067061_MetadataUsageId;
extern const uint32_t SaveImageToFile_Start_mB25E5A76789A91B110D88E200C7324D1ADFC99B2_MetadataUsageId;
extern const uint32_t SaveImageToFile_TakeScreenShot_mF31594A7E22C2A2E632345CEC685BDEA695A3C37_MetadataUsageId;
extern const uint32_t SetNewCanvasImageExample_Start_m84D721AC0E9B59996543CB42A8FBC0C4D349A7D8_MetadataUsageId;
extern const uint32_t SetNewMaskImage_Start_m642F4210B7FFC91BDF37EC01E86EE76D7EE0911B_MetadataUsageId;
extern const uint32_t SetSortingOrderAndLayer_Awake_mEE214F4FB7872C261EF6C7CA574105EE665430A4_MetadataUsageId;
extern const uint32_t SetSortingOrderAndLayer__ctor_m0879B1433E145E2873FF6D1B8AFCC7DC466A6200_MetadataUsageId;
extern const uint32_t TangentSolver_Solve_mC1A59B0DE4F71AE58060A1FA0E546917C348B7F7_MetadataUsageId;
extern const uint32_t ToggleBrushModeUI_SetMode_m0D6E237D85BE989C46F3399244FB8B9065AC2BF8_MetadataUsageId;
extern const uint32_t ToggleBrushModeUI_Start_mE14D3D6A5D897EEA80C686D2633B9AFAE0663996_MetadataUsageId;
extern const uint32_t ToggleCustomPatternModeUI_SetMode_mF0225DFF7BFBCF4A096FF61DBE8631B3607BCDFD_MetadataUsageId;
extern const uint32_t ToggleCustomPatternModeUI_Start_mBED1EEC50E04980751FBD5D6E57A8606F052F284_MetadataUsageId;
extern const uint32_t ToggleCustomShapeModeUI_SetMode_mE58A9402216F7D890A4258BD6D6BE6D3F4FA4D2C_MetadataUsageId;
extern const uint32_t ToggleCustomShapeModeUI_Start_mDCF0B691794D31EFBF7C0A3744439B649449CEC7_MetadataUsageId;
extern const uint32_t ToggleEraserModeUI_SetMode_mB8CD91227A8742223015F5DBB79CC498D1AE3B6B_MetadataUsageId;
extern const uint32_t ToggleEraserModeUI_Start_m2F5227799AEC33A72B6A5D19F1820693F618C080_MetadataUsageId;
extern const uint32_t ToggleFloodFillModeUI_SetMode_m64DE801CCA5251718582F3FC81B83D279BE9F811_MetadataUsageId;
extern const uint32_t ToggleFloodFillModeUI_Start_mEE320A965A70D12824DC4C5ADE0C9128AF2A892F_MetadataUsageId;
extern const uint32_t ToggleLineModeUI_SetMode_m2C8B487144B734A99D53DEA0DF9563DEFD1B5979_MetadataUsageId;
extern const uint32_t ToggleLineModeUI_Start_mCA708BB155073CF160261F2FA5410E8B3D39B160_MetadataUsageId;
extern const uint32_t ToggleMode_OnMouseDown_mAB5E5E892709DB080A396478C22F5F62AE48838B_MetadataUsageId;
extern const uint32_t TogglePanZoomModeUI_Start_m5EC187CE56087FBFDAD3C391C6E1AE7083DEDB7E_MetadataUsageId;
extern const uint32_t TogglePanZoomModeUI_ToggleZoomPan_m5C400FF51681E0C0ED6EAFE6CD7FFC000A2D8D81_MetadataUsageId;
extern const uint32_t U3CStartU3Ed__2_MoveNext_m8F0E7A6565076AFD1B0EBFCEF0A2E96BBBA5DEA9_MetadataUsageId;
extern const uint32_t U3CStartU3Ed__2_System_Collections_IEnumerator_Reset_mF33C48CFBA65054D9C7C2E59048671B782426CA8_MetadataUsageId;
extern const uint32_t U3CTakeScreenShotU3Ed__4_MoveNext_m2603AACF6ED5242C103ACE5FE55A2EF46B70D884_MetadataUsageId;
extern const uint32_t U3CTakeScreenShotU3Ed__4_System_Collections_IEnumerator_Reset_m3E894B69319934EECAC34BACC0EC47DD267CEBE6_MetadataUsageId;
struct Exception_t_marshaled_com;
struct Exception_t_marshaled_pinvoke;

struct ByteU5BU5D_tD06FDBE8142446525DF1C40351D523A228373821;
struct DelegateU5BU5D_tDFCDEE2A6322F96C0FE49AF47E9ADB8C4B294E86;
struct Int32U5BU5D_t2B9E4FDDDB9F0A00EC0AC631BA2DA915EB1ECF83;
struct Texture2DU5BU5D_tCAC03055C735C020BAFC218D55183CF03E74C1C9;
struct Vector2U5BU5D_tA065A07DFC060C1B8786BBAA5F3A6577CCEB27D6;
struct Vector3U5BU5D_tB9EC3346CC4A0EA5447D968E84A9AC1F6F372C28;
struct Vector4U5BU5D_t51402C154FFFCF7217A9BEC4B834F0B726C10F66;


#ifndef RUNTIMEOBJECT_H
#define RUNTIMEOBJECT_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// System.Object

#ifdef __clang__
#pragma clang diagnostic pop
#endif
#endif // RUNTIMEOBJECT_H
struct Il2CppArrayBounds;
#ifndef RUNTIMEARRAY_H
#define RUNTIMEARRAY_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// System.Array

#ifdef __clang__
#pragma clang diagnostic pop
#endif
#endif // RUNTIMEARRAY_H
#ifndef EXCEPTION_T_H
#define EXCEPTION_T_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// System.Exception
struct  Exception_t  : public RuntimeObject
{
public:
	// System.String System.Exception::_className
	String_t* ____className_1;
	// System.String System.Exception::_message
	String_t* ____message_2;
	// System.Collections.IDictionary System.Exception::_data
	RuntimeObject* ____data_3;
	// System.Exception System.Exception::_innerException
	Exception_t * ____innerException_4;
	// System.String System.Exception::_helpURL
	String_t* ____helpURL_5;
	// System.Object System.Exception::_stackTrace
	RuntimeObject * ____stackTrace_6;
	// System.String System.Exception::_stackTraceString
	String_t* ____stackTraceString_7;
	// System.String System.Exception::_remoteStackTraceString
	String_t* ____remoteStackTraceString_8;
	// System.Int32 System.Exception::_remoteStackIndex
	int32_t ____remoteStackIndex_9;
	// System.Object System.Exception::_dynamicMethods
	RuntimeObject * ____dynamicMethods_10;
	// System.Int32 System.Exception::_HResult
	int32_t ____HResult_11;
	// System.String System.Exception::_source
	String_t* ____source_12;
	// System.Runtime.Serialization.SafeSerializationManager System.Exception::_safeSerializationManager
	SafeSerializationManager_t4A754D86B0F784B18CBC36C073BA564BED109770 * ____safeSerializationManager_13;
	// System.Diagnostics.StackTrace[] System.Exception::captured_traces
	StackTraceU5BU5D_t855F09649EA34DEE7C1B6F088E0538E3CCC3F196* ___captured_traces_14;
	// System.IntPtr[] System.Exception::native_trace_ips
	IntPtrU5BU5D_t4DC01DCB9A6DF6C9792A6513595D7A11E637DCDD* ___native_trace_ips_15;

public:
	inline static int32_t get_offset_of__className_1() { return static_cast<int32_t>(offsetof(Exception_t, ____className_1)); }
	inline String_t* get__className_1() const { return ____className_1; }
	inline String_t** get_address_of__className_1() { return &____className_1; }
	inline void set__className_1(String_t* value)
	{
		____className_1 = value;
		Il2CppCodeGenWriteBarrier((&____className_1), value);
	}

	inline static int32_t get_offset_of__message_2() { return static_cast<int32_t>(offsetof(Exception_t, ____message_2)); }
	inline String_t* get__message_2() const { return ____message_2; }
	inline String_t** get_address_of__message_2() { return &____message_2; }
	inline void set__message_2(String_t* value)
	{
		____message_2 = value;
		Il2CppCodeGenWriteBarrier((&____message_2), value);
	}

	inline static int32_t get_offset_of__data_3() { return static_cast<int32_t>(offsetof(Exception_t, ____data_3)); }
	inline RuntimeObject* get__data_3() const { return ____data_3; }
	inline RuntimeObject** get_address_of__data_3() { return &____data_3; }
	inline void set__data_3(RuntimeObject* value)
	{
		____data_3 = value;
		Il2CppCodeGenWriteBarrier((&____data_3), value);
	}

	inline static int32_t get_offset_of__innerException_4() { return static_cast<int32_t>(offsetof(Exception_t, ____innerException_4)); }
	inline Exception_t * get__innerException_4() const { return ____innerException_4; }
	inline Exception_t ** get_address_of__innerException_4() { return &____innerException_4; }
	inline void set__innerException_4(Exception_t * value)
	{
		____innerException_4 = value;
		Il2CppCodeGenWriteBarrier((&____innerException_4), value);
	}

	inline static int32_t get_offset_of__helpURL_5() { return static_cast<int32_t>(offsetof(Exception_t, ____helpURL_5)); }
	inline String_t* get__helpURL_5() const { return ____helpURL_5; }
	inline String_t** get_address_of__helpURL_5() { return &____helpURL_5; }
	inline void set__helpURL_5(String_t* value)
	{
		____helpURL_5 = value;
		Il2CppCodeGenWriteBarrier((&____helpURL_5), value);
	}

	inline static int32_t get_offset_of__stackTrace_6() { return static_cast<int32_t>(offsetof(Exception_t, ____stackTrace_6)); }
	inline RuntimeObject * get__stackTrace_6() const { return ____stackTrace_6; }
	inline RuntimeObject ** get_address_of__stackTrace_6() { return &____stackTrace_6; }
	inline void set__stackTrace_6(RuntimeObject * value)
	{
		____stackTrace_6 = value;
		Il2CppCodeGenWriteBarrier((&____stackTrace_6), value);
	}

	inline static int32_t get_offset_of__stackTraceString_7() { return static_cast<int32_t>(offsetof(Exception_t, ____stackTraceString_7)); }
	inline String_t* get__stackTraceString_7() const { return ____stackTraceString_7; }
	inline String_t** get_address_of__stackTraceString_7() { return &____stackTraceString_7; }
	inline void set__stackTraceString_7(String_t* value)
	{
		____stackTraceString_7 = value;
		Il2CppCodeGenWriteBarrier((&____stackTraceString_7), value);
	}

	inline static int32_t get_offset_of__remoteStackTraceString_8() { return static_cast<int32_t>(offsetof(Exception_t, ____remoteStackTraceString_8)); }
	inline String_t* get__remoteStackTraceString_8() const { return ____remoteStackTraceString_8; }
	inline String_t** get_address_of__remoteStackTraceString_8() { return &____remoteStackTraceString_8; }
	inline void set__remoteStackTraceString_8(String_t* value)
	{
		____remoteStackTraceString_8 = value;
		Il2CppCodeGenWriteBarrier((&____remoteStackTraceString_8), value);
	}

	inline static int32_t get_offset_of__remoteStackIndex_9() { return static_cast<int32_t>(offsetof(Exception_t, ____remoteStackIndex_9)); }
	inline int32_t get__remoteStackIndex_9() const { return ____remoteStackIndex_9; }
	inline int32_t* get_address_of__remoteStackIndex_9() { return &____remoteStackIndex_9; }
	inline void set__remoteStackIndex_9(int32_t value)
	{
		____remoteStackIndex_9 = value;
	}

	inline static int32_t get_offset_of__dynamicMethods_10() { return static_cast<int32_t>(offsetof(Exception_t, ____dynamicMethods_10)); }
	inline RuntimeObject * get__dynamicMethods_10() const { return ____dynamicMethods_10; }
	inline RuntimeObject ** get_address_of__dynamicMethods_10() { return &____dynamicMethods_10; }
	inline void set__dynamicMethods_10(RuntimeObject * value)
	{
		____dynamicMethods_10 = value;
		Il2CppCodeGenWriteBarrier((&____dynamicMethods_10), value);
	}

	inline static int32_t get_offset_of__HResult_11() { return static_cast<int32_t>(offsetof(Exception_t, ____HResult_11)); }
	inline int32_t get__HResult_11() const { return ____HResult_11; }
	inline int32_t* get_address_of__HResult_11() { return &____HResult_11; }
	inline void set__HResult_11(int32_t value)
	{
		____HResult_11 = value;
	}

	inline static int32_t get_offset_of__source_12() { return static_cast<int32_t>(offsetof(Exception_t, ____source_12)); }
	inline String_t* get__source_12() const { return ____source_12; }
	inline String_t** get_address_of__source_12() { return &____source_12; }
	inline void set__source_12(String_t* value)
	{
		____source_12 = value;
		Il2CppCodeGenWriteBarrier((&____source_12), value);
	}

	inline static int32_t get_offset_of__safeSerializationManager_13() { return static_cast<int32_t>(offsetof(Exception_t, ____safeSerializationManager_13)); }
	inline SafeSerializationManager_t4A754D86B0F784B18CBC36C073BA564BED109770 * get__safeSerializationManager_13() const { return ____safeSerializationManager_13; }
	inline SafeSerializationManager_t4A754D86B0F784B18CBC36C073BA564BED109770 ** get_address_of__safeSerializationManager_13() { return &____safeSerializationManager_13; }
	inline void set__safeSerializationManager_13(SafeSerializationManager_t4A754D86B0F784B18CBC36C073BA564BED109770 * value)
	{
		____safeSerializationManager_13 = value;
		Il2CppCodeGenWriteBarrier((&____safeSerializationManager_13), value);
	}

	inline static int32_t get_offset_of_captured_traces_14() { return static_cast<int32_t>(offsetof(Exception_t, ___captured_traces_14)); }
	inline StackTraceU5BU5D_t855F09649EA34DEE7C1B6F088E0538E3CCC3F196* get_captured_traces_14() const { return ___captured_traces_14; }
	inline StackTraceU5BU5D_t855F09649EA34DEE7C1B6F088E0538E3CCC3F196** get_address_of_captured_traces_14() { return &___captured_traces_14; }
	inline void set_captured_traces_14(StackTraceU5BU5D_t855F09649EA34DEE7C1B6F088E0538E3CCC3F196* value)
	{
		___captured_traces_14 = value;
		Il2CppCodeGenWriteBarrier((&___captured_traces_14), value);
	}

	inline static int32_t get_offset_of_native_trace_ips_15() { return static_cast<int32_t>(offsetof(Exception_t, ___native_trace_ips_15)); }
	inline IntPtrU5BU5D_t4DC01DCB9A6DF6C9792A6513595D7A11E637DCDD* get_native_trace_ips_15() const { return ___native_trace_ips_15; }
	inline IntPtrU5BU5D_t4DC01DCB9A6DF6C9792A6513595D7A11E637DCDD** get_address_of_native_trace_ips_15() { return &___native_trace_ips_15; }
	inline void set_native_trace_ips_15(IntPtrU5BU5D_t4DC01DCB9A6DF6C9792A6513595D7A11E637DCDD* value)
	{
		___native_trace_ips_15 = value;
		Il2CppCodeGenWriteBarrier((&___native_trace_ips_15), value);
	}
};

struct Exception_t_StaticFields
{
public:
	// System.Object System.Exception::s_EDILock
	RuntimeObject * ___s_EDILock_0;

public:
	inline static int32_t get_offset_of_s_EDILock_0() { return static_cast<int32_t>(offsetof(Exception_t_StaticFields, ___s_EDILock_0)); }
	inline RuntimeObject * get_s_EDILock_0() const { return ___s_EDILock_0; }
	inline RuntimeObject ** get_address_of_s_EDILock_0() { return &___s_EDILock_0; }
	inline void set_s_EDILock_0(RuntimeObject * value)
	{
		___s_EDILock_0 = value;
		Il2CppCodeGenWriteBarrier((&___s_EDILock_0), value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
// Native definition for P/Invoke marshalling of System.Exception
struct Exception_t_marshaled_pinvoke
{
	char* ____className_1;
	char* ____message_2;
	RuntimeObject* ____data_3;
	Exception_t_marshaled_pinvoke* ____innerException_4;
	char* ____helpURL_5;
	Il2CppIUnknown* ____stackTrace_6;
	char* ____stackTraceString_7;
	char* ____remoteStackTraceString_8;
	int32_t ____remoteStackIndex_9;
	Il2CppIUnknown* ____dynamicMethods_10;
	int32_t ____HResult_11;
	char* ____source_12;
	SafeSerializationManager_t4A754D86B0F784B18CBC36C073BA564BED109770 * ____safeSerializationManager_13;
	StackTraceU5BU5D_t855F09649EA34DEE7C1B6F088E0538E3CCC3F196* ___captured_traces_14;
	intptr_t* ___native_trace_ips_15;
};
// Native definition for COM marshalling of System.Exception
struct Exception_t_marshaled_com
{
	Il2CppChar* ____className_1;
	Il2CppChar* ____message_2;
	RuntimeObject* ____data_3;
	Exception_t_marshaled_com* ____innerException_4;
	Il2CppChar* ____helpURL_5;
	Il2CppIUnknown* ____stackTrace_6;
	Il2CppChar* ____stackTraceString_7;
	Il2CppChar* ____remoteStackTraceString_8;
	int32_t ____remoteStackIndex_9;
	Il2CppIUnknown* ____dynamicMethods_10;
	int32_t ____HResult_11;
	Il2CppChar* ____source_12;
	SafeSerializationManager_t4A754D86B0F784B18CBC36C073BA564BED109770 * ____safeSerializationManager_13;
	StackTraceU5BU5D_t855F09649EA34DEE7C1B6F088E0538E3CCC3F196* ___captured_traces_14;
	intptr_t* ___native_trace_ips_15;
};
#endif // EXCEPTION_T_H
#ifndef MARSHALBYREFOBJECT_TC4577953D0A44D0AB8597CFA868E01C858B1C9AF_H
#define MARSHALBYREFOBJECT_TC4577953D0A44D0AB8597CFA868E01C858B1C9AF_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// System.MarshalByRefObject
struct  MarshalByRefObject_tC4577953D0A44D0AB8597CFA868E01C858B1C9AF  : public RuntimeObject
{
public:
	// System.Object System.MarshalByRefObject::_identity
	RuntimeObject * ____identity_0;

public:
	inline static int32_t get_offset_of__identity_0() { return static_cast<int32_t>(offsetof(MarshalByRefObject_tC4577953D0A44D0AB8597CFA868E01C858B1C9AF, ____identity_0)); }
	inline RuntimeObject * get__identity_0() const { return ____identity_0; }
	inline RuntimeObject ** get_address_of__identity_0() { return &____identity_0; }
	inline void set__identity_0(RuntimeObject * value)
	{
		____identity_0 = value;
		Il2CppCodeGenWriteBarrier((&____identity_0), value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
// Native definition for P/Invoke marshalling of System.MarshalByRefObject
struct MarshalByRefObject_tC4577953D0A44D0AB8597CFA868E01C858B1C9AF_marshaled_pinvoke
{
	Il2CppIUnknown* ____identity_0;
};
// Native definition for COM marshalling of System.MarshalByRefObject
struct MarshalByRefObject_tC4577953D0A44D0AB8597CFA868E01C858B1C9AF_marshaled_com
{
	Il2CppIUnknown* ____identity_0;
};
#endif // MARSHALBYREFOBJECT_TC4577953D0A44D0AB8597CFA868E01C858B1C9AF_H
#ifndef STRING_T_H
#define STRING_T_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// System.String
struct  String_t  : public RuntimeObject
{
public:
	// System.Int32 System.String::m_stringLength
	int32_t ___m_stringLength_0;
	// System.Char System.String::m_firstChar
	Il2CppChar ___m_firstChar_1;

public:
	inline static int32_t get_offset_of_m_stringLength_0() { return static_cast<int32_t>(offsetof(String_t, ___m_stringLength_0)); }
	inline int32_t get_m_stringLength_0() const { return ___m_stringLength_0; }
	inline int32_t* get_address_of_m_stringLength_0() { return &___m_stringLength_0; }
	inline void set_m_stringLength_0(int32_t value)
	{
		___m_stringLength_0 = value;
	}

	inline static int32_t get_offset_of_m_firstChar_1() { return static_cast<int32_t>(offsetof(String_t, ___m_firstChar_1)); }
	inline Il2CppChar get_m_firstChar_1() const { return ___m_firstChar_1; }
	inline Il2CppChar* get_address_of_m_firstChar_1() { return &___m_firstChar_1; }
	inline void set_m_firstChar_1(Il2CppChar value)
	{
		___m_firstChar_1 = value;
	}
};

struct String_t_StaticFields
{
public:
	// System.String System.String::Empty
	String_t* ___Empty_5;

public:
	inline static int32_t get_offset_of_Empty_5() { return static_cast<int32_t>(offsetof(String_t_StaticFields, ___Empty_5)); }
	inline String_t* get_Empty_5() const { return ___Empty_5; }
	inline String_t** get_address_of_Empty_5() { return &___Empty_5; }
	inline void set_Empty_5(String_t* value)
	{
		___Empty_5 = value;
		Il2CppCodeGenWriteBarrier((&___Empty_5), value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
#endif // STRING_T_H
#ifndef VALUETYPE_T4D0C27076F7C36E76190FB3328E232BCB1CD1FFF_H
#define VALUETYPE_T4D0C27076F7C36E76190FB3328E232BCB1CD1FFF_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// System.ValueType
struct  ValueType_t4D0C27076F7C36E76190FB3328E232BCB1CD1FFF  : public RuntimeObject
{
public:

public:
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
// Native definition for P/Invoke marshalling of System.ValueType
struct ValueType_t4D0C27076F7C36E76190FB3328E232BCB1CD1FFF_marshaled_pinvoke
{
};
// Native definition for COM marshalling of System.ValueType
struct ValueType_t4D0C27076F7C36E76190FB3328E232BCB1CD1FFF_marshaled_com
{
};
#endif // VALUETYPE_T4D0C27076F7C36E76190FB3328E232BCB1CD1FFF_H
#ifndef CUSTOMYIELDINSTRUCTION_T819BB0973AFF22766749FF087B8AEFEAF3C2CB7D_H
#define CUSTOMYIELDINSTRUCTION_T819BB0973AFF22766749FF087B8AEFEAF3C2CB7D_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// UnityEngine.CustomYieldInstruction
struct  CustomYieldInstruction_t819BB0973AFF22766749FF087B8AEFEAF3C2CB7D  : public RuntimeObject
{
public:

public:
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
#endif // CUSTOMYIELDINSTRUCTION_T819BB0973AFF22766749FF087B8AEFEAF3C2CB7D_H
#ifndef UNITYEVENTBASE_T6E0F7823762EE94BB8489B5AE41C7802A266D3D5_H
#define UNITYEVENTBASE_T6E0F7823762EE94BB8489B5AE41C7802A266D3D5_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// UnityEngine.Events.UnityEventBase
struct  UnityEventBase_t6E0F7823762EE94BB8489B5AE41C7802A266D3D5  : public RuntimeObject
{
public:
	// UnityEngine.Events.InvokableCallList UnityEngine.Events.UnityEventBase::m_Calls
	InvokableCallList_t18AA4F473C7B295216B7D4B9723B4F3DFCCC9A3F * ___m_Calls_0;
	// UnityEngine.Events.PersistentCallGroup UnityEngine.Events.UnityEventBase::m_PersistentCalls
	PersistentCallGroup_t6E5DF2EBDA42794B5FE0C6DAA97DF65F0BFF571F * ___m_PersistentCalls_1;
	// System.String UnityEngine.Events.UnityEventBase::m_TypeName
	String_t* ___m_TypeName_2;
	// System.Boolean UnityEngine.Events.UnityEventBase::m_CallsDirty
	bool ___m_CallsDirty_3;

public:
	inline static int32_t get_offset_of_m_Calls_0() { return static_cast<int32_t>(offsetof(UnityEventBase_t6E0F7823762EE94BB8489B5AE41C7802A266D3D5, ___m_Calls_0)); }
	inline InvokableCallList_t18AA4F473C7B295216B7D4B9723B4F3DFCCC9A3F * get_m_Calls_0() const { return ___m_Calls_0; }
	inline InvokableCallList_t18AA4F473C7B295216B7D4B9723B4F3DFCCC9A3F ** get_address_of_m_Calls_0() { return &___m_Calls_0; }
	inline void set_m_Calls_0(InvokableCallList_t18AA4F473C7B295216B7D4B9723B4F3DFCCC9A3F * value)
	{
		___m_Calls_0 = value;
		Il2CppCodeGenWriteBarrier((&___m_Calls_0), value);
	}

	inline static int32_t get_offset_of_m_PersistentCalls_1() { return static_cast<int32_t>(offsetof(UnityEventBase_t6E0F7823762EE94BB8489B5AE41C7802A266D3D5, ___m_PersistentCalls_1)); }
	inline PersistentCallGroup_t6E5DF2EBDA42794B5FE0C6DAA97DF65F0BFF571F * get_m_PersistentCalls_1() const { return ___m_PersistentCalls_1; }
	inline PersistentCallGroup_t6E5DF2EBDA42794B5FE0C6DAA97DF65F0BFF571F ** get_address_of_m_PersistentCalls_1() { return &___m_PersistentCalls_1; }
	inline void set_m_PersistentCalls_1(PersistentCallGroup_t6E5DF2EBDA42794B5FE0C6DAA97DF65F0BFF571F * value)
	{
		___m_PersistentCalls_1 = value;
		Il2CppCodeGenWriteBarrier((&___m_PersistentCalls_1), value);
	}

	inline static int32_t get_offset_of_m_TypeName_2() { return static_cast<int32_t>(offsetof(UnityEventBase_t6E0F7823762EE94BB8489B5AE41C7802A266D3D5, ___m_TypeName_2)); }
	inline String_t* get_m_TypeName_2() const { return ___m_TypeName_2; }
	inline String_t** get_address_of_m_TypeName_2() { return &___m_TypeName_2; }
	inline void set_m_TypeName_2(String_t* value)
	{
		___m_TypeName_2 = value;
		Il2CppCodeGenWriteBarrier((&___m_TypeName_2), value);
	}

	inline static int32_t get_offset_of_m_CallsDirty_3() { return static_cast<int32_t>(offsetof(UnityEventBase_t6E0F7823762EE94BB8489B5AE41C7802A266D3D5, ___m_CallsDirty_3)); }
	inline bool get_m_CallsDirty_3() const { return ___m_CallsDirty_3; }
	inline bool* get_address_of_m_CallsDirty_3() { return &___m_CallsDirty_3; }
	inline void set_m_CallsDirty_3(bool value)
	{
		___m_CallsDirty_3 = value;
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
#endif // UNITYEVENTBASE_T6E0F7823762EE94BB8489B5AE41C7802A266D3D5_H
#ifndef YIELDINSTRUCTION_T836035AC7BD07A3C7909F7AD2A5B42DE99D91C44_H
#define YIELDINSTRUCTION_T836035AC7BD07A3C7909F7AD2A5B42DE99D91C44_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// UnityEngine.YieldInstruction
struct  YieldInstruction_t836035AC7BD07A3C7909F7AD2A5B42DE99D91C44  : public RuntimeObject
{
public:

public:
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
// Native definition for P/Invoke marshalling of UnityEngine.YieldInstruction
struct YieldInstruction_t836035AC7BD07A3C7909F7AD2A5B42DE99D91C44_marshaled_pinvoke
{
};
// Native definition for COM marshalling of UnityEngine.YieldInstruction
struct YieldInstruction_t836035AC7BD07A3C7909F7AD2A5B42DE99D91C44_marshaled_com
{
};
#endif // YIELDINSTRUCTION_T836035AC7BD07A3C7909F7AD2A5B42DE99D91C44_H
#ifndef PAINTTOOLS_T48946C04AB6DB2171D01BE68687CF14E4FE87E3F_H
#define PAINTTOOLS_T48946C04AB6DB2171D01BE68687CF14E4FE87E3F_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// unitycoder_MobilePaint.PaintTools
struct  PaintTools_t48946C04AB6DB2171D01BE68687CF14E4FE87E3F  : public RuntimeObject
{
public:

public:
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
#endif // PAINTTOOLS_T48946C04AB6DB2171D01BE68687CF14E4FE87E3F_H
#ifndef U3CSTARTU3ED__2_TEC4FB974F881789E25ED33C9CC1420A5662BF176_H
#define U3CSTARTU3ED__2_TEC4FB974F881789E25ED33C9CC1420A5662BF176_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// unitycoder_MobilePaint_samples.LoadTextureFromWeb/<Start>d__2
struct  U3CStartU3Ed__2_tEC4FB974F881789E25ED33C9CC1420A5662BF176  : public RuntimeObject
{
public:
	// System.Int32 unitycoder_MobilePaint_samples.LoadTextureFromWeb/<Start>d__2::<>1__state
	int32_t ___U3CU3E1__state_0;
	// System.Object unitycoder_MobilePaint_samples.LoadTextureFromWeb/<Start>d__2::<>2__current
	RuntimeObject * ___U3CU3E2__current_1;
	// unitycoder_MobilePaint_samples.LoadTextureFromWeb unitycoder_MobilePaint_samples.LoadTextureFromWeb/<Start>d__2::<>4__this
	LoadTextureFromWeb_tFC746A6E41B9DB9A0D76CE18D58637FA36CA3F18 * ___U3CU3E4__this_2;
	// UnityEngine.WWW unitycoder_MobilePaint_samples.LoadTextureFromWeb/<Start>d__2::<www>5__2
	WWW_tA50AFB5DE276783409B4CE88FE9B772322EE5664 * ___U3CwwwU3E5__2_3;

public:
	inline static int32_t get_offset_of_U3CU3E1__state_0() { return static_cast<int32_t>(offsetof(U3CStartU3Ed__2_tEC4FB974F881789E25ED33C9CC1420A5662BF176, ___U3CU3E1__state_0)); }
	inline int32_t get_U3CU3E1__state_0() const { return ___U3CU3E1__state_0; }
	inline int32_t* get_address_of_U3CU3E1__state_0() { return &___U3CU3E1__state_0; }
	inline void set_U3CU3E1__state_0(int32_t value)
	{
		___U3CU3E1__state_0 = value;
	}

	inline static int32_t get_offset_of_U3CU3E2__current_1() { return static_cast<int32_t>(offsetof(U3CStartU3Ed__2_tEC4FB974F881789E25ED33C9CC1420A5662BF176, ___U3CU3E2__current_1)); }
	inline RuntimeObject * get_U3CU3E2__current_1() const { return ___U3CU3E2__current_1; }
	inline RuntimeObject ** get_address_of_U3CU3E2__current_1() { return &___U3CU3E2__current_1; }
	inline void set_U3CU3E2__current_1(RuntimeObject * value)
	{
		___U3CU3E2__current_1 = value;
		Il2CppCodeGenWriteBarrier((&___U3CU3E2__current_1), value);
	}

	inline static int32_t get_offset_of_U3CU3E4__this_2() { return static_cast<int32_t>(offsetof(U3CStartU3Ed__2_tEC4FB974F881789E25ED33C9CC1420A5662BF176, ___U3CU3E4__this_2)); }
	inline LoadTextureFromWeb_tFC746A6E41B9DB9A0D76CE18D58637FA36CA3F18 * get_U3CU3E4__this_2() const { return ___U3CU3E4__this_2; }
	inline LoadTextureFromWeb_tFC746A6E41B9DB9A0D76CE18D58637FA36CA3F18 ** get_address_of_U3CU3E4__this_2() { return &___U3CU3E4__this_2; }
	inline void set_U3CU3E4__this_2(LoadTextureFromWeb_tFC746A6E41B9DB9A0D76CE18D58637FA36CA3F18 * value)
	{
		___U3CU3E4__this_2 = value;
		Il2CppCodeGenWriteBarrier((&___U3CU3E4__this_2), value);
	}

	inline static int32_t get_offset_of_U3CwwwU3E5__2_3() { return static_cast<int32_t>(offsetof(U3CStartU3Ed__2_tEC4FB974F881789E25ED33C9CC1420A5662BF176, ___U3CwwwU3E5__2_3)); }
	inline WWW_tA50AFB5DE276783409B4CE88FE9B772322EE5664 * get_U3CwwwU3E5__2_3() const { return ___U3CwwwU3E5__2_3; }
	inline WWW_tA50AFB5DE276783409B4CE88FE9B772322EE5664 ** get_address_of_U3CwwwU3E5__2_3() { return &___U3CwwwU3E5__2_3; }
	inline void set_U3CwwwU3E5__2_3(WWW_tA50AFB5DE276783409B4CE88FE9B772322EE5664 * value)
	{
		___U3CwwwU3E5__2_3 = value;
		Il2CppCodeGenWriteBarrier((&___U3CwwwU3E5__2_3), value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
#endif // U3CSTARTU3ED__2_TEC4FB974F881789E25ED33C9CC1420A5662BF176_H
#ifndef U3CTAKESCREENSHOTU3ED__4_T64EC1BB46F6C5F44D6231D42AF034F669E966DE7_H
#define U3CTAKESCREENSHOTU3ED__4_T64EC1BB46F6C5F44D6231D42AF034F669E966DE7_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// unitycoder_MobilePaint_samples.SaveImageToFile/<TakeScreenShot>d__4
struct  U3CTakeScreenShotU3Ed__4_t64EC1BB46F6C5F44D6231D42AF034F669E966DE7  : public RuntimeObject
{
public:
	// System.Int32 unitycoder_MobilePaint_samples.SaveImageToFile/<TakeScreenShot>d__4::<>1__state
	int32_t ___U3CU3E1__state_0;
	// System.Object unitycoder_MobilePaint_samples.SaveImageToFile/<TakeScreenShot>d__4::<>2__current
	RuntimeObject * ___U3CU3E2__current_1;
	// unitycoder_MobilePaint_samples.SaveImageToFile unitycoder_MobilePaint_samples.SaveImageToFile/<TakeScreenShot>d__4::<>4__this
	SaveImageToFile_tA64B2DAC4D2AF5B3E183119D7B8EB1C53770B018 * ___U3CU3E4__this_2;

public:
	inline static int32_t get_offset_of_U3CU3E1__state_0() { return static_cast<int32_t>(offsetof(U3CTakeScreenShotU3Ed__4_t64EC1BB46F6C5F44D6231D42AF034F669E966DE7, ___U3CU3E1__state_0)); }
	inline int32_t get_U3CU3E1__state_0() const { return ___U3CU3E1__state_0; }
	inline int32_t* get_address_of_U3CU3E1__state_0() { return &___U3CU3E1__state_0; }
	inline void set_U3CU3E1__state_0(int32_t value)
	{
		___U3CU3E1__state_0 = value;
	}

	inline static int32_t get_offset_of_U3CU3E2__current_1() { return static_cast<int32_t>(offsetof(U3CTakeScreenShotU3Ed__4_t64EC1BB46F6C5F44D6231D42AF034F669E966DE7, ___U3CU3E2__current_1)); }
	inline RuntimeObject * get_U3CU3E2__current_1() const { return ___U3CU3E2__current_1; }
	inline RuntimeObject ** get_address_of_U3CU3E2__current_1() { return &___U3CU3E2__current_1; }
	inline void set_U3CU3E2__current_1(RuntimeObject * value)
	{
		___U3CU3E2__current_1 = value;
		Il2CppCodeGenWriteBarrier((&___U3CU3E2__current_1), value);
	}

	inline static int32_t get_offset_of_U3CU3E4__this_2() { return static_cast<int32_t>(offsetof(U3CTakeScreenShotU3Ed__4_t64EC1BB46F6C5F44D6231D42AF034F669E966DE7, ___U3CU3E4__this_2)); }
	inline SaveImageToFile_tA64B2DAC4D2AF5B3E183119D7B8EB1C53770B018 * get_U3CU3E4__this_2() const { return ___U3CU3E4__this_2; }
	inline SaveImageToFile_tA64B2DAC4D2AF5B3E183119D7B8EB1C53770B018 ** get_address_of_U3CU3E4__this_2() { return &___U3CU3E4__this_2; }
	inline void set_U3CU3E4__this_2(SaveImageToFile_tA64B2DAC4D2AF5B3E183119D7B8EB1C53770B018 * value)
	{
		___U3CU3E4__this_2 = value;
		Il2CppCodeGenWriteBarrier((&___U3CU3E4__this_2), value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
#endif // U3CTAKESCREENSHOTU3ED__4_T64EC1BB46F6C5F44D6231D42AF034F669E966DE7_H
#ifndef BOOLEAN_TB53F6830F670160873277339AA58F15CAED4399C_H
#define BOOLEAN_TB53F6830F670160873277339AA58F15CAED4399C_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// System.Boolean
struct  Boolean_tB53F6830F670160873277339AA58F15CAED4399C 
{
public:
	// System.Boolean System.Boolean::m_value
	bool ___m_value_0;

public:
	inline static int32_t get_offset_of_m_value_0() { return static_cast<int32_t>(offsetof(Boolean_tB53F6830F670160873277339AA58F15CAED4399C, ___m_value_0)); }
	inline bool get_m_value_0() const { return ___m_value_0; }
	inline bool* get_address_of_m_value_0() { return &___m_value_0; }
	inline void set_m_value_0(bool value)
	{
		___m_value_0 = value;
	}
};

struct Boolean_tB53F6830F670160873277339AA58F15CAED4399C_StaticFields
{
public:
	// System.String System.Boolean::TrueString
	String_t* ___TrueString_5;
	// System.String System.Boolean::FalseString
	String_t* ___FalseString_6;

public:
	inline static int32_t get_offset_of_TrueString_5() { return static_cast<int32_t>(offsetof(Boolean_tB53F6830F670160873277339AA58F15CAED4399C_StaticFields, ___TrueString_5)); }
	inline String_t* get_TrueString_5() const { return ___TrueString_5; }
	inline String_t** get_address_of_TrueString_5() { return &___TrueString_5; }
	inline void set_TrueString_5(String_t* value)
	{
		___TrueString_5 = value;
		Il2CppCodeGenWriteBarrier((&___TrueString_5), value);
	}

	inline static int32_t get_offset_of_FalseString_6() { return static_cast<int32_t>(offsetof(Boolean_tB53F6830F670160873277339AA58F15CAED4399C_StaticFields, ___FalseString_6)); }
	inline String_t* get_FalseString_6() const { return ___FalseString_6; }
	inline String_t** get_address_of_FalseString_6() { return &___FalseString_6; }
	inline void set_FalseString_6(String_t* value)
	{
		___FalseString_6 = value;
		Il2CppCodeGenWriteBarrier((&___FalseString_6), value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
#endif // BOOLEAN_TB53F6830F670160873277339AA58F15CAED4399C_H
#ifndef BYTE_TF87C579059BD4633E6840EBBBEEF899C6E33EF07_H
#define BYTE_TF87C579059BD4633E6840EBBBEEF899C6E33EF07_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// System.Byte
struct  Byte_tF87C579059BD4633E6840EBBBEEF899C6E33EF07 
{
public:
	// System.Byte System.Byte::m_value
	uint8_t ___m_value_0;

public:
	inline static int32_t get_offset_of_m_value_0() { return static_cast<int32_t>(offsetof(Byte_tF87C579059BD4633E6840EBBBEEF899C6E33EF07, ___m_value_0)); }
	inline uint8_t get_m_value_0() const { return ___m_value_0; }
	inline uint8_t* get_address_of_m_value_0() { return &___m_value_0; }
	inline void set_m_value_0(uint8_t value)
	{
		___m_value_0 = value;
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
#endif // BYTE_TF87C579059BD4633E6840EBBBEEF899C6E33EF07_H
#ifndef ENUM_T2AF27C02B8653AE29442467390005ABC74D8F521_H
#define ENUM_T2AF27C02B8653AE29442467390005ABC74D8F521_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// System.Enum
struct  Enum_t2AF27C02B8653AE29442467390005ABC74D8F521  : public ValueType_t4D0C27076F7C36E76190FB3328E232BCB1CD1FFF
{
public:

public:
};

struct Enum_t2AF27C02B8653AE29442467390005ABC74D8F521_StaticFields
{
public:
	// System.Char[] System.Enum::enumSeperatorCharArray
	CharU5BU5D_t4CC6ABF0AD71BEC97E3C2F1E9C5677E46D3A75C2* ___enumSeperatorCharArray_0;

public:
	inline static int32_t get_offset_of_enumSeperatorCharArray_0() { return static_cast<int32_t>(offsetof(Enum_t2AF27C02B8653AE29442467390005ABC74D8F521_StaticFields, ___enumSeperatorCharArray_0)); }
	inline CharU5BU5D_t4CC6ABF0AD71BEC97E3C2F1E9C5677E46D3A75C2* get_enumSeperatorCharArray_0() const { return ___enumSeperatorCharArray_0; }
	inline CharU5BU5D_t4CC6ABF0AD71BEC97E3C2F1E9C5677E46D3A75C2** get_address_of_enumSeperatorCharArray_0() { return &___enumSeperatorCharArray_0; }
	inline void set_enumSeperatorCharArray_0(CharU5BU5D_t4CC6ABF0AD71BEC97E3C2F1E9C5677E46D3A75C2* value)
	{
		___enumSeperatorCharArray_0 = value;
		Il2CppCodeGenWriteBarrier((&___enumSeperatorCharArray_0), value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
// Native definition for P/Invoke marshalling of System.Enum
struct Enum_t2AF27C02B8653AE29442467390005ABC74D8F521_marshaled_pinvoke
{
};
// Native definition for COM marshalling of System.Enum
struct Enum_t2AF27C02B8653AE29442467390005ABC74D8F521_marshaled_com
{
};
#endif // ENUM_T2AF27C02B8653AE29442467390005ABC74D8F521_H
#ifndef INT32_T585191389E07734F19F3156FF88FB3EF4800D102_H
#define INT32_T585191389E07734F19F3156FF88FB3EF4800D102_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// System.Int32
struct  Int32_t585191389E07734F19F3156FF88FB3EF4800D102 
{
public:
	// System.Int32 System.Int32::m_value
	int32_t ___m_value_0;

public:
	inline static int32_t get_offset_of_m_value_0() { return static_cast<int32_t>(offsetof(Int32_t585191389E07734F19F3156FF88FB3EF4800D102, ___m_value_0)); }
	inline int32_t get_m_value_0() const { return ___m_value_0; }
	inline int32_t* get_address_of_m_value_0() { return &___m_value_0; }
	inline void set_m_value_0(int32_t value)
	{
		___m_value_0 = value;
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
#endif // INT32_T585191389E07734F19F3156FF88FB3EF4800D102_H
#ifndef INTPTR_T_H
#define INTPTR_T_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// System.IntPtr
struct  IntPtr_t 
{
public:
	// System.Void* System.IntPtr::m_value
	void* ___m_value_0;

public:
	inline static int32_t get_offset_of_m_value_0() { return static_cast<int32_t>(offsetof(IntPtr_t, ___m_value_0)); }
	inline void* get_m_value_0() const { return ___m_value_0; }
	inline void** get_address_of_m_value_0() { return &___m_value_0; }
	inline void set_m_value_0(void* value)
	{
		___m_value_0 = value;
	}
};

struct IntPtr_t_StaticFields
{
public:
	// System.IntPtr System.IntPtr::Zero
	intptr_t ___Zero_1;

public:
	inline static int32_t get_offset_of_Zero_1() { return static_cast<int32_t>(offsetof(IntPtr_t_StaticFields, ___Zero_1)); }
	inline intptr_t get_Zero_1() const { return ___Zero_1; }
	inline intptr_t* get_address_of_Zero_1() { return &___Zero_1; }
	inline void set_Zero_1(intptr_t value)
	{
		___Zero_1 = value;
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
#endif // INTPTR_T_H
#ifndef SINGLE_TDDDA9169C4E4E308AC6D7A824F9B28DC82204AE1_H
#define SINGLE_TDDDA9169C4E4E308AC6D7A824F9B28DC82204AE1_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// System.Single
struct  Single_tDDDA9169C4E4E308AC6D7A824F9B28DC82204AE1 
{
public:
	// System.Single System.Single::m_value
	float ___m_value_0;

public:
	inline static int32_t get_offset_of_m_value_0() { return static_cast<int32_t>(offsetof(Single_tDDDA9169C4E4E308AC6D7A824F9B28DC82204AE1, ___m_value_0)); }
	inline float get_m_value_0() const { return ___m_value_0; }
	inline float* get_address_of_m_value_0() { return &___m_value_0; }
	inline void set_m_value_0(float value)
	{
		___m_value_0 = value;
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
#endif // SINGLE_TDDDA9169C4E4E308AC6D7A824F9B28DC82204AE1_H
#ifndef SYSTEMEXCEPTION_T5380468142AA850BE4A341D7AF3EAB9C78746782_H
#define SYSTEMEXCEPTION_T5380468142AA850BE4A341D7AF3EAB9C78746782_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// System.SystemException
struct  SystemException_t5380468142AA850BE4A341D7AF3EAB9C78746782  : public Exception_t
{
public:

public:
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
#endif // SYSTEMEXCEPTION_T5380468142AA850BE4A341D7AF3EAB9C78746782_H
#ifndef VOID_T22962CB4C05B1D89B55A6E1139F0E87A90987017_H
#define VOID_T22962CB4C05B1D89B55A6E1139F0E87A90987017_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// System.Void
struct  Void_t22962CB4C05B1D89B55A6E1139F0E87A90987017 
{
public:
	union
	{
		struct
		{
		};
		uint8_t Void_t22962CB4C05B1D89B55A6E1139F0E87A90987017__padding[1];
	};

public:
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
#endif // VOID_T22962CB4C05B1D89B55A6E1139F0E87A90987017_H
#ifndef COLOR_T119BCA590009762C7223FDD3AF9706653AC84ED2_H
#define COLOR_T119BCA590009762C7223FDD3AF9706653AC84ED2_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// UnityEngine.Color
struct  Color_t119BCA590009762C7223FDD3AF9706653AC84ED2 
{
public:
	// System.Single UnityEngine.Color::r
	float ___r_0;
	// System.Single UnityEngine.Color::g
	float ___g_1;
	// System.Single UnityEngine.Color::b
	float ___b_2;
	// System.Single UnityEngine.Color::a
	float ___a_3;

public:
	inline static int32_t get_offset_of_r_0() { return static_cast<int32_t>(offsetof(Color_t119BCA590009762C7223FDD3AF9706653AC84ED2, ___r_0)); }
	inline float get_r_0() const { return ___r_0; }
	inline float* get_address_of_r_0() { return &___r_0; }
	inline void set_r_0(float value)
	{
		___r_0 = value;
	}

	inline static int32_t get_offset_of_g_1() { return static_cast<int32_t>(offsetof(Color_t119BCA590009762C7223FDD3AF9706653AC84ED2, ___g_1)); }
	inline float get_g_1() const { return ___g_1; }
	inline float* get_address_of_g_1() { return &___g_1; }
	inline void set_g_1(float value)
	{
		___g_1 = value;
	}

	inline static int32_t get_offset_of_b_2() { return static_cast<int32_t>(offsetof(Color_t119BCA590009762C7223FDD3AF9706653AC84ED2, ___b_2)); }
	inline float get_b_2() const { return ___b_2; }
	inline float* get_address_of_b_2() { return &___b_2; }
	inline void set_b_2(float value)
	{
		___b_2 = value;
	}

	inline static int32_t get_offset_of_a_3() { return static_cast<int32_t>(offsetof(Color_t119BCA590009762C7223FDD3AF9706653AC84ED2, ___a_3)); }
	inline float get_a_3() const { return ___a_3; }
	inline float* get_address_of_a_3() { return &___a_3; }
	inline void set_a_3(float value)
	{
		___a_3 = value;
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
#endif // COLOR_T119BCA590009762C7223FDD3AF9706653AC84ED2_H
#ifndef COLOR32_T23ABC4AE0E0BDFD2E22EE1FA0DA3904FFE5F6E23_H
#define COLOR32_T23ABC4AE0E0BDFD2E22EE1FA0DA3904FFE5F6E23_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// UnityEngine.Color32
struct  Color32_t23ABC4AE0E0BDFD2E22EE1FA0DA3904FFE5F6E23 
{
public:
	union
	{
		#pragma pack(push, tp, 1)
		struct
		{
			// System.Int32 UnityEngine.Color32::rgba
			int32_t ___rgba_0;
		};
		#pragma pack(pop, tp)
		struct
		{
			int32_t ___rgba_0_forAlignmentOnly;
		};
		#pragma pack(push, tp, 1)
		struct
		{
			// System.Byte UnityEngine.Color32::r
			uint8_t ___r_1;
		};
		#pragma pack(pop, tp)
		struct
		{
			uint8_t ___r_1_forAlignmentOnly;
		};
		#pragma pack(push, tp, 1)
		struct
		{
			char ___g_2_OffsetPadding[1];
			// System.Byte UnityEngine.Color32::g
			uint8_t ___g_2;
		};
		#pragma pack(pop, tp)
		struct
		{
			char ___g_2_OffsetPadding_forAlignmentOnly[1];
			uint8_t ___g_2_forAlignmentOnly;
		};
		#pragma pack(push, tp, 1)
		struct
		{
			char ___b_3_OffsetPadding[2];
			// System.Byte UnityEngine.Color32::b
			uint8_t ___b_3;
		};
		#pragma pack(pop, tp)
		struct
		{
			char ___b_3_OffsetPadding_forAlignmentOnly[2];
			uint8_t ___b_3_forAlignmentOnly;
		};
		#pragma pack(push, tp, 1)
		struct
		{
			char ___a_4_OffsetPadding[3];
			// System.Byte UnityEngine.Color32::a
			uint8_t ___a_4;
		};
		#pragma pack(pop, tp)
		struct
		{
			char ___a_4_OffsetPadding_forAlignmentOnly[3];
			uint8_t ___a_4_forAlignmentOnly;
		};
	};

public:
	inline static int32_t get_offset_of_rgba_0() { return static_cast<int32_t>(offsetof(Color32_t23ABC4AE0E0BDFD2E22EE1FA0DA3904FFE5F6E23, ___rgba_0)); }
	inline int32_t get_rgba_0() const { return ___rgba_0; }
	inline int32_t* get_address_of_rgba_0() { return &___rgba_0; }
	inline void set_rgba_0(int32_t value)
	{
		___rgba_0 = value;
	}

	inline static int32_t get_offset_of_r_1() { return static_cast<int32_t>(offsetof(Color32_t23ABC4AE0E0BDFD2E22EE1FA0DA3904FFE5F6E23, ___r_1)); }
	inline uint8_t get_r_1() const { return ___r_1; }
	inline uint8_t* get_address_of_r_1() { return &___r_1; }
	inline void set_r_1(uint8_t value)
	{
		___r_1 = value;
	}

	inline static int32_t get_offset_of_g_2() { return static_cast<int32_t>(offsetof(Color32_t23ABC4AE0E0BDFD2E22EE1FA0DA3904FFE5F6E23, ___g_2)); }
	inline uint8_t get_g_2() const { return ___g_2; }
	inline uint8_t* get_address_of_g_2() { return &___g_2; }
	inline void set_g_2(uint8_t value)
	{
		___g_2 = value;
	}

	inline static int32_t get_offset_of_b_3() { return static_cast<int32_t>(offsetof(Color32_t23ABC4AE0E0BDFD2E22EE1FA0DA3904FFE5F6E23, ___b_3)); }
	inline uint8_t get_b_3() const { return ___b_3; }
	inline uint8_t* get_address_of_b_3() { return &___b_3; }
	inline void set_b_3(uint8_t value)
	{
		___b_3 = value;
	}

	inline static int32_t get_offset_of_a_4() { return static_cast<int32_t>(offsetof(Color32_t23ABC4AE0E0BDFD2E22EE1FA0DA3904FFE5F6E23, ___a_4)); }
	inline uint8_t get_a_4() const { return ___a_4; }
	inline uint8_t* get_address_of_a_4() { return &___a_4; }
	inline void set_a_4(uint8_t value)
	{
		___a_4 = value;
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
#endif // COLOR32_T23ABC4AE0E0BDFD2E22EE1FA0DA3904FFE5F6E23_H
#ifndef UNITYEVENT_1_T6FE5C79FD433599728A9AA732E588823AB88FDB5_H
#define UNITYEVENT_1_T6FE5C79FD433599728A9AA732E588823AB88FDB5_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// UnityEngine.Events.UnityEvent`1<System.Boolean>
struct  UnityEvent_1_t6FE5C79FD433599728A9AA732E588823AB88FDB5  : public UnityEventBase_t6E0F7823762EE94BB8489B5AE41C7802A266D3D5
{
public:
	// System.Object[] UnityEngine.Events.UnityEvent`1::m_InvokeArray
	ObjectU5BU5D_t3C9242B5C88A48B2A5BD9FDA6CD0024E792AF08A* ___m_InvokeArray_4;

public:
	inline static int32_t get_offset_of_m_InvokeArray_4() { return static_cast<int32_t>(offsetof(UnityEvent_1_t6FE5C79FD433599728A9AA732E588823AB88FDB5, ___m_InvokeArray_4)); }
	inline ObjectU5BU5D_t3C9242B5C88A48B2A5BD9FDA6CD0024E792AF08A* get_m_InvokeArray_4() const { return ___m_InvokeArray_4; }
	inline ObjectU5BU5D_t3C9242B5C88A48B2A5BD9FDA6CD0024E792AF08A** get_address_of_m_InvokeArray_4() { return &___m_InvokeArray_4; }
	inline void set_m_InvokeArray_4(ObjectU5BU5D_t3C9242B5C88A48B2A5BD9FDA6CD0024E792AF08A* value)
	{
		___m_InvokeArray_4 = value;
		Il2CppCodeGenWriteBarrier((&___m_InvokeArray_4), value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
#endif // UNITYEVENT_1_T6FE5C79FD433599728A9AA732E588823AB88FDB5_H
#ifndef LAYERMASK_TBB9173D8B6939D476E67E849280AC9F4EC4D93B0_H
#define LAYERMASK_TBB9173D8B6939D476E67E849280AC9F4EC4D93B0_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// UnityEngine.LayerMask
struct  LayerMask_tBB9173D8B6939D476E67E849280AC9F4EC4D93B0 
{
public:
	// System.Int32 UnityEngine.LayerMask::m_Mask
	int32_t ___m_Mask_0;

public:
	inline static int32_t get_offset_of_m_Mask_0() { return static_cast<int32_t>(offsetof(LayerMask_tBB9173D8B6939D476E67E849280AC9F4EC4D93B0, ___m_Mask_0)); }
	inline int32_t get_m_Mask_0() const { return ___m_Mask_0; }
	inline int32_t* get_address_of_m_Mask_0() { return &___m_Mask_0; }
	inline void set_m_Mask_0(int32_t value)
	{
		___m_Mask_0 = value;
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
#endif // LAYERMASK_TBB9173D8B6939D476E67E849280AC9F4EC4D93B0_H
#ifndef RECT_T35B976DE901B5423C11705E156938EA27AB402CE_H
#define RECT_T35B976DE901B5423C11705E156938EA27AB402CE_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// UnityEngine.Rect
struct  Rect_t35B976DE901B5423C11705E156938EA27AB402CE 
{
public:
	// System.Single UnityEngine.Rect::m_XMin
	float ___m_XMin_0;
	// System.Single UnityEngine.Rect::m_YMin
	float ___m_YMin_1;
	// System.Single UnityEngine.Rect::m_Width
	float ___m_Width_2;
	// System.Single UnityEngine.Rect::m_Height
	float ___m_Height_3;

public:
	inline static int32_t get_offset_of_m_XMin_0() { return static_cast<int32_t>(offsetof(Rect_t35B976DE901B5423C11705E156938EA27AB402CE, ___m_XMin_0)); }
	inline float get_m_XMin_0() const { return ___m_XMin_0; }
	inline float* get_address_of_m_XMin_0() { return &___m_XMin_0; }
	inline void set_m_XMin_0(float value)
	{
		___m_XMin_0 = value;
	}

	inline static int32_t get_offset_of_m_YMin_1() { return static_cast<int32_t>(offsetof(Rect_t35B976DE901B5423C11705E156938EA27AB402CE, ___m_YMin_1)); }
	inline float get_m_YMin_1() const { return ___m_YMin_1; }
	inline float* get_address_of_m_YMin_1() { return &___m_YMin_1; }
	inline void set_m_YMin_1(float value)
	{
		___m_YMin_1 = value;
	}

	inline static int32_t get_offset_of_m_Width_2() { return static_cast<int32_t>(offsetof(Rect_t35B976DE901B5423C11705E156938EA27AB402CE, ___m_Width_2)); }
	inline float get_m_Width_2() const { return ___m_Width_2; }
	inline float* get_address_of_m_Width_2() { return &___m_Width_2; }
	inline void set_m_Width_2(float value)
	{
		___m_Width_2 = value;
	}

	inline static int32_t get_offset_of_m_Height_3() { return static_cast<int32_t>(offsetof(Rect_t35B976DE901B5423C11705E156938EA27AB402CE, ___m_Height_3)); }
	inline float get_m_Height_3() const { return ___m_Height_3; }
	inline float* get_address_of_m_Height_3() { return &___m_Height_3; }
	inline void set_m_Height_3(float value)
	{
		___m_Height_3 = value;
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
#endif // RECT_T35B976DE901B5423C11705E156938EA27AB402CE_H
#ifndef SPRITESTATE_T58B9DD66A79CD69AB4CFC3AD0C41E45DC2192C0A_H
#define SPRITESTATE_T58B9DD66A79CD69AB4CFC3AD0C41E45DC2192C0A_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// UnityEngine.UI.SpriteState
struct  SpriteState_t58B9DD66A79CD69AB4CFC3AD0C41E45DC2192C0A 
{
public:
	// UnityEngine.Sprite UnityEngine.UI.SpriteState::m_HighlightedSprite
	Sprite_tCA09498D612D08DE668653AF1E9C12BF53434198 * ___m_HighlightedSprite_0;
	// UnityEngine.Sprite UnityEngine.UI.SpriteState::m_PressedSprite
	Sprite_tCA09498D612D08DE668653AF1E9C12BF53434198 * ___m_PressedSprite_1;
	// UnityEngine.Sprite UnityEngine.UI.SpriteState::m_DisabledSprite
	Sprite_tCA09498D612D08DE668653AF1E9C12BF53434198 * ___m_DisabledSprite_2;

public:
	inline static int32_t get_offset_of_m_HighlightedSprite_0() { return static_cast<int32_t>(offsetof(SpriteState_t58B9DD66A79CD69AB4CFC3AD0C41E45DC2192C0A, ___m_HighlightedSprite_0)); }
	inline Sprite_tCA09498D612D08DE668653AF1E9C12BF53434198 * get_m_HighlightedSprite_0() const { return ___m_HighlightedSprite_0; }
	inline Sprite_tCA09498D612D08DE668653AF1E9C12BF53434198 ** get_address_of_m_HighlightedSprite_0() { return &___m_HighlightedSprite_0; }
	inline void set_m_HighlightedSprite_0(Sprite_tCA09498D612D08DE668653AF1E9C12BF53434198 * value)
	{
		___m_HighlightedSprite_0 = value;
		Il2CppCodeGenWriteBarrier((&___m_HighlightedSprite_0), value);
	}

	inline static int32_t get_offset_of_m_PressedSprite_1() { return static_cast<int32_t>(offsetof(SpriteState_t58B9DD66A79CD69AB4CFC3AD0C41E45DC2192C0A, ___m_PressedSprite_1)); }
	inline Sprite_tCA09498D612D08DE668653AF1E9C12BF53434198 * get_m_PressedSprite_1() const { return ___m_PressedSprite_1; }
	inline Sprite_tCA09498D612D08DE668653AF1E9C12BF53434198 ** get_address_of_m_PressedSprite_1() { return &___m_PressedSprite_1; }
	inline void set_m_PressedSprite_1(Sprite_tCA09498D612D08DE668653AF1E9C12BF53434198 * value)
	{
		___m_PressedSprite_1 = value;
		Il2CppCodeGenWriteBarrier((&___m_PressedSprite_1), value);
	}

	inline static int32_t get_offset_of_m_DisabledSprite_2() { return static_cast<int32_t>(offsetof(SpriteState_t58B9DD66A79CD69AB4CFC3AD0C41E45DC2192C0A, ___m_DisabledSprite_2)); }
	inline Sprite_tCA09498D612D08DE668653AF1E9C12BF53434198 * get_m_DisabledSprite_2() const { return ___m_DisabledSprite_2; }
	inline Sprite_tCA09498D612D08DE668653AF1E9C12BF53434198 ** get_address_of_m_DisabledSprite_2() { return &___m_DisabledSprite_2; }
	inline void set_m_DisabledSprite_2(Sprite_tCA09498D612D08DE668653AF1E9C12BF53434198 * value)
	{
		___m_DisabledSprite_2 = value;
		Il2CppCodeGenWriteBarrier((&___m_DisabledSprite_2), value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
// Native definition for P/Invoke marshalling of UnityEngine.UI.SpriteState
struct SpriteState_t58B9DD66A79CD69AB4CFC3AD0C41E45DC2192C0A_marshaled_pinvoke
{
	Sprite_tCA09498D612D08DE668653AF1E9C12BF53434198 * ___m_HighlightedSprite_0;
	Sprite_tCA09498D612D08DE668653AF1E9C12BF53434198 * ___m_PressedSprite_1;
	Sprite_tCA09498D612D08DE668653AF1E9C12BF53434198 * ___m_DisabledSprite_2;
};
// Native definition for COM marshalling of UnityEngine.UI.SpriteState
struct SpriteState_t58B9DD66A79CD69AB4CFC3AD0C41E45DC2192C0A_marshaled_com
{
	Sprite_tCA09498D612D08DE668653AF1E9C12BF53434198 * ___m_HighlightedSprite_0;
	Sprite_tCA09498D612D08DE668653AF1E9C12BF53434198 * ___m_PressedSprite_1;
	Sprite_tCA09498D612D08DE668653AF1E9C12BF53434198 * ___m_DisabledSprite_2;
};
#endif // SPRITESTATE_T58B9DD66A79CD69AB4CFC3AD0C41E45DC2192C0A_H
#ifndef VECTOR2_TA85D2DD88578276CA8A8796756458277E72D073D_H
#define VECTOR2_TA85D2DD88578276CA8A8796756458277E72D073D_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// UnityEngine.Vector2
struct  Vector2_tA85D2DD88578276CA8A8796756458277E72D073D 
{
public:
	// System.Single UnityEngine.Vector2::x
	float ___x_0;
	// System.Single UnityEngine.Vector2::y
	float ___y_1;

public:
	inline static int32_t get_offset_of_x_0() { return static_cast<int32_t>(offsetof(Vector2_tA85D2DD88578276CA8A8796756458277E72D073D, ___x_0)); }
	inline float get_x_0() const { return ___x_0; }
	inline float* get_address_of_x_0() { return &___x_0; }
	inline void set_x_0(float value)
	{
		___x_0 = value;
	}

	inline static int32_t get_offset_of_y_1() { return static_cast<int32_t>(offsetof(Vector2_tA85D2DD88578276CA8A8796756458277E72D073D, ___y_1)); }
	inline float get_y_1() const { return ___y_1; }
	inline float* get_address_of_y_1() { return &___y_1; }
	inline void set_y_1(float value)
	{
		___y_1 = value;
	}
};

struct Vector2_tA85D2DD88578276CA8A8796756458277E72D073D_StaticFields
{
public:
	// UnityEngine.Vector2 UnityEngine.Vector2::zeroVector
	Vector2_tA85D2DD88578276CA8A8796756458277E72D073D  ___zeroVector_2;
	// UnityEngine.Vector2 UnityEngine.Vector2::oneVector
	Vector2_tA85D2DD88578276CA8A8796756458277E72D073D  ___oneVector_3;
	// UnityEngine.Vector2 UnityEngine.Vector2::upVector
	Vector2_tA85D2DD88578276CA8A8796756458277E72D073D  ___upVector_4;
	// UnityEngine.Vector2 UnityEngine.Vector2::downVector
	Vector2_tA85D2DD88578276CA8A8796756458277E72D073D  ___downVector_5;
	// UnityEngine.Vector2 UnityEngine.Vector2::leftVector
	Vector2_tA85D2DD88578276CA8A8796756458277E72D073D  ___leftVector_6;
	// UnityEngine.Vector2 UnityEngine.Vector2::rightVector
	Vector2_tA85D2DD88578276CA8A8796756458277E72D073D  ___rightVector_7;
	// UnityEngine.Vector2 UnityEngine.Vector2::positiveInfinityVector
	Vector2_tA85D2DD88578276CA8A8796756458277E72D073D  ___positiveInfinityVector_8;
	// UnityEngine.Vector2 UnityEngine.Vector2::negativeInfinityVector
	Vector2_tA85D2DD88578276CA8A8796756458277E72D073D  ___negativeInfinityVector_9;

public:
	inline static int32_t get_offset_of_zeroVector_2() { return static_cast<int32_t>(offsetof(Vector2_tA85D2DD88578276CA8A8796756458277E72D073D_StaticFields, ___zeroVector_2)); }
	inline Vector2_tA85D2DD88578276CA8A8796756458277E72D073D  get_zeroVector_2() const { return ___zeroVector_2; }
	inline Vector2_tA85D2DD88578276CA8A8796756458277E72D073D * get_address_of_zeroVector_2() { return &___zeroVector_2; }
	inline void set_zeroVector_2(Vector2_tA85D2DD88578276CA8A8796756458277E72D073D  value)
	{
		___zeroVector_2 = value;
	}

	inline static int32_t get_offset_of_oneVector_3() { return static_cast<int32_t>(offsetof(Vector2_tA85D2DD88578276CA8A8796756458277E72D073D_StaticFields, ___oneVector_3)); }
	inline Vector2_tA85D2DD88578276CA8A8796756458277E72D073D  get_oneVector_3() const { return ___oneVector_3; }
	inline Vector2_tA85D2DD88578276CA8A8796756458277E72D073D * get_address_of_oneVector_3() { return &___oneVector_3; }
	inline void set_oneVector_3(Vector2_tA85D2DD88578276CA8A8796756458277E72D073D  value)
	{
		___oneVector_3 = value;
	}

	inline static int32_t get_offset_of_upVector_4() { return static_cast<int32_t>(offsetof(Vector2_tA85D2DD88578276CA8A8796756458277E72D073D_StaticFields, ___upVector_4)); }
	inline Vector2_tA85D2DD88578276CA8A8796756458277E72D073D  get_upVector_4() const { return ___upVector_4; }
	inline Vector2_tA85D2DD88578276CA8A8796756458277E72D073D * get_address_of_upVector_4() { return &___upVector_4; }
	inline void set_upVector_4(Vector2_tA85D2DD88578276CA8A8796756458277E72D073D  value)
	{
		___upVector_4 = value;
	}

	inline static int32_t get_offset_of_downVector_5() { return static_cast<int32_t>(offsetof(Vector2_tA85D2DD88578276CA8A8796756458277E72D073D_StaticFields, ___downVector_5)); }
	inline Vector2_tA85D2DD88578276CA8A8796756458277E72D073D  get_downVector_5() const { return ___downVector_5; }
	inline Vector2_tA85D2DD88578276CA8A8796756458277E72D073D * get_address_of_downVector_5() { return &___downVector_5; }
	inline void set_downVector_5(Vector2_tA85D2DD88578276CA8A8796756458277E72D073D  value)
	{
		___downVector_5 = value;
	}

	inline static int32_t get_offset_of_leftVector_6() { return static_cast<int32_t>(offsetof(Vector2_tA85D2DD88578276CA8A8796756458277E72D073D_StaticFields, ___leftVector_6)); }
	inline Vector2_tA85D2DD88578276CA8A8796756458277E72D073D  get_leftVector_6() const { return ___leftVector_6; }
	inline Vector2_tA85D2DD88578276CA8A8796756458277E72D073D * get_address_of_leftVector_6() { return &___leftVector_6; }
	inline void set_leftVector_6(Vector2_tA85D2DD88578276CA8A8796756458277E72D073D  value)
	{
		___leftVector_6 = value;
	}

	inline static int32_t get_offset_of_rightVector_7() { return static_cast<int32_t>(offsetof(Vector2_tA85D2DD88578276CA8A8796756458277E72D073D_StaticFields, ___rightVector_7)); }
	inline Vector2_tA85D2DD88578276CA8A8796756458277E72D073D  get_rightVector_7() const { return ___rightVector_7; }
	inline Vector2_tA85D2DD88578276CA8A8796756458277E72D073D * get_address_of_rightVector_7() { return &___rightVector_7; }
	inline void set_rightVector_7(Vector2_tA85D2DD88578276CA8A8796756458277E72D073D  value)
	{
		___rightVector_7 = value;
	}

	inline static int32_t get_offset_of_positiveInfinityVector_8() { return static_cast<int32_t>(offsetof(Vector2_tA85D2DD88578276CA8A8796756458277E72D073D_StaticFields, ___positiveInfinityVector_8)); }
	inline Vector2_tA85D2DD88578276CA8A8796756458277E72D073D  get_positiveInfinityVector_8() const { return ___positiveInfinityVector_8; }
	inline Vector2_tA85D2DD88578276CA8A8796756458277E72D073D * get_address_of_positiveInfinityVector_8() { return &___positiveInfinityVector_8; }
	inline void set_positiveInfinityVector_8(Vector2_tA85D2DD88578276CA8A8796756458277E72D073D  value)
	{
		___positiveInfinityVector_8 = value;
	}

	inline static int32_t get_offset_of_negativeInfinityVector_9() { return static_cast<int32_t>(offsetof(Vector2_tA85D2DD88578276CA8A8796756458277E72D073D_StaticFields, ___negativeInfinityVector_9)); }
	inline Vector2_tA85D2DD88578276CA8A8796756458277E72D073D  get_negativeInfinityVector_9() const { return ___negativeInfinityVector_9; }
	inline Vector2_tA85D2DD88578276CA8A8796756458277E72D073D * get_address_of_negativeInfinityVector_9() { return &___negativeInfinityVector_9; }
	inline void set_negativeInfinityVector_9(Vector2_tA85D2DD88578276CA8A8796756458277E72D073D  value)
	{
		___negativeInfinityVector_9 = value;
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
#endif // VECTOR2_TA85D2DD88578276CA8A8796756458277E72D073D_H
#ifndef VECTOR3_TDCF05E21F632FE2BA260C06E0D10CA81513E6720_H
#define VECTOR3_TDCF05E21F632FE2BA260C06E0D10CA81513E6720_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// UnityEngine.Vector3
struct  Vector3_tDCF05E21F632FE2BA260C06E0D10CA81513E6720 
{
public:
	// System.Single UnityEngine.Vector3::x
	float ___x_2;
	// System.Single UnityEngine.Vector3::y
	float ___y_3;
	// System.Single UnityEngine.Vector3::z
	float ___z_4;

public:
	inline static int32_t get_offset_of_x_2() { return static_cast<int32_t>(offsetof(Vector3_tDCF05E21F632FE2BA260C06E0D10CA81513E6720, ___x_2)); }
	inline float get_x_2() const { return ___x_2; }
	inline float* get_address_of_x_2() { return &___x_2; }
	inline void set_x_2(float value)
	{
		___x_2 = value;
	}

	inline static int32_t get_offset_of_y_3() { return static_cast<int32_t>(offsetof(Vector3_tDCF05E21F632FE2BA260C06E0D10CA81513E6720, ___y_3)); }
	inline float get_y_3() const { return ___y_3; }
	inline float* get_address_of_y_3() { return &___y_3; }
	inline void set_y_3(float value)
	{
		___y_3 = value;
	}

	inline static int32_t get_offset_of_z_4() { return static_cast<int32_t>(offsetof(Vector3_tDCF05E21F632FE2BA260C06E0D10CA81513E6720, ___z_4)); }
	inline float get_z_4() const { return ___z_4; }
	inline float* get_address_of_z_4() { return &___z_4; }
	inline void set_z_4(float value)
	{
		___z_4 = value;
	}
};

struct Vector3_tDCF05E21F632FE2BA260C06E0D10CA81513E6720_StaticFields
{
public:
	// UnityEngine.Vector3 UnityEngine.Vector3::zeroVector
	Vector3_tDCF05E21F632FE2BA260C06E0D10CA81513E6720  ___zeroVector_5;
	// UnityEngine.Vector3 UnityEngine.Vector3::oneVector
	Vector3_tDCF05E21F632FE2BA260C06E0D10CA81513E6720  ___oneVector_6;
	// UnityEngine.Vector3 UnityEngine.Vector3::upVector
	Vector3_tDCF05E21F632FE2BA260C06E0D10CA81513E6720  ___upVector_7;
	// UnityEngine.Vector3 UnityEngine.Vector3::downVector
	Vector3_tDCF05E21F632FE2BA260C06E0D10CA81513E6720  ___downVector_8;
	// UnityEngine.Vector3 UnityEngine.Vector3::leftVector
	Vector3_tDCF05E21F632FE2BA260C06E0D10CA81513E6720  ___leftVector_9;
	// UnityEngine.Vector3 UnityEngine.Vector3::rightVector
	Vector3_tDCF05E21F632FE2BA260C06E0D10CA81513E6720  ___rightVector_10;
	// UnityEngine.Vector3 UnityEngine.Vector3::forwardVector
	Vector3_tDCF05E21F632FE2BA260C06E0D10CA81513E6720  ___forwardVector_11;
	// UnityEngine.Vector3 UnityEngine.Vector3::backVector
	Vector3_tDCF05E21F632FE2BA260C06E0D10CA81513E6720  ___backVector_12;
	// UnityEngine.Vector3 UnityEngine.Vector3::positiveInfinityVector
	Vector3_tDCF05E21F632FE2BA260C06E0D10CA81513E6720  ___positiveInfinityVector_13;
	// UnityEngine.Vector3 UnityEngine.Vector3::negativeInfinityVector
	Vector3_tDCF05E21F632FE2BA260C06E0D10CA81513E6720  ___negativeInfinityVector_14;

public:
	inline static int32_t get_offset_of_zeroVector_5() { return static_cast<int32_t>(offsetof(Vector3_tDCF05E21F632FE2BA260C06E0D10CA81513E6720_StaticFields, ___zeroVector_5)); }
	inline Vector3_tDCF05E21F632FE2BA260C06E0D10CA81513E6720  get_zeroVector_5() const { return ___zeroVector_5; }
	inline Vector3_tDCF05E21F632FE2BA260C06E0D10CA81513E6720 * get_address_of_zeroVector_5() { return &___zeroVector_5; }
	inline void set_zeroVector_5(Vector3_tDCF05E21F632FE2BA260C06E0D10CA81513E6720  value)
	{
		___zeroVector_5 = value;
	}

	inline static int32_t get_offset_of_oneVector_6() { return static_cast<int32_t>(offsetof(Vector3_tDCF05E21F632FE2BA260C06E0D10CA81513E6720_StaticFields, ___oneVector_6)); }
	inline Vector3_tDCF05E21F632FE2BA260C06E0D10CA81513E6720  get_oneVector_6() const { return ___oneVector_6; }
	inline Vector3_tDCF05E21F632FE2BA260C06E0D10CA81513E6720 * get_address_of_oneVector_6() { return &___oneVector_6; }
	inline void set_oneVector_6(Vector3_tDCF05E21F632FE2BA260C06E0D10CA81513E6720  value)
	{
		___oneVector_6 = value;
	}

	inline static int32_t get_offset_of_upVector_7() { return static_cast<int32_t>(offsetof(Vector3_tDCF05E21F632FE2BA260C06E0D10CA81513E6720_StaticFields, ___upVector_7)); }
	inline Vector3_tDCF05E21F632FE2BA260C06E0D10CA81513E6720  get_upVector_7() const { return ___upVector_7; }
	inline Vector3_tDCF05E21F632FE2BA260C06E0D10CA81513E6720 * get_address_of_upVector_7() { return &___upVector_7; }
	inline void set_upVector_7(Vector3_tDCF05E21F632FE2BA260C06E0D10CA81513E6720  value)
	{
		___upVector_7 = value;
	}

	inline static int32_t get_offset_of_downVector_8() { return static_cast<int32_t>(offsetof(Vector3_tDCF05E21F632FE2BA260C06E0D10CA81513E6720_StaticFields, ___downVector_8)); }
	inline Vector3_tDCF05E21F632FE2BA260C06E0D10CA81513E6720  get_downVector_8() const { return ___downVector_8; }
	inline Vector3_tDCF05E21F632FE2BA260C06E0D10CA81513E6720 * get_address_of_downVector_8() { return &___downVector_8; }
	inline void set_downVector_8(Vector3_tDCF05E21F632FE2BA260C06E0D10CA81513E6720  value)
	{
		___downVector_8 = value;
	}

	inline static int32_t get_offset_of_leftVector_9() { return static_cast<int32_t>(offsetof(Vector3_tDCF05E21F632FE2BA260C06E0D10CA81513E6720_StaticFields, ___leftVector_9)); }
	inline Vector3_tDCF05E21F632FE2BA260C06E0D10CA81513E6720  get_leftVector_9() const { return ___leftVector_9; }
	inline Vector3_tDCF05E21F632FE2BA260C06E0D10CA81513E6720 * get_address_of_leftVector_9() { return &___leftVector_9; }
	inline void set_leftVector_9(Vector3_tDCF05E21F632FE2BA260C06E0D10CA81513E6720  value)
	{
		___leftVector_9 = value;
	}

	inline static int32_t get_offset_of_rightVector_10() { return static_cast<int32_t>(offsetof(Vector3_tDCF05E21F632FE2BA260C06E0D10CA81513E6720_StaticFields, ___rightVector_10)); }
	inline Vector3_tDCF05E21F632FE2BA260C06E0D10CA81513E6720  get_rightVector_10() const { return ___rightVector_10; }
	inline Vector3_tDCF05E21F632FE2BA260C06E0D10CA81513E6720 * get_address_of_rightVector_10() { return &___rightVector_10; }
	inline void set_rightVector_10(Vector3_tDCF05E21F632FE2BA260C06E0D10CA81513E6720  value)
	{
		___rightVector_10 = value;
	}

	inline static int32_t get_offset_of_forwardVector_11() { return static_cast<int32_t>(offsetof(Vector3_tDCF05E21F632FE2BA260C06E0D10CA81513E6720_StaticFields, ___forwardVector_11)); }
	inline Vector3_tDCF05E21F632FE2BA260C06E0D10CA81513E6720  get_forwardVector_11() const { return ___forwardVector_11; }
	inline Vector3_tDCF05E21F632FE2BA260C06E0D10CA81513E6720 * get_address_of_forwardVector_11() { return &___forwardVector_11; }
	inline void set_forwardVector_11(Vector3_tDCF05E21F632FE2BA260C06E0D10CA81513E6720  value)
	{
		___forwardVector_11 = value;
	}

	inline static int32_t get_offset_of_backVector_12() { return static_cast<int32_t>(offsetof(Vector3_tDCF05E21F632FE2BA260C06E0D10CA81513E6720_StaticFields, ___backVector_12)); }
	inline Vector3_tDCF05E21F632FE2BA260C06E0D10CA81513E6720  get_backVector_12() const { return ___backVector_12; }
	inline Vector3_tDCF05E21F632FE2BA260C06E0D10CA81513E6720 * get_address_of_backVector_12() { return &___backVector_12; }
	inline void set_backVector_12(Vector3_tDCF05E21F632FE2BA260C06E0D10CA81513E6720  value)
	{
		___backVector_12 = value;
	}

	inline static int32_t get_offset_of_positiveInfinityVector_13() { return static_cast<int32_t>(offsetof(Vector3_tDCF05E21F632FE2BA260C06E0D10CA81513E6720_StaticFields, ___positiveInfinityVector_13)); }
	inline Vector3_tDCF05E21F632FE2BA260C06E0D10CA81513E6720  get_positiveInfinityVector_13() const { return ___positiveInfinityVector_13; }
	inline Vector3_tDCF05E21F632FE2BA260C06E0D10CA81513E6720 * get_address_of_positiveInfinityVector_13() { return &___positiveInfinityVector_13; }
	inline void set_positiveInfinityVector_13(Vector3_tDCF05E21F632FE2BA260C06E0D10CA81513E6720  value)
	{
		___positiveInfinityVector_13 = value;
	}

	inline static int32_t get_offset_of_negativeInfinityVector_14() { return static_cast<int32_t>(offsetof(Vector3_tDCF05E21F632FE2BA260C06E0D10CA81513E6720_StaticFields, ___negativeInfinityVector_14)); }
	inline Vector3_tDCF05E21F632FE2BA260C06E0D10CA81513E6720  get_negativeInfinityVector_14() const { return ___negativeInfinityVector_14; }
	inline Vector3_tDCF05E21F632FE2BA260C06E0D10CA81513E6720 * get_address_of_negativeInfinityVector_14() { return &___negativeInfinityVector_14; }
	inline void set_negativeInfinityVector_14(Vector3_tDCF05E21F632FE2BA260C06E0D10CA81513E6720  value)
	{
		___negativeInfinityVector_14 = value;
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
#endif // VECTOR3_TDCF05E21F632FE2BA260C06E0D10CA81513E6720_H
#ifndef VECTOR4_TD148D6428C3F8FF6CD998F82090113C2B490B76E_H
#define VECTOR4_TD148D6428C3F8FF6CD998F82090113C2B490B76E_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// UnityEngine.Vector4
struct  Vector4_tD148D6428C3F8FF6CD998F82090113C2B490B76E 
{
public:
	// System.Single UnityEngine.Vector4::x
	float ___x_0;
	// System.Single UnityEngine.Vector4::y
	float ___y_1;
	// System.Single UnityEngine.Vector4::z
	float ___z_2;
	// System.Single UnityEngine.Vector4::w
	float ___w_3;

public:
	inline static int32_t get_offset_of_x_0() { return static_cast<int32_t>(offsetof(Vector4_tD148D6428C3F8FF6CD998F82090113C2B490B76E, ___x_0)); }
	inline float get_x_0() const { return ___x_0; }
	inline float* get_address_of_x_0() { return &___x_0; }
	inline void set_x_0(float value)
	{
		___x_0 = value;
	}

	inline static int32_t get_offset_of_y_1() { return static_cast<int32_t>(offsetof(Vector4_tD148D6428C3F8FF6CD998F82090113C2B490B76E, ___y_1)); }
	inline float get_y_1() const { return ___y_1; }
	inline float* get_address_of_y_1() { return &___y_1; }
	inline void set_y_1(float value)
	{
		___y_1 = value;
	}

	inline static int32_t get_offset_of_z_2() { return static_cast<int32_t>(offsetof(Vector4_tD148D6428C3F8FF6CD998F82090113C2B490B76E, ___z_2)); }
	inline float get_z_2() const { return ___z_2; }
	inline float* get_address_of_z_2() { return &___z_2; }
	inline void set_z_2(float value)
	{
		___z_2 = value;
	}

	inline static int32_t get_offset_of_w_3() { return static_cast<int32_t>(offsetof(Vector4_tD148D6428C3F8FF6CD998F82090113C2B490B76E, ___w_3)); }
	inline float get_w_3() const { return ___w_3; }
	inline float* get_address_of_w_3() { return &___w_3; }
	inline void set_w_3(float value)
	{
		___w_3 = value;
	}
};

struct Vector4_tD148D6428C3F8FF6CD998F82090113C2B490B76E_StaticFields
{
public:
	// UnityEngine.Vector4 UnityEngine.Vector4::zeroVector
	Vector4_tD148D6428C3F8FF6CD998F82090113C2B490B76E  ___zeroVector_4;
	// UnityEngine.Vector4 UnityEngine.Vector4::oneVector
	Vector4_tD148D6428C3F8FF6CD998F82090113C2B490B76E  ___oneVector_5;
	// UnityEngine.Vector4 UnityEngine.Vector4::positiveInfinityVector
	Vector4_tD148D6428C3F8FF6CD998F82090113C2B490B76E  ___positiveInfinityVector_6;
	// UnityEngine.Vector4 UnityEngine.Vector4::negativeInfinityVector
	Vector4_tD148D6428C3F8FF6CD998F82090113C2B490B76E  ___negativeInfinityVector_7;

public:
	inline static int32_t get_offset_of_zeroVector_4() { return static_cast<int32_t>(offsetof(Vector4_tD148D6428C3F8FF6CD998F82090113C2B490B76E_StaticFields, ___zeroVector_4)); }
	inline Vector4_tD148D6428C3F8FF6CD998F82090113C2B490B76E  get_zeroVector_4() const { return ___zeroVector_4; }
	inline Vector4_tD148D6428C3F8FF6CD998F82090113C2B490B76E * get_address_of_zeroVector_4() { return &___zeroVector_4; }
	inline void set_zeroVector_4(Vector4_tD148D6428C3F8FF6CD998F82090113C2B490B76E  value)
	{
		___zeroVector_4 = value;
	}

	inline static int32_t get_offset_of_oneVector_5() { return static_cast<int32_t>(offsetof(Vector4_tD148D6428C3F8FF6CD998F82090113C2B490B76E_StaticFields, ___oneVector_5)); }
	inline Vector4_tD148D6428C3F8FF6CD998F82090113C2B490B76E  get_oneVector_5() const { return ___oneVector_5; }
	inline Vector4_tD148D6428C3F8FF6CD998F82090113C2B490B76E * get_address_of_oneVector_5() { return &___oneVector_5; }
	inline void set_oneVector_5(Vector4_tD148D6428C3F8FF6CD998F82090113C2B490B76E  value)
	{
		___oneVector_5 = value;
	}

	inline static int32_t get_offset_of_positiveInfinityVector_6() { return static_cast<int32_t>(offsetof(Vector4_tD148D6428C3F8FF6CD998F82090113C2B490B76E_StaticFields, ___positiveInfinityVector_6)); }
	inline Vector4_tD148D6428C3F8FF6CD998F82090113C2B490B76E  get_positiveInfinityVector_6() const { return ___positiveInfinityVector_6; }
	inline Vector4_tD148D6428C3F8FF6CD998F82090113C2B490B76E * get_address_of_positiveInfinityVector_6() { return &___positiveInfinityVector_6; }
	inline void set_positiveInfinityVector_6(Vector4_tD148D6428C3F8FF6CD998F82090113C2B490B76E  value)
	{
		___positiveInfinityVector_6 = value;
	}

	inline static int32_t get_offset_of_negativeInfinityVector_7() { return static_cast<int32_t>(offsetof(Vector4_tD148D6428C3F8FF6CD998F82090113C2B490B76E_StaticFields, ___negativeInfinityVector_7)); }
	inline Vector4_tD148D6428C3F8FF6CD998F82090113C2B490B76E  get_negativeInfinityVector_7() const { return ___negativeInfinityVector_7; }
	inline Vector4_tD148D6428C3F8FF6CD998F82090113C2B490B76E * get_address_of_negativeInfinityVector_7() { return &___negativeInfinityVector_7; }
	inline void set_negativeInfinityVector_7(Vector4_tD148D6428C3F8FF6CD998F82090113C2B490B76E  value)
	{
		___negativeInfinityVector_7 = value;
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
#endif // VECTOR4_TD148D6428C3F8FF6CD998F82090113C2B490B76E_H
#ifndef WWW_TA50AFB5DE276783409B4CE88FE9B772322EE5664_H
#define WWW_TA50AFB5DE276783409B4CE88FE9B772322EE5664_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// UnityEngine.WWW
struct  WWW_tA50AFB5DE276783409B4CE88FE9B772322EE5664  : public CustomYieldInstruction_t819BB0973AFF22766749FF087B8AEFEAF3C2CB7D
{
public:
	// UnityEngine.Networking.UnityWebRequest UnityEngine.WWW::_uwr
	UnityWebRequest_t9120F5A2C7D43B936B49C0B7E4CA54C822689129 * ____uwr_0;

public:
	inline static int32_t get_offset_of__uwr_0() { return static_cast<int32_t>(offsetof(WWW_tA50AFB5DE276783409B4CE88FE9B772322EE5664, ____uwr_0)); }
	inline UnityWebRequest_t9120F5A2C7D43B936B49C0B7E4CA54C822689129 * get__uwr_0() const { return ____uwr_0; }
	inline UnityWebRequest_t9120F5A2C7D43B936B49C0B7E4CA54C822689129 ** get_address_of__uwr_0() { return &____uwr_0; }
	inline void set__uwr_0(UnityWebRequest_t9120F5A2C7D43B936B49C0B7E4CA54C822689129 * value)
	{
		____uwr_0 = value;
		Il2CppCodeGenWriteBarrier((&____uwr_0), value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
#endif // WWW_TA50AFB5DE276783409B4CE88FE9B772322EE5664_H
#ifndef WAITFORENDOFFRAME_T75980FB3F246D6AD36A85CA2BFDF8474E5EEBCCA_H
#define WAITFORENDOFFRAME_T75980FB3F246D6AD36A85CA2BFDF8474E5EEBCCA_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// UnityEngine.WaitForEndOfFrame
struct  WaitForEndOfFrame_t75980FB3F246D6AD36A85CA2BFDF8474E5EEBCCA  : public YieldInstruction_t836035AC7BD07A3C7909F7AD2A5B42DE99D91C44
{
public:

public:
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
#endif // WAITFORENDOFFRAME_T75980FB3F246D6AD36A85CA2BFDF8474E5EEBCCA_H
#ifndef DELEGATE_T_H
#define DELEGATE_T_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// System.Delegate
struct  Delegate_t  : public RuntimeObject
{
public:
	// System.IntPtr System.Delegate::method_ptr
	Il2CppMethodPointer ___method_ptr_0;
	// System.IntPtr System.Delegate::invoke_impl
	intptr_t ___invoke_impl_1;
	// System.Object System.Delegate::m_target
	RuntimeObject * ___m_target_2;
	// System.IntPtr System.Delegate::method
	intptr_t ___method_3;
	// System.IntPtr System.Delegate::delegate_trampoline
	intptr_t ___delegate_trampoline_4;
	// System.IntPtr System.Delegate::extra_arg
	intptr_t ___extra_arg_5;
	// System.IntPtr System.Delegate::method_code
	intptr_t ___method_code_6;
	// System.Reflection.MethodInfo System.Delegate::method_info
	MethodInfo_t * ___method_info_7;
	// System.Reflection.MethodInfo System.Delegate::original_method_info
	MethodInfo_t * ___original_method_info_8;
	// System.DelegateData System.Delegate::data
	DelegateData_t1BF9F691B56DAE5F8C28C5E084FDE94F15F27BBE * ___data_9;
	// System.Boolean System.Delegate::method_is_virtual
	bool ___method_is_virtual_10;

public:
	inline static int32_t get_offset_of_method_ptr_0() { return static_cast<int32_t>(offsetof(Delegate_t, ___method_ptr_0)); }
	inline Il2CppMethodPointer get_method_ptr_0() const { return ___method_ptr_0; }
	inline Il2CppMethodPointer* get_address_of_method_ptr_0() { return &___method_ptr_0; }
	inline void set_method_ptr_0(Il2CppMethodPointer value)
	{
		___method_ptr_0 = value;
	}

	inline static int32_t get_offset_of_invoke_impl_1() { return static_cast<int32_t>(offsetof(Delegate_t, ___invoke_impl_1)); }
	inline intptr_t get_invoke_impl_1() const { return ___invoke_impl_1; }
	inline intptr_t* get_address_of_invoke_impl_1() { return &___invoke_impl_1; }
	inline void set_invoke_impl_1(intptr_t value)
	{
		___invoke_impl_1 = value;
	}

	inline static int32_t get_offset_of_m_target_2() { return static_cast<int32_t>(offsetof(Delegate_t, ___m_target_2)); }
	inline RuntimeObject * get_m_target_2() const { return ___m_target_2; }
	inline RuntimeObject ** get_address_of_m_target_2() { return &___m_target_2; }
	inline void set_m_target_2(RuntimeObject * value)
	{
		___m_target_2 = value;
		Il2CppCodeGenWriteBarrier((&___m_target_2), value);
	}

	inline static int32_t get_offset_of_method_3() { return static_cast<int32_t>(offsetof(Delegate_t, ___method_3)); }
	inline intptr_t get_method_3() const { return ___method_3; }
	inline intptr_t* get_address_of_method_3() { return &___method_3; }
	inline void set_method_3(intptr_t value)
	{
		___method_3 = value;
	}

	inline static int32_t get_offset_of_delegate_trampoline_4() { return static_cast<int32_t>(offsetof(Delegate_t, ___delegate_trampoline_4)); }
	inline intptr_t get_delegate_trampoline_4() const { return ___delegate_trampoline_4; }
	inline intptr_t* get_address_of_delegate_trampoline_4() { return &___delegate_trampoline_4; }
	inline void set_delegate_trampoline_4(intptr_t value)
	{
		___delegate_trampoline_4 = value;
	}

	inline static int32_t get_offset_of_extra_arg_5() { return static_cast<int32_t>(offsetof(Delegate_t, ___extra_arg_5)); }
	inline intptr_t get_extra_arg_5() const { return ___extra_arg_5; }
	inline intptr_t* get_address_of_extra_arg_5() { return &___extra_arg_5; }
	inline void set_extra_arg_5(intptr_t value)
	{
		___extra_arg_5 = value;
	}

	inline static int32_t get_offset_of_method_code_6() { return static_cast<int32_t>(offsetof(Delegate_t, ___method_code_6)); }
	inline intptr_t get_method_code_6() const { return ___method_code_6; }
	inline intptr_t* get_address_of_method_code_6() { return &___method_code_6; }
	inline void set_method_code_6(intptr_t value)
	{
		___method_code_6 = value;
	}

	inline static int32_t get_offset_of_method_info_7() { return static_cast<int32_t>(offsetof(Delegate_t, ___method_info_7)); }
	inline MethodInfo_t * get_method_info_7() const { return ___method_info_7; }
	inline MethodInfo_t ** get_address_of_method_info_7() { return &___method_info_7; }
	inline void set_method_info_7(MethodInfo_t * value)
	{
		___method_info_7 = value;
		Il2CppCodeGenWriteBarrier((&___method_info_7), value);
	}

	inline static int32_t get_offset_of_original_method_info_8() { return static_cast<int32_t>(offsetof(Delegate_t, ___original_method_info_8)); }
	inline MethodInfo_t * get_original_method_info_8() const { return ___original_method_info_8; }
	inline MethodInfo_t ** get_address_of_original_method_info_8() { return &___original_method_info_8; }
	inline void set_original_method_info_8(MethodInfo_t * value)
	{
		___original_method_info_8 = value;
		Il2CppCodeGenWriteBarrier((&___original_method_info_8), value);
	}

	inline static int32_t get_offset_of_data_9() { return static_cast<int32_t>(offsetof(Delegate_t, ___data_9)); }
	inline DelegateData_t1BF9F691B56DAE5F8C28C5E084FDE94F15F27BBE * get_data_9() const { return ___data_9; }
	inline DelegateData_t1BF9F691B56DAE5F8C28C5E084FDE94F15F27BBE ** get_address_of_data_9() { return &___data_9; }
	inline void set_data_9(DelegateData_t1BF9F691B56DAE5F8C28C5E084FDE94F15F27BBE * value)
	{
		___data_9 = value;
		Il2CppCodeGenWriteBarrier((&___data_9), value);
	}

	inline static int32_t get_offset_of_method_is_virtual_10() { return static_cast<int32_t>(offsetof(Delegate_t, ___method_is_virtual_10)); }
	inline bool get_method_is_virtual_10() const { return ___method_is_virtual_10; }
	inline bool* get_address_of_method_is_virtual_10() { return &___method_is_virtual_10; }
	inline void set_method_is_virtual_10(bool value)
	{
		___method_is_virtual_10 = value;
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
// Native definition for P/Invoke marshalling of System.Delegate
struct Delegate_t_marshaled_pinvoke
{
	intptr_t ___method_ptr_0;
	intptr_t ___invoke_impl_1;
	Il2CppIUnknown* ___m_target_2;
	intptr_t ___method_3;
	intptr_t ___delegate_trampoline_4;
	intptr_t ___extra_arg_5;
	intptr_t ___method_code_6;
	MethodInfo_t * ___method_info_7;
	MethodInfo_t * ___original_method_info_8;
	DelegateData_t1BF9F691B56DAE5F8C28C5E084FDE94F15F27BBE * ___data_9;
	int32_t ___method_is_virtual_10;
};
// Native definition for COM marshalling of System.Delegate
struct Delegate_t_marshaled_com
{
	intptr_t ___method_ptr_0;
	intptr_t ___invoke_impl_1;
	Il2CppIUnknown* ___m_target_2;
	intptr_t ___method_3;
	intptr_t ___delegate_trampoline_4;
	intptr_t ___extra_arg_5;
	intptr_t ___method_code_6;
	MethodInfo_t * ___method_info_7;
	MethodInfo_t * ___original_method_info_8;
	DelegateData_t1BF9F691B56DAE5F8C28C5E084FDE94F15F27BBE * ___data_9;
	int32_t ___method_is_virtual_10;
};
#endif // DELEGATE_T_H
#ifndef FILEATTRIBUTES_T224B42F6F82954C94B51791913857C005C559876_H
#define FILEATTRIBUTES_T224B42F6F82954C94B51791913857C005C559876_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// System.IO.FileAttributes
struct  FileAttributes_t224B42F6F82954C94B51791913857C005C559876 
{
public:
	// System.Int32 System.IO.FileAttributes::value__
	int32_t ___value___2;

public:
	inline static int32_t get_offset_of_value___2() { return static_cast<int32_t>(offsetof(FileAttributes_t224B42F6F82954C94B51791913857C005C559876, ___value___2)); }
	inline int32_t get_value___2() const { return ___value___2; }
	inline int32_t* get_address_of_value___2() { return &___value___2; }
	inline void set_value___2(int32_t value)
	{
		___value___2 = value;
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
#endif // FILEATTRIBUTES_T224B42F6F82954C94B51791913857C005C559876_H
#ifndef NOTSUPPORTEDEXCEPTION_TE75B318D6590A02A5D9B29FD97409B1750FA0010_H
#define NOTSUPPORTEDEXCEPTION_TE75B318D6590A02A5D9B29FD97409B1750FA0010_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// System.NotSupportedException
struct  NotSupportedException_tE75B318D6590A02A5D9B29FD97409B1750FA0010  : public SystemException_t5380468142AA850BE4A341D7AF3EAB9C78746782
{
public:

public:
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
#endif // NOTSUPPORTEDEXCEPTION_TE75B318D6590A02A5D9B29FD97409B1750FA0010_H
#ifndef COROUTINE_TAE7DB2FC70A0AE6477F896F852057CB0754F06EC_H
#define COROUTINE_TAE7DB2FC70A0AE6477F896F852057CB0754F06EC_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// UnityEngine.Coroutine
struct  Coroutine_tAE7DB2FC70A0AE6477F896F852057CB0754F06EC  : public YieldInstruction_t836035AC7BD07A3C7909F7AD2A5B42DE99D91C44
{
public:
	// System.IntPtr UnityEngine.Coroutine::m_Ptr
	intptr_t ___m_Ptr_0;

public:
	inline static int32_t get_offset_of_m_Ptr_0() { return static_cast<int32_t>(offsetof(Coroutine_tAE7DB2FC70A0AE6477F896F852057CB0754F06EC, ___m_Ptr_0)); }
	inline intptr_t get_m_Ptr_0() const { return ___m_Ptr_0; }
	inline intptr_t* get_address_of_m_Ptr_0() { return &___m_Ptr_0; }
	inline void set_m_Ptr_0(intptr_t value)
	{
		___m_Ptr_0 = value;
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
// Native definition for P/Invoke marshalling of UnityEngine.Coroutine
struct Coroutine_tAE7DB2FC70A0AE6477F896F852057CB0754F06EC_marshaled_pinvoke : public YieldInstruction_t836035AC7BD07A3C7909F7AD2A5B42DE99D91C44_marshaled_pinvoke
{
	intptr_t ___m_Ptr_0;
};
// Native definition for COM marshalling of UnityEngine.Coroutine
struct Coroutine_tAE7DB2FC70A0AE6477F896F852057CB0754F06EC_marshaled_com : public YieldInstruction_t836035AC7BD07A3C7909F7AD2A5B42DE99D91C44_marshaled_com
{
	intptr_t ___m_Ptr_0;
};
#endif // COROUTINE_TAE7DB2FC70A0AE6477F896F852057CB0754F06EC_H
#ifndef FILTERMODE_T6590B4B0BAE2BBBCABA8E1E93FA07A052B3261AF_H
#define FILTERMODE_T6590B4B0BAE2BBBCABA8E1E93FA07A052B3261AF_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// UnityEngine.FilterMode
struct  FilterMode_t6590B4B0BAE2BBBCABA8E1E93FA07A052B3261AF 
{
public:
	// System.Int32 UnityEngine.FilterMode::value__
	int32_t ___value___2;

public:
	inline static int32_t get_offset_of_value___2() { return static_cast<int32_t>(offsetof(FilterMode_t6590B4B0BAE2BBBCABA8E1E93FA07A052B3261AF, ___value___2)); }
	inline int32_t get_value___2() const { return ___value___2; }
	inline int32_t* get_address_of_value___2() { return &___value___2; }
	inline void set_value___2(int32_t value)
	{
		___value___2 = value;
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
#endif // FILTERMODE_T6590B4B0BAE2BBBCABA8E1E93FA07A052B3261AF_H
#ifndef KEYCODE_TC93EA87C5A6901160B583ADFCD3EF6726570DC3C_H
#define KEYCODE_TC93EA87C5A6901160B583ADFCD3EF6726570DC3C_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// UnityEngine.KeyCode
struct  KeyCode_tC93EA87C5A6901160B583ADFCD3EF6726570DC3C 
{
public:
	// System.Int32 UnityEngine.KeyCode::value__
	int32_t ___value___2;

public:
	inline static int32_t get_offset_of_value___2() { return static_cast<int32_t>(offsetof(KeyCode_tC93EA87C5A6901160B583ADFCD3EF6726570DC3C, ___value___2)); }
	inline int32_t get_value___2() const { return ___value___2; }
	inline int32_t* get_address_of_value___2() { return &___value___2; }
	inline void set_value___2(int32_t value)
	{
		___value___2 = value;
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
#endif // KEYCODE_TC93EA87C5A6901160B583ADFCD3EF6726570DC3C_H
#ifndef OBJECT_TAE11E5E46CD5C37C9F3E8950C00CD8B45666A2D0_H
#define OBJECT_TAE11E5E46CD5C37C9F3E8950C00CD8B45666A2D0_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// UnityEngine.Object
struct  Object_tAE11E5E46CD5C37C9F3E8950C00CD8B45666A2D0  : public RuntimeObject
{
public:
	// System.IntPtr UnityEngine.Object::m_CachedPtr
	intptr_t ___m_CachedPtr_0;

public:
	inline static int32_t get_offset_of_m_CachedPtr_0() { return static_cast<int32_t>(offsetof(Object_tAE11E5E46CD5C37C9F3E8950C00CD8B45666A2D0, ___m_CachedPtr_0)); }
	inline intptr_t get_m_CachedPtr_0() const { return ___m_CachedPtr_0; }
	inline intptr_t* get_address_of_m_CachedPtr_0() { return &___m_CachedPtr_0; }
	inline void set_m_CachedPtr_0(intptr_t value)
	{
		___m_CachedPtr_0 = value;
	}
};

struct Object_tAE11E5E46CD5C37C9F3E8950C00CD8B45666A2D0_StaticFields
{
public:
	// System.Int32 UnityEngine.Object::OffsetOfInstanceIDInCPlusPlusObject
	int32_t ___OffsetOfInstanceIDInCPlusPlusObject_1;

public:
	inline static int32_t get_offset_of_OffsetOfInstanceIDInCPlusPlusObject_1() { return static_cast<int32_t>(offsetof(Object_tAE11E5E46CD5C37C9F3E8950C00CD8B45666A2D0_StaticFields, ___OffsetOfInstanceIDInCPlusPlusObject_1)); }
	inline int32_t get_OffsetOfInstanceIDInCPlusPlusObject_1() const { return ___OffsetOfInstanceIDInCPlusPlusObject_1; }
	inline int32_t* get_address_of_OffsetOfInstanceIDInCPlusPlusObject_1() { return &___OffsetOfInstanceIDInCPlusPlusObject_1; }
	inline void set_OffsetOfInstanceIDInCPlusPlusObject_1(int32_t value)
	{
		___OffsetOfInstanceIDInCPlusPlusObject_1 = value;
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
// Native definition for P/Invoke marshalling of UnityEngine.Object
struct Object_tAE11E5E46CD5C37C9F3E8950C00CD8B45666A2D0_marshaled_pinvoke
{
	intptr_t ___m_CachedPtr_0;
};
// Native definition for COM marshalling of UnityEngine.Object
struct Object_tAE11E5E46CD5C37C9F3E8950C00CD8B45666A2D0_marshaled_com
{
	intptr_t ___m_CachedPtr_0;
};
#endif // OBJECT_TAE11E5E46CD5C37C9F3E8950C00CD8B45666A2D0_H
#ifndef RAYCASTHIT_T19695F18F9265FE5425062BBA6A4D330480538C3_H
#define RAYCASTHIT_T19695F18F9265FE5425062BBA6A4D330480538C3_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// UnityEngine.RaycastHit
struct  RaycastHit_t19695F18F9265FE5425062BBA6A4D330480538C3 
{
public:
	// UnityEngine.Vector3 UnityEngine.RaycastHit::m_Point
	Vector3_tDCF05E21F632FE2BA260C06E0D10CA81513E6720  ___m_Point_0;
	// UnityEngine.Vector3 UnityEngine.RaycastHit::m_Normal
	Vector3_tDCF05E21F632FE2BA260C06E0D10CA81513E6720  ___m_Normal_1;
	// System.UInt32 UnityEngine.RaycastHit::m_FaceID
	uint32_t ___m_FaceID_2;
	// System.Single UnityEngine.RaycastHit::m_Distance
	float ___m_Distance_3;
	// UnityEngine.Vector2 UnityEngine.RaycastHit::m_UV
	Vector2_tA85D2DD88578276CA8A8796756458277E72D073D  ___m_UV_4;
	// System.Int32 UnityEngine.RaycastHit::m_Collider
	int32_t ___m_Collider_5;

public:
	inline static int32_t get_offset_of_m_Point_0() { return static_cast<int32_t>(offsetof(RaycastHit_t19695F18F9265FE5425062BBA6A4D330480538C3, ___m_Point_0)); }
	inline Vector3_tDCF05E21F632FE2BA260C06E0D10CA81513E6720  get_m_Point_0() const { return ___m_Point_0; }
	inline Vector3_tDCF05E21F632FE2BA260C06E0D10CA81513E6720 * get_address_of_m_Point_0() { return &___m_Point_0; }
	inline void set_m_Point_0(Vector3_tDCF05E21F632FE2BA260C06E0D10CA81513E6720  value)
	{
		___m_Point_0 = value;
	}

	inline static int32_t get_offset_of_m_Normal_1() { return static_cast<int32_t>(offsetof(RaycastHit_t19695F18F9265FE5425062BBA6A4D330480538C3, ___m_Normal_1)); }
	inline Vector3_tDCF05E21F632FE2BA260C06E0D10CA81513E6720  get_m_Normal_1() const { return ___m_Normal_1; }
	inline Vector3_tDCF05E21F632FE2BA260C06E0D10CA81513E6720 * get_address_of_m_Normal_1() { return &___m_Normal_1; }
	inline void set_m_Normal_1(Vector3_tDCF05E21F632FE2BA260C06E0D10CA81513E6720  value)
	{
		___m_Normal_1 = value;
	}

	inline static int32_t get_offset_of_m_FaceID_2() { return static_cast<int32_t>(offsetof(RaycastHit_t19695F18F9265FE5425062BBA6A4D330480538C3, ___m_FaceID_2)); }
	inline uint32_t get_m_FaceID_2() const { return ___m_FaceID_2; }
	inline uint32_t* get_address_of_m_FaceID_2() { return &___m_FaceID_2; }
	inline void set_m_FaceID_2(uint32_t value)
	{
		___m_FaceID_2 = value;
	}

	inline static int32_t get_offset_of_m_Distance_3() { return static_cast<int32_t>(offsetof(RaycastHit_t19695F18F9265FE5425062BBA6A4D330480538C3, ___m_Distance_3)); }
	inline float get_m_Distance_3() const { return ___m_Distance_3; }
	inline float* get_address_of_m_Distance_3() { return &___m_Distance_3; }
	inline void set_m_Distance_3(float value)
	{
		___m_Distance_3 = value;
	}

	inline static int32_t get_offset_of_m_UV_4() { return static_cast<int32_t>(offsetof(RaycastHit_t19695F18F9265FE5425062BBA6A4D330480538C3, ___m_UV_4)); }
	inline Vector2_tA85D2DD88578276CA8A8796756458277E72D073D  get_m_UV_4() const { return ___m_UV_4; }
	inline Vector2_tA85D2DD88578276CA8A8796756458277E72D073D * get_address_of_m_UV_4() { return &___m_UV_4; }
	inline void set_m_UV_4(Vector2_tA85D2DD88578276CA8A8796756458277E72D073D  value)
	{
		___m_UV_4 = value;
	}

	inline static int32_t get_offset_of_m_Collider_5() { return static_cast<int32_t>(offsetof(RaycastHit_t19695F18F9265FE5425062BBA6A4D330480538C3, ___m_Collider_5)); }
	inline int32_t get_m_Collider_5() const { return ___m_Collider_5; }
	inline int32_t* get_address_of_m_Collider_5() { return &___m_Collider_5; }
	inline void set_m_Collider_5(int32_t value)
	{
		___m_Collider_5 = value;
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
#endif // RAYCASTHIT_T19695F18F9265FE5425062BBA6A4D330480538C3_H
#ifndef TOUCHPHASE_TD902305F0B673116C42548A58E8BEED50177A33D_H
#define TOUCHPHASE_TD902305F0B673116C42548A58E8BEED50177A33D_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// UnityEngine.TouchPhase
struct  TouchPhase_tD902305F0B673116C42548A58E8BEED50177A33D 
{
public:
	// System.Int32 UnityEngine.TouchPhase::value__
	int32_t ___value___2;

public:
	inline static int32_t get_offset_of_value___2() { return static_cast<int32_t>(offsetof(TouchPhase_tD902305F0B673116C42548A58E8BEED50177A33D, ___value___2)); }
	inline int32_t get_value___2() const { return ___value___2; }
	inline int32_t* get_address_of_value___2() { return &___value___2; }
	inline void set_value___2(int32_t value)
	{
		___value___2 = value;
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
#endif // TOUCHPHASE_TD902305F0B673116C42548A58E8BEED50177A33D_H
#ifndef TOUCHTYPE_T27DBEAB2242247A15EDE96D740F7EB73ACC938DB_H
#define TOUCHTYPE_T27DBEAB2242247A15EDE96D740F7EB73ACC938DB_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// UnityEngine.TouchType
struct  TouchType_t27DBEAB2242247A15EDE96D740F7EB73ACC938DB 
{
public:
	// System.Int32 UnityEngine.TouchType::value__
	int32_t ___value___2;

public:
	inline static int32_t get_offset_of_value___2() { return static_cast<int32_t>(offsetof(TouchType_t27DBEAB2242247A15EDE96D740F7EB73ACC938DB, ___value___2)); }
	inline int32_t get_value___2() const { return ___value___2; }
	inline int32_t* get_address_of_value___2() { return &___value___2; }
	inline void set_value___2(int32_t value)
	{
		___value___2 = value;
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
#endif // TOUCHTYPE_T27DBEAB2242247A15EDE96D740F7EB73ACC938DB_H
#ifndef COLORBLOCK_T93B54DF6E8D65D24CEA9726CA745E48C53E3B1EA_H
#define COLORBLOCK_T93B54DF6E8D65D24CEA9726CA745E48C53E3B1EA_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// UnityEngine.UI.ColorBlock
struct  ColorBlock_t93B54DF6E8D65D24CEA9726CA745E48C53E3B1EA 
{
public:
	// UnityEngine.Color UnityEngine.UI.ColorBlock::m_NormalColor
	Color_t119BCA590009762C7223FDD3AF9706653AC84ED2  ___m_NormalColor_0;
	// UnityEngine.Color UnityEngine.UI.ColorBlock::m_HighlightedColor
	Color_t119BCA590009762C7223FDD3AF9706653AC84ED2  ___m_HighlightedColor_1;
	// UnityEngine.Color UnityEngine.UI.ColorBlock::m_PressedColor
	Color_t119BCA590009762C7223FDD3AF9706653AC84ED2  ___m_PressedColor_2;
	// UnityEngine.Color UnityEngine.UI.ColorBlock::m_DisabledColor
	Color_t119BCA590009762C7223FDD3AF9706653AC84ED2  ___m_DisabledColor_3;
	// System.Single UnityEngine.UI.ColorBlock::m_ColorMultiplier
	float ___m_ColorMultiplier_4;
	// System.Single UnityEngine.UI.ColorBlock::m_FadeDuration
	float ___m_FadeDuration_5;

public:
	inline static int32_t get_offset_of_m_NormalColor_0() { return static_cast<int32_t>(offsetof(ColorBlock_t93B54DF6E8D65D24CEA9726CA745E48C53E3B1EA, ___m_NormalColor_0)); }
	inline Color_t119BCA590009762C7223FDD3AF9706653AC84ED2  get_m_NormalColor_0() const { return ___m_NormalColor_0; }
	inline Color_t119BCA590009762C7223FDD3AF9706653AC84ED2 * get_address_of_m_NormalColor_0() { return &___m_NormalColor_0; }
	inline void set_m_NormalColor_0(Color_t119BCA590009762C7223FDD3AF9706653AC84ED2  value)
	{
		___m_NormalColor_0 = value;
	}

	inline static int32_t get_offset_of_m_HighlightedColor_1() { return static_cast<int32_t>(offsetof(ColorBlock_t93B54DF6E8D65D24CEA9726CA745E48C53E3B1EA, ___m_HighlightedColor_1)); }
	inline Color_t119BCA590009762C7223FDD3AF9706653AC84ED2  get_m_HighlightedColor_1() const { return ___m_HighlightedColor_1; }
	inline Color_t119BCA590009762C7223FDD3AF9706653AC84ED2 * get_address_of_m_HighlightedColor_1() { return &___m_HighlightedColor_1; }
	inline void set_m_HighlightedColor_1(Color_t119BCA590009762C7223FDD3AF9706653AC84ED2  value)
	{
		___m_HighlightedColor_1 = value;
	}

	inline static int32_t get_offset_of_m_PressedColor_2() { return static_cast<int32_t>(offsetof(ColorBlock_t93B54DF6E8D65D24CEA9726CA745E48C53E3B1EA, ___m_PressedColor_2)); }
	inline Color_t119BCA590009762C7223FDD3AF9706653AC84ED2  get_m_PressedColor_2() const { return ___m_PressedColor_2; }
	inline Color_t119BCA590009762C7223FDD3AF9706653AC84ED2 * get_address_of_m_PressedColor_2() { return &___m_PressedColor_2; }
	inline void set_m_PressedColor_2(Color_t119BCA590009762C7223FDD3AF9706653AC84ED2  value)
	{
		___m_PressedColor_2 = value;
	}

	inline static int32_t get_offset_of_m_DisabledColor_3() { return static_cast<int32_t>(offsetof(ColorBlock_t93B54DF6E8D65D24CEA9726CA745E48C53E3B1EA, ___m_DisabledColor_3)); }
	inline Color_t119BCA590009762C7223FDD3AF9706653AC84ED2  get_m_DisabledColor_3() const { return ___m_DisabledColor_3; }
	inline Color_t119BCA590009762C7223FDD3AF9706653AC84ED2 * get_address_of_m_DisabledColor_3() { return &___m_DisabledColor_3; }
	inline void set_m_DisabledColor_3(Color_t119BCA590009762C7223FDD3AF9706653AC84ED2  value)
	{
		___m_DisabledColor_3 = value;
	}

	inline static int32_t get_offset_of_m_ColorMultiplier_4() { return static_cast<int32_t>(offsetof(ColorBlock_t93B54DF6E8D65D24CEA9726CA745E48C53E3B1EA, ___m_ColorMultiplier_4)); }
	inline float get_m_ColorMultiplier_4() const { return ___m_ColorMultiplier_4; }
	inline float* get_address_of_m_ColorMultiplier_4() { return &___m_ColorMultiplier_4; }
	inline void set_m_ColorMultiplier_4(float value)
	{
		___m_ColorMultiplier_4 = value;
	}

	inline static int32_t get_offset_of_m_FadeDuration_5() { return static_cast<int32_t>(offsetof(ColorBlock_t93B54DF6E8D65D24CEA9726CA745E48C53E3B1EA, ___m_FadeDuration_5)); }
	inline float get_m_FadeDuration_5() const { return ___m_FadeDuration_5; }
	inline float* get_address_of_m_FadeDuration_5() { return &___m_FadeDuration_5; }
	inline void set_m_FadeDuration_5(float value)
	{
		___m_FadeDuration_5 = value;
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
#endif // COLORBLOCK_T93B54DF6E8D65D24CEA9726CA745E48C53E3B1EA_H
#ifndef MODE_T93F92BD50B147AE38D82BA33FA77FD247A59FE26_H
#define MODE_T93F92BD50B147AE38D82BA33FA77FD247A59FE26_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// UnityEngine.UI.Navigation/Mode
struct  Mode_t93F92BD50B147AE38D82BA33FA77FD247A59FE26 
{
public:
	// System.Int32 UnityEngine.UI.Navigation/Mode::value__
	int32_t ___value___2;

public:
	inline static int32_t get_offset_of_value___2() { return static_cast<int32_t>(offsetof(Mode_t93F92BD50B147AE38D82BA33FA77FD247A59FE26, ___value___2)); }
	inline int32_t get_value___2() const { return ___value___2; }
	inline int32_t* get_address_of_value___2() { return &___value___2; }
	inline void set_value___2(int32_t value)
	{
		___value___2 = value;
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
#endif // MODE_T93F92BD50B147AE38D82BA33FA77FD247A59FE26_H
#ifndef SELECTIONSTATE_TF089B96B46A592693753CBF23C52A3887632D210_H
#define SELECTIONSTATE_TF089B96B46A592693753CBF23C52A3887632D210_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// UnityEngine.UI.Selectable/SelectionState
struct  SelectionState_tF089B96B46A592693753CBF23C52A3887632D210 
{
public:
	// System.Int32 UnityEngine.UI.Selectable/SelectionState::value__
	int32_t ___value___2;

public:
	inline static int32_t get_offset_of_value___2() { return static_cast<int32_t>(offsetof(SelectionState_tF089B96B46A592693753CBF23C52A3887632D210, ___value___2)); }
	inline int32_t get_value___2() const { return ___value___2; }
	inline int32_t* get_address_of_value___2() { return &___value___2; }
	inline void set_value___2(int32_t value)
	{
		___value___2 = value;
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
#endif // SELECTIONSTATE_TF089B96B46A592693753CBF23C52A3887632D210_H
#ifndef TRANSITION_TA9261C608B54C52324084A0B080E7A3E0548A181_H
#define TRANSITION_TA9261C608B54C52324084A0B080E7A3E0548A181_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// UnityEngine.UI.Selectable/Transition
struct  Transition_tA9261C608B54C52324084A0B080E7A3E0548A181 
{
public:
	// System.Int32 UnityEngine.UI.Selectable/Transition::value__
	int32_t ___value___2;

public:
	inline static int32_t get_offset_of_value___2() { return static_cast<int32_t>(offsetof(Transition_tA9261C608B54C52324084A0B080E7A3E0548A181, ___value___2)); }
	inline int32_t get_value___2() const { return ___value___2; }
	inline int32_t* get_address_of_value___2() { return &___value___2; }
	inline void set_value___2(int32_t value)
	{
		___value___2 = value;
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
#endif // TRANSITION_TA9261C608B54C52324084A0B080E7A3E0548A181_H
#ifndef TOGGLEEVENT_T50D925F8E220FB47DA738411CEF9C57FF7E1DC43_H
#define TOGGLEEVENT_T50D925F8E220FB47DA738411CEF9C57FF7E1DC43_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// UnityEngine.UI.Toggle/ToggleEvent
struct  ToggleEvent_t50D925F8E220FB47DA738411CEF9C57FF7E1DC43  : public UnityEvent_1_t6FE5C79FD433599728A9AA732E588823AB88FDB5
{
public:

public:
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
#endif // TOGGLEEVENT_T50D925F8E220FB47DA738411CEF9C57FF7E1DC43_H
#ifndef TOGGLETRANSITION_T45980EB1352FF47B2D8D8EBC90385AB68939046D_H
#define TOGGLETRANSITION_T45980EB1352FF47B2D8D8EBC90385AB68939046D_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// UnityEngine.UI.Toggle/ToggleTransition
struct  ToggleTransition_t45980EB1352FF47B2D8D8EBC90385AB68939046D 
{
public:
	// System.Int32 UnityEngine.UI.Toggle/ToggleTransition::value__
	int32_t ___value___2;

public:
	inline static int32_t get_offset_of_value___2() { return static_cast<int32_t>(offsetof(ToggleTransition_t45980EB1352FF47B2D8D8EBC90385AB68939046D, ___value___2)); }
	inline int32_t get_value___2() const { return ___value___2; }
	inline int32_t* get_address_of_value___2() { return &___value___2; }
	inline void set_value___2(int32_t value)
	{
		___value___2 = value;
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
#endif // TOGGLETRANSITION_T45980EB1352FF47B2D8D8EBC90385AB68939046D_H
#ifndef DRAWMODE_TBAB7F60CE40C56283E6F6721DA9E6CB319A4084F_H
#define DRAWMODE_TBAB7F60CE40C56283E6F6721DA9E6CB319A4084F_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// unitycoder_MobilePaint.DrawMode
struct  DrawMode_tBAB7F60CE40C56283E6F6721DA9E6CB319A4084F 
{
public:
	// System.Int32 unitycoder_MobilePaint.DrawMode::value__
	int32_t ___value___2;

public:
	inline static int32_t get_offset_of_value___2() { return static_cast<int32_t>(offsetof(DrawMode_tBAB7F60CE40C56283E6F6721DA9E6CB319A4084F, ___value___2)); }
	inline int32_t get_value___2() const { return ___value___2; }
	inline int32_t* get_address_of_value___2() { return &___value___2; }
	inline void set_value___2(int32_t value)
	{
		___value___2 = value;
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
#endif // DRAWMODE_TBAB7F60CE40C56283E6F6721DA9E6CB319A4084F_H
#ifndef ERASERMODE_TFF53041A2F884982E793659ACA38B2183CFCDE60_H
#define ERASERMODE_TFF53041A2F884982E793659ACA38B2183CFCDE60_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// unitycoder_MobilePaint.EraserMode
struct  EraserMode_tFF53041A2F884982E793659ACA38B2183CFCDE60 
{
public:
	// System.Int32 unitycoder_MobilePaint.EraserMode::value__
	int32_t ___value___2;

public:
	inline static int32_t get_offset_of_value___2() { return static_cast<int32_t>(offsetof(EraserMode_tFF53041A2F884982E793659ACA38B2183CFCDE60, ___value___2)); }
	inline int32_t get_value___2() const { return ___value___2; }
	inline int32_t* get_address_of_value___2() { return &___value___2; }
	inline void set_value___2(int32_t value)
	{
		___value___2 = value;
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
#endif // ERASERMODE_TFF53041A2F884982E793659ACA38B2183CFCDE60_H
#ifndef MONOIOSTAT_T819C03DA1902AA493BDBF4B55E76DCE6FB16A124_H
#define MONOIOSTAT_T819C03DA1902AA493BDBF4B55E76DCE6FB16A124_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// System.IO.MonoIOStat
struct  MonoIOStat_t819C03DA1902AA493BDBF4B55E76DCE6FB16A124 
{
public:
	// System.IO.FileAttributes System.IO.MonoIOStat::fileAttributes
	int32_t ___fileAttributes_0;
	// System.Int64 System.IO.MonoIOStat::Length
	int64_t ___Length_1;
	// System.Int64 System.IO.MonoIOStat::CreationTime
	int64_t ___CreationTime_2;
	// System.Int64 System.IO.MonoIOStat::LastAccessTime
	int64_t ___LastAccessTime_3;
	// System.Int64 System.IO.MonoIOStat::LastWriteTime
	int64_t ___LastWriteTime_4;

public:
	inline static int32_t get_offset_of_fileAttributes_0() { return static_cast<int32_t>(offsetof(MonoIOStat_t819C03DA1902AA493BDBF4B55E76DCE6FB16A124, ___fileAttributes_0)); }
	inline int32_t get_fileAttributes_0() const { return ___fileAttributes_0; }
	inline int32_t* get_address_of_fileAttributes_0() { return &___fileAttributes_0; }
	inline void set_fileAttributes_0(int32_t value)
	{
		___fileAttributes_0 = value;
	}

	inline static int32_t get_offset_of_Length_1() { return static_cast<int32_t>(offsetof(MonoIOStat_t819C03DA1902AA493BDBF4B55E76DCE6FB16A124, ___Length_1)); }
	inline int64_t get_Length_1() const { return ___Length_1; }
	inline int64_t* get_address_of_Length_1() { return &___Length_1; }
	inline void set_Length_1(int64_t value)
	{
		___Length_1 = value;
	}

	inline static int32_t get_offset_of_CreationTime_2() { return static_cast<int32_t>(offsetof(MonoIOStat_t819C03DA1902AA493BDBF4B55E76DCE6FB16A124, ___CreationTime_2)); }
	inline int64_t get_CreationTime_2() const { return ___CreationTime_2; }
	inline int64_t* get_address_of_CreationTime_2() { return &___CreationTime_2; }
	inline void set_CreationTime_2(int64_t value)
	{
		___CreationTime_2 = value;
	}

	inline static int32_t get_offset_of_LastAccessTime_3() { return static_cast<int32_t>(offsetof(MonoIOStat_t819C03DA1902AA493BDBF4B55E76DCE6FB16A124, ___LastAccessTime_3)); }
	inline int64_t get_LastAccessTime_3() const { return ___LastAccessTime_3; }
	inline int64_t* get_address_of_LastAccessTime_3() { return &___LastAccessTime_3; }
	inline void set_LastAccessTime_3(int64_t value)
	{
		___LastAccessTime_3 = value;
	}

	inline static int32_t get_offset_of_LastWriteTime_4() { return static_cast<int32_t>(offsetof(MonoIOStat_t819C03DA1902AA493BDBF4B55E76DCE6FB16A124, ___LastWriteTime_4)); }
	inline int64_t get_LastWriteTime_4() const { return ___LastWriteTime_4; }
	inline int64_t* get_address_of_LastWriteTime_4() { return &___LastWriteTime_4; }
	inline void set_LastWriteTime_4(int64_t value)
	{
		___LastWriteTime_4 = value;
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
#endif // MONOIOSTAT_T819C03DA1902AA493BDBF4B55E76DCE6FB16A124_H
#ifndef MULTICASTDELEGATE_T_H
#define MULTICASTDELEGATE_T_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// System.MulticastDelegate
struct  MulticastDelegate_t  : public Delegate_t
{
public:
	// System.Delegate[] System.MulticastDelegate::delegates
	DelegateU5BU5D_tDFCDEE2A6322F96C0FE49AF47E9ADB8C4B294E86* ___delegates_11;

public:
	inline static int32_t get_offset_of_delegates_11() { return static_cast<int32_t>(offsetof(MulticastDelegate_t, ___delegates_11)); }
	inline DelegateU5BU5D_tDFCDEE2A6322F96C0FE49AF47E9ADB8C4B294E86* get_delegates_11() const { return ___delegates_11; }
	inline DelegateU5BU5D_tDFCDEE2A6322F96C0FE49AF47E9ADB8C4B294E86** get_address_of_delegates_11() { return &___delegates_11; }
	inline void set_delegates_11(DelegateU5BU5D_tDFCDEE2A6322F96C0FE49AF47E9ADB8C4B294E86* value)
	{
		___delegates_11 = value;
		Il2CppCodeGenWriteBarrier((&___delegates_11), value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
// Native definition for P/Invoke marshalling of System.MulticastDelegate
struct MulticastDelegate_t_marshaled_pinvoke : public Delegate_t_marshaled_pinvoke
{
	DelegateU5BU5D_tDFCDEE2A6322F96C0FE49AF47E9ADB8C4B294E86* ___delegates_11;
};
// Native definition for COM marshalling of System.MulticastDelegate
struct MulticastDelegate_t_marshaled_com : public Delegate_t_marshaled_com
{
	DelegateU5BU5D_tDFCDEE2A6322F96C0FE49AF47E9ADB8C4B294E86* ___delegates_11;
};
#endif // MULTICASTDELEGATE_T_H
#ifndef COMPONENT_T05064EF382ABCAF4B8C94F8A350EA85184C26621_H
#define COMPONENT_T05064EF382ABCAF4B8C94F8A350EA85184C26621_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// UnityEngine.Component
struct  Component_t05064EF382ABCAF4B8C94F8A350EA85184C26621  : public Object_tAE11E5E46CD5C37C9F3E8950C00CD8B45666A2D0
{
public:

public:
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
#endif // COMPONENT_T05064EF382ABCAF4B8C94F8A350EA85184C26621_H
#ifndef GAMEOBJECT_TBD1244AD56B4E59AAD76E5E7C9282EC5CE434F0F_H
#define GAMEOBJECT_TBD1244AD56B4E59AAD76E5E7C9282EC5CE434F0F_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// UnityEngine.GameObject
struct  GameObject_tBD1244AD56B4E59AAD76E5E7C9282EC5CE434F0F  : public Object_tAE11E5E46CD5C37C9F3E8950C00CD8B45666A2D0
{
public:

public:
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
#endif // GAMEOBJECT_TBD1244AD56B4E59AAD76E5E7C9282EC5CE434F0F_H
#ifndef MESH_T6106B8D8E4C691321581AB0445552EC78B947B8C_H
#define MESH_T6106B8D8E4C691321581AB0445552EC78B947B8C_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// UnityEngine.Mesh
struct  Mesh_t6106B8D8E4C691321581AB0445552EC78B947B8C  : public Object_tAE11E5E46CD5C37C9F3E8950C00CD8B45666A2D0
{
public:

public:
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
#endif // MESH_T6106B8D8E4C691321581AB0445552EC78B947B8C_H
#ifndef TEXTURE_T387FE83BB848001FD06B14707AEA6D5A0F6A95F4_H
#define TEXTURE_T387FE83BB848001FD06B14707AEA6D5A0F6A95F4_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// UnityEngine.Texture
struct  Texture_t387FE83BB848001FD06B14707AEA6D5A0F6A95F4  : public Object_tAE11E5E46CD5C37C9F3E8950C00CD8B45666A2D0
{
public:

public:
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
#endif // TEXTURE_T387FE83BB848001FD06B14707AEA6D5A0F6A95F4_H
#ifndef TOUCH_T806752C775BA713A91B6588A07CA98417CABC003_H
#define TOUCH_T806752C775BA713A91B6588A07CA98417CABC003_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// UnityEngine.Touch
struct  Touch_t806752C775BA713A91B6588A07CA98417CABC003 
{
public:
	// System.Int32 UnityEngine.Touch::m_FingerId
	int32_t ___m_FingerId_0;
	// UnityEngine.Vector2 UnityEngine.Touch::m_Position
	Vector2_tA85D2DD88578276CA8A8796756458277E72D073D  ___m_Position_1;
	// UnityEngine.Vector2 UnityEngine.Touch::m_RawPosition
	Vector2_tA85D2DD88578276CA8A8796756458277E72D073D  ___m_RawPosition_2;
	// UnityEngine.Vector2 UnityEngine.Touch::m_PositionDelta
	Vector2_tA85D2DD88578276CA8A8796756458277E72D073D  ___m_PositionDelta_3;
	// System.Single UnityEngine.Touch::m_TimeDelta
	float ___m_TimeDelta_4;
	// System.Int32 UnityEngine.Touch::m_TapCount
	int32_t ___m_TapCount_5;
	// UnityEngine.TouchPhase UnityEngine.Touch::m_Phase
	int32_t ___m_Phase_6;
	// UnityEngine.TouchType UnityEngine.Touch::m_Type
	int32_t ___m_Type_7;
	// System.Single UnityEngine.Touch::m_Pressure
	float ___m_Pressure_8;
	// System.Single UnityEngine.Touch::m_maximumPossiblePressure
	float ___m_maximumPossiblePressure_9;
	// System.Single UnityEngine.Touch::m_Radius
	float ___m_Radius_10;
	// System.Single UnityEngine.Touch::m_RadiusVariance
	float ___m_RadiusVariance_11;
	// System.Single UnityEngine.Touch::m_AltitudeAngle
	float ___m_AltitudeAngle_12;
	// System.Single UnityEngine.Touch::m_AzimuthAngle
	float ___m_AzimuthAngle_13;

public:
	inline static int32_t get_offset_of_m_FingerId_0() { return static_cast<int32_t>(offsetof(Touch_t806752C775BA713A91B6588A07CA98417CABC003, ___m_FingerId_0)); }
	inline int32_t get_m_FingerId_0() const { return ___m_FingerId_0; }
	inline int32_t* get_address_of_m_FingerId_0() { return &___m_FingerId_0; }
	inline void set_m_FingerId_0(int32_t value)
	{
		___m_FingerId_0 = value;
	}

	inline static int32_t get_offset_of_m_Position_1() { return static_cast<int32_t>(offsetof(Touch_t806752C775BA713A91B6588A07CA98417CABC003, ___m_Position_1)); }
	inline Vector2_tA85D2DD88578276CA8A8796756458277E72D073D  get_m_Position_1() const { return ___m_Position_1; }
	inline Vector2_tA85D2DD88578276CA8A8796756458277E72D073D * get_address_of_m_Position_1() { return &___m_Position_1; }
	inline void set_m_Position_1(Vector2_tA85D2DD88578276CA8A8796756458277E72D073D  value)
	{
		___m_Position_1 = value;
	}

	inline static int32_t get_offset_of_m_RawPosition_2() { return static_cast<int32_t>(offsetof(Touch_t806752C775BA713A91B6588A07CA98417CABC003, ___m_RawPosition_2)); }
	inline Vector2_tA85D2DD88578276CA8A8796756458277E72D073D  get_m_RawPosition_2() const { return ___m_RawPosition_2; }
	inline Vector2_tA85D2DD88578276CA8A8796756458277E72D073D * get_address_of_m_RawPosition_2() { return &___m_RawPosition_2; }
	inline void set_m_RawPosition_2(Vector2_tA85D2DD88578276CA8A8796756458277E72D073D  value)
	{
		___m_RawPosition_2 = value;
	}

	inline static int32_t get_offset_of_m_PositionDelta_3() { return static_cast<int32_t>(offsetof(Touch_t806752C775BA713A91B6588A07CA98417CABC003, ___m_PositionDelta_3)); }
	inline Vector2_tA85D2DD88578276CA8A8796756458277E72D073D  get_m_PositionDelta_3() const { return ___m_PositionDelta_3; }
	inline Vector2_tA85D2DD88578276CA8A8796756458277E72D073D * get_address_of_m_PositionDelta_3() { return &___m_PositionDelta_3; }
	inline void set_m_PositionDelta_3(Vector2_tA85D2DD88578276CA8A8796756458277E72D073D  value)
	{
		___m_PositionDelta_3 = value;
	}

	inline static int32_t get_offset_of_m_TimeDelta_4() { return static_cast<int32_t>(offsetof(Touch_t806752C775BA713A91B6588A07CA98417CABC003, ___m_TimeDelta_4)); }
	inline float get_m_TimeDelta_4() const { return ___m_TimeDelta_4; }
	inline float* get_address_of_m_TimeDelta_4() { return &___m_TimeDelta_4; }
	inline void set_m_TimeDelta_4(float value)
	{
		___m_TimeDelta_4 = value;
	}

	inline static int32_t get_offset_of_m_TapCount_5() { return static_cast<int32_t>(offsetof(Touch_t806752C775BA713A91B6588A07CA98417CABC003, ___m_TapCount_5)); }
	inline int32_t get_m_TapCount_5() const { return ___m_TapCount_5; }
	inline int32_t* get_address_of_m_TapCount_5() { return &___m_TapCount_5; }
	inline void set_m_TapCount_5(int32_t value)
	{
		___m_TapCount_5 = value;
	}

	inline static int32_t get_offset_of_m_Phase_6() { return static_cast<int32_t>(offsetof(Touch_t806752C775BA713A91B6588A07CA98417CABC003, ___m_Phase_6)); }
	inline int32_t get_m_Phase_6() const { return ___m_Phase_6; }
	inline int32_t* get_address_of_m_Phase_6() { return &___m_Phase_6; }
	inline void set_m_Phase_6(int32_t value)
	{
		___m_Phase_6 = value;
	}

	inline static int32_t get_offset_of_m_Type_7() { return static_cast<int32_t>(offsetof(Touch_t806752C775BA713A91B6588A07CA98417CABC003, ___m_Type_7)); }
	inline int32_t get_m_Type_7() const { return ___m_Type_7; }
	inline int32_t* get_address_of_m_Type_7() { return &___m_Type_7; }
	inline void set_m_Type_7(int32_t value)
	{
		___m_Type_7 = value;
	}

	inline static int32_t get_offset_of_m_Pressure_8() { return static_cast<int32_t>(offsetof(Touch_t806752C775BA713A91B6588A07CA98417CABC003, ___m_Pressure_8)); }
	inline float get_m_Pressure_8() const { return ___m_Pressure_8; }
	inline float* get_address_of_m_Pressure_8() { return &___m_Pressure_8; }
	inline void set_m_Pressure_8(float value)
	{
		___m_Pressure_8 = value;
	}

	inline static int32_t get_offset_of_m_maximumPossiblePressure_9() { return static_cast<int32_t>(offsetof(Touch_t806752C775BA713A91B6588A07CA98417CABC003, ___m_maximumPossiblePressure_9)); }
	inline float get_m_maximumPossiblePressure_9() const { return ___m_maximumPossiblePressure_9; }
	inline float* get_address_of_m_maximumPossiblePressure_9() { return &___m_maximumPossiblePressure_9; }
	inline void set_m_maximumPossiblePressure_9(float value)
	{
		___m_maximumPossiblePressure_9 = value;
	}

	inline static int32_t get_offset_of_m_Radius_10() { return static_cast<int32_t>(offsetof(Touch_t806752C775BA713A91B6588A07CA98417CABC003, ___m_Radius_10)); }
	inline float get_m_Radius_10() const { return ___m_Radius_10; }
	inline float* get_address_of_m_Radius_10() { return &___m_Radius_10; }
	inline void set_m_Radius_10(float value)
	{
		___m_Radius_10 = value;
	}

	inline static int32_t get_offset_of_m_RadiusVariance_11() { return static_cast<int32_t>(offsetof(Touch_t806752C775BA713A91B6588A07CA98417CABC003, ___m_RadiusVariance_11)); }
	inline float get_m_RadiusVariance_11() const { return ___m_RadiusVariance_11; }
	inline float* get_address_of_m_RadiusVariance_11() { return &___m_RadiusVariance_11; }
	inline void set_m_RadiusVariance_11(float value)
	{
		___m_RadiusVariance_11 = value;
	}

	inline static int32_t get_offset_of_m_AltitudeAngle_12() { return static_cast<int32_t>(offsetof(Touch_t806752C775BA713A91B6588A07CA98417CABC003, ___m_AltitudeAngle_12)); }
	inline float get_m_AltitudeAngle_12() const { return ___m_AltitudeAngle_12; }
	inline float* get_address_of_m_AltitudeAngle_12() { return &___m_AltitudeAngle_12; }
	inline void set_m_AltitudeAngle_12(float value)
	{
		___m_AltitudeAngle_12 = value;
	}

	inline static int32_t get_offset_of_m_AzimuthAngle_13() { return static_cast<int32_t>(offsetof(Touch_t806752C775BA713A91B6588A07CA98417CABC003, ___m_AzimuthAngle_13)); }
	inline float get_m_AzimuthAngle_13() const { return ___m_AzimuthAngle_13; }
	inline float* get_address_of_m_AzimuthAngle_13() { return &___m_AzimuthAngle_13; }
	inline void set_m_AzimuthAngle_13(float value)
	{
		___m_AzimuthAngle_13 = value;
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
#endif // TOUCH_T806752C775BA713A91B6588A07CA98417CABC003_H
#ifndef NAVIGATION_T761250C05C09773B75F5E0D52DDCBBFE60288A07_H
#define NAVIGATION_T761250C05C09773B75F5E0D52DDCBBFE60288A07_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// UnityEngine.UI.Navigation
struct  Navigation_t761250C05C09773B75F5E0D52DDCBBFE60288A07 
{
public:
	// UnityEngine.UI.Navigation/Mode UnityEngine.UI.Navigation::m_Mode
	int32_t ___m_Mode_0;
	// UnityEngine.UI.Selectable UnityEngine.UI.Navigation::m_SelectOnUp
	Selectable_tAA9065030FE0468018DEC880302F95FEA9C0133A * ___m_SelectOnUp_1;
	// UnityEngine.UI.Selectable UnityEngine.UI.Navigation::m_SelectOnDown
	Selectable_tAA9065030FE0468018DEC880302F95FEA9C0133A * ___m_SelectOnDown_2;
	// UnityEngine.UI.Selectable UnityEngine.UI.Navigation::m_SelectOnLeft
	Selectable_tAA9065030FE0468018DEC880302F95FEA9C0133A * ___m_SelectOnLeft_3;
	// UnityEngine.UI.Selectable UnityEngine.UI.Navigation::m_SelectOnRight
	Selectable_tAA9065030FE0468018DEC880302F95FEA9C0133A * ___m_SelectOnRight_4;

public:
	inline static int32_t get_offset_of_m_Mode_0() { return static_cast<int32_t>(offsetof(Navigation_t761250C05C09773B75F5E0D52DDCBBFE60288A07, ___m_Mode_0)); }
	inline int32_t get_m_Mode_0() const { return ___m_Mode_0; }
	inline int32_t* get_address_of_m_Mode_0() { return &___m_Mode_0; }
	inline void set_m_Mode_0(int32_t value)
	{
		___m_Mode_0 = value;
	}

	inline static int32_t get_offset_of_m_SelectOnUp_1() { return static_cast<int32_t>(offsetof(Navigation_t761250C05C09773B75F5E0D52DDCBBFE60288A07, ___m_SelectOnUp_1)); }
	inline Selectable_tAA9065030FE0468018DEC880302F95FEA9C0133A * get_m_SelectOnUp_1() const { return ___m_SelectOnUp_1; }
	inline Selectable_tAA9065030FE0468018DEC880302F95FEA9C0133A ** get_address_of_m_SelectOnUp_1() { return &___m_SelectOnUp_1; }
	inline void set_m_SelectOnUp_1(Selectable_tAA9065030FE0468018DEC880302F95FEA9C0133A * value)
	{
		___m_SelectOnUp_1 = value;
		Il2CppCodeGenWriteBarrier((&___m_SelectOnUp_1), value);
	}

	inline static int32_t get_offset_of_m_SelectOnDown_2() { return static_cast<int32_t>(offsetof(Navigation_t761250C05C09773B75F5E0D52DDCBBFE60288A07, ___m_SelectOnDown_2)); }
	inline Selectable_tAA9065030FE0468018DEC880302F95FEA9C0133A * get_m_SelectOnDown_2() const { return ___m_SelectOnDown_2; }
	inline Selectable_tAA9065030FE0468018DEC880302F95FEA9C0133A ** get_address_of_m_SelectOnDown_2() { return &___m_SelectOnDown_2; }
	inline void set_m_SelectOnDown_2(Selectable_tAA9065030FE0468018DEC880302F95FEA9C0133A * value)
	{
		___m_SelectOnDown_2 = value;
		Il2CppCodeGenWriteBarrier((&___m_SelectOnDown_2), value);
	}

	inline static int32_t get_offset_of_m_SelectOnLeft_3() { return static_cast<int32_t>(offsetof(Navigation_t761250C05C09773B75F5E0D52DDCBBFE60288A07, ___m_SelectOnLeft_3)); }
	inline Selectable_tAA9065030FE0468018DEC880302F95FEA9C0133A * get_m_SelectOnLeft_3() const { return ___m_SelectOnLeft_3; }
	inline Selectable_tAA9065030FE0468018DEC880302F95FEA9C0133A ** get_address_of_m_SelectOnLeft_3() { return &___m_SelectOnLeft_3; }
	inline void set_m_SelectOnLeft_3(Selectable_tAA9065030FE0468018DEC880302F95FEA9C0133A * value)
	{
		___m_SelectOnLeft_3 = value;
		Il2CppCodeGenWriteBarrier((&___m_SelectOnLeft_3), value);
	}

	inline static int32_t get_offset_of_m_SelectOnRight_4() { return static_cast<int32_t>(offsetof(Navigation_t761250C05C09773B75F5E0D52DDCBBFE60288A07, ___m_SelectOnRight_4)); }
	inline Selectable_tAA9065030FE0468018DEC880302F95FEA9C0133A * get_m_SelectOnRight_4() const { return ___m_SelectOnRight_4; }
	inline Selectable_tAA9065030FE0468018DEC880302F95FEA9C0133A ** get_address_of_m_SelectOnRight_4() { return &___m_SelectOnRight_4; }
	inline void set_m_SelectOnRight_4(Selectable_tAA9065030FE0468018DEC880302F95FEA9C0133A * value)
	{
		___m_SelectOnRight_4 = value;
		Il2CppCodeGenWriteBarrier((&___m_SelectOnRight_4), value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
// Native definition for P/Invoke marshalling of UnityEngine.UI.Navigation
struct Navigation_t761250C05C09773B75F5E0D52DDCBBFE60288A07_marshaled_pinvoke
{
	int32_t ___m_Mode_0;
	Selectable_tAA9065030FE0468018DEC880302F95FEA9C0133A * ___m_SelectOnUp_1;
	Selectable_tAA9065030FE0468018DEC880302F95FEA9C0133A * ___m_SelectOnDown_2;
	Selectable_tAA9065030FE0468018DEC880302F95FEA9C0133A * ___m_SelectOnLeft_3;
	Selectable_tAA9065030FE0468018DEC880302F95FEA9C0133A * ___m_SelectOnRight_4;
};
// Native definition for COM marshalling of UnityEngine.UI.Navigation
struct Navigation_t761250C05C09773B75F5E0D52DDCBBFE60288A07_marshaled_com
{
	int32_t ___m_Mode_0;
	Selectable_tAA9065030FE0468018DEC880302F95FEA9C0133A * ___m_SelectOnUp_1;
	Selectable_tAA9065030FE0468018DEC880302F95FEA9C0133A * ___m_SelectOnDown_2;
	Selectable_tAA9065030FE0468018DEC880302F95FEA9C0133A * ___m_SelectOnLeft_3;
	Selectable_tAA9065030FE0468018DEC880302F95FEA9C0133A * ___m_SelectOnRight_4;
};
#endif // NAVIGATION_T761250C05C09773B75F5E0D52DDCBBFE60288A07_H
#ifndef ASYNCCALLBACK_T3F3DA3BEDAEE81DD1D24125DF8EB30E85EE14DA4_H
#define ASYNCCALLBACK_T3F3DA3BEDAEE81DD1D24125DF8EB30E85EE14DA4_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// System.AsyncCallback
struct  AsyncCallback_t3F3DA3BEDAEE81DD1D24125DF8EB30E85EE14DA4  : public MulticastDelegate_t
{
public:

public:
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
#endif // ASYNCCALLBACK_T3F3DA3BEDAEE81DD1D24125DF8EB30E85EE14DA4_H
#ifndef FILESYSTEMINFO_T6831B76FBA37F7181E4A5AEB28194730EB356A3D_H
#define FILESYSTEMINFO_T6831B76FBA37F7181E4A5AEB28194730EB356A3D_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// System.IO.FileSystemInfo
struct  FileSystemInfo_t6831B76FBA37F7181E4A5AEB28194730EB356A3D  : public MarshalByRefObject_tC4577953D0A44D0AB8597CFA868E01C858B1C9AF
{
public:
	// System.IO.MonoIOStat System.IO.FileSystemInfo::_data
	MonoIOStat_t819C03DA1902AA493BDBF4B55E76DCE6FB16A124  ____data_1;
	// System.Int32 System.IO.FileSystemInfo::_dataInitialised
	int32_t ____dataInitialised_2;
	// System.String System.IO.FileSystemInfo::FullPath
	String_t* ___FullPath_3;
	// System.String System.IO.FileSystemInfo::OriginalPath
	String_t* ___OriginalPath_4;
	// System.String System.IO.FileSystemInfo::_displayPath
	String_t* ____displayPath_5;

public:
	inline static int32_t get_offset_of__data_1() { return static_cast<int32_t>(offsetof(FileSystemInfo_t6831B76FBA37F7181E4A5AEB28194730EB356A3D, ____data_1)); }
	inline MonoIOStat_t819C03DA1902AA493BDBF4B55E76DCE6FB16A124  get__data_1() const { return ____data_1; }
	inline MonoIOStat_t819C03DA1902AA493BDBF4B55E76DCE6FB16A124 * get_address_of__data_1() { return &____data_1; }
	inline void set__data_1(MonoIOStat_t819C03DA1902AA493BDBF4B55E76DCE6FB16A124  value)
	{
		____data_1 = value;
	}

	inline static int32_t get_offset_of__dataInitialised_2() { return static_cast<int32_t>(offsetof(FileSystemInfo_t6831B76FBA37F7181E4A5AEB28194730EB356A3D, ____dataInitialised_2)); }
	inline int32_t get__dataInitialised_2() const { return ____dataInitialised_2; }
	inline int32_t* get_address_of__dataInitialised_2() { return &____dataInitialised_2; }
	inline void set__dataInitialised_2(int32_t value)
	{
		____dataInitialised_2 = value;
	}

	inline static int32_t get_offset_of_FullPath_3() { return static_cast<int32_t>(offsetof(FileSystemInfo_t6831B76FBA37F7181E4A5AEB28194730EB356A3D, ___FullPath_3)); }
	inline String_t* get_FullPath_3() const { return ___FullPath_3; }
	inline String_t** get_address_of_FullPath_3() { return &___FullPath_3; }
	inline void set_FullPath_3(String_t* value)
	{
		___FullPath_3 = value;
		Il2CppCodeGenWriteBarrier((&___FullPath_3), value);
	}

	inline static int32_t get_offset_of_OriginalPath_4() { return static_cast<int32_t>(offsetof(FileSystemInfo_t6831B76FBA37F7181E4A5AEB28194730EB356A3D, ___OriginalPath_4)); }
	inline String_t* get_OriginalPath_4() const { return ___OriginalPath_4; }
	inline String_t** get_address_of_OriginalPath_4() { return &___OriginalPath_4; }
	inline void set_OriginalPath_4(String_t* value)
	{
		___OriginalPath_4 = value;
		Il2CppCodeGenWriteBarrier((&___OriginalPath_4), value);
	}

	inline static int32_t get_offset_of__displayPath_5() { return static_cast<int32_t>(offsetof(FileSystemInfo_t6831B76FBA37F7181E4A5AEB28194730EB356A3D, ____displayPath_5)); }
	inline String_t* get__displayPath_5() const { return ____displayPath_5; }
	inline String_t** get_address_of__displayPath_5() { return &____displayPath_5; }
	inline void set__displayPath_5(String_t* value)
	{
		____displayPath_5 = value;
		Il2CppCodeGenWriteBarrier((&____displayPath_5), value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
#endif // FILESYSTEMINFO_T6831B76FBA37F7181E4A5AEB28194730EB356A3D_H
#ifndef BEHAVIOUR_TBDC7E9C3C898AD8348891B82D3E345801D920CA8_H
#define BEHAVIOUR_TBDC7E9C3C898AD8348891B82D3E345801D920CA8_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// UnityEngine.Behaviour
struct  Behaviour_tBDC7E9C3C898AD8348891B82D3E345801D920CA8  : public Component_t05064EF382ABCAF4B8C94F8A350EA85184C26621
{
public:

public:
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
#endif // BEHAVIOUR_TBDC7E9C3C898AD8348891B82D3E345801D920CA8_H
#ifndef UNITYACTION_1_TB994D127B02789CE2010397AEF756615E5F84FDC_H
#define UNITYACTION_1_TB994D127B02789CE2010397AEF756615E5F84FDC_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// UnityEngine.Events.UnityAction`1<System.Boolean>
struct  UnityAction_1_tB994D127B02789CE2010397AEF756615E5F84FDC  : public MulticastDelegate_t
{
public:

public:
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
#endif // UNITYACTION_1_TB994D127B02789CE2010397AEF756615E5F84FDC_H
#ifndef RENDERER_T0556D67DD582620D1F495627EDE30D03284151F4_H
#define RENDERER_T0556D67DD582620D1F495627EDE30D03284151F4_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// UnityEngine.Renderer
struct  Renderer_t0556D67DD582620D1F495627EDE30D03284151F4  : public Component_t05064EF382ABCAF4B8C94F8A350EA85184C26621
{
public:

public:
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
#endif // RENDERER_T0556D67DD582620D1F495627EDE30D03284151F4_H
#ifndef TEXTURE2D_TBBF96AC337723E2EF156DF17E09D4379FD05DE1C_H
#define TEXTURE2D_TBBF96AC337723E2EF156DF17E09D4379FD05DE1C_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// UnityEngine.Texture2D
struct  Texture2D_tBBF96AC337723E2EF156DF17E09D4379FD05DE1C  : public Texture_t387FE83BB848001FD06B14707AEA6D5A0F6A95F4
{
public:

public:
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
#endif // TEXTURE2D_TBBF96AC337723E2EF156DF17E09D4379FD05DE1C_H
#ifndef TRANSFORM_TBB9E78A2766C3C83599A8F66EDE7D1FCAFC66EDA_H
#define TRANSFORM_TBB9E78A2766C3C83599A8F66EDE7D1FCAFC66EDA_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// UnityEngine.Transform
struct  Transform_tBB9E78A2766C3C83599A8F66EDE7D1FCAFC66EDA  : public Component_t05064EF382ABCAF4B8C94F8A350EA85184C26621
{
public:

public:
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
#endif // TRANSFORM_TBB9E78A2766C3C83599A8F66EDE7D1FCAFC66EDA_H
#ifndef AREAWASPAINTED_T537D2557735149202851C1AF691D54AA43D52E57_H
#define AREAWASPAINTED_T537D2557735149202851C1AF691D54AA43D52E57_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// unitycoder_MobilePaint.MobilePaint/AreaWasPainted
struct  AreaWasPainted_t537D2557735149202851C1AF691D54AA43D52E57  : public MulticastDelegate_t
{
public:

public:
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
#endif // AREAWASPAINTED_T537D2557735149202851C1AF691D54AA43D52E57_H
#ifndef DIRECTORYINFO_T432CD06DF148701E930708371CB985BC0E8EF87F_H
#define DIRECTORYINFO_T432CD06DF148701E930708371CB985BC0E8EF87F_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// System.IO.DirectoryInfo
struct  DirectoryInfo_t432CD06DF148701E930708371CB985BC0E8EF87F  : public FileSystemInfo_t6831B76FBA37F7181E4A5AEB28194730EB356A3D
{
public:
	// System.String System.IO.DirectoryInfo::current
	String_t* ___current_6;
	// System.String System.IO.DirectoryInfo::parent
	String_t* ___parent_7;

public:
	inline static int32_t get_offset_of_current_6() { return static_cast<int32_t>(offsetof(DirectoryInfo_t432CD06DF148701E930708371CB985BC0E8EF87F, ___current_6)); }
	inline String_t* get_current_6() const { return ___current_6; }
	inline String_t** get_address_of_current_6() { return &___current_6; }
	inline void set_current_6(String_t* value)
	{
		___current_6 = value;
		Il2CppCodeGenWriteBarrier((&___current_6), value);
	}

	inline static int32_t get_offset_of_parent_7() { return static_cast<int32_t>(offsetof(DirectoryInfo_t432CD06DF148701E930708371CB985BC0E8EF87F, ___parent_7)); }
	inline String_t* get_parent_7() const { return ___parent_7; }
	inline String_t** get_address_of_parent_7() { return &___parent_7; }
	inline void set_parent_7(String_t* value)
	{
		___parent_7 = value;
		Il2CppCodeGenWriteBarrier((&___parent_7), value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
#endif // DIRECTORYINFO_T432CD06DF148701E930708371CB985BC0E8EF87F_H
#ifndef GUIELEMENT_T7509096A8399BAB91367BBDD2F90EB2BACB1C4C4_H
#define GUIELEMENT_T7509096A8399BAB91367BBDD2F90EB2BACB1C4C4_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// UnityEngine.GUIElement
struct  GUIElement_t7509096A8399BAB91367BBDD2F90EB2BACB1C4C4  : public Behaviour_tBDC7E9C3C898AD8348891B82D3E345801D920CA8
{
public:

public:
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
#endif // GUIELEMENT_T7509096A8399BAB91367BBDD2F90EB2BACB1C4C4_H
#ifndef MONOBEHAVIOUR_T4A60845CF505405AF8BE8C61CC07F75CADEF6429_H
#define MONOBEHAVIOUR_T4A60845CF505405AF8BE8C61CC07F75CADEF6429_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// UnityEngine.MonoBehaviour
struct  MonoBehaviour_t4A60845CF505405AF8BE8C61CC07F75CADEF6429  : public Behaviour_tBDC7E9C3C898AD8348891B82D3E345801D920CA8
{
public:

public:
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
#endif // MONOBEHAVIOUR_T4A60845CF505405AF8BE8C61CC07F75CADEF6429_H
#ifndef UIBEHAVIOUR_T3C3C339CD5677BA7FC27C352FED8B78052A3FE70_H
#define UIBEHAVIOUR_T3C3C339CD5677BA7FC27C352FED8B78052A3FE70_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// UnityEngine.EventSystems.UIBehaviour
struct  UIBehaviour_t3C3C339CD5677BA7FC27C352FED8B78052A3FE70  : public MonoBehaviour_t4A60845CF505405AF8BE8C61CC07F75CADEF6429
{
public:

public:
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
#endif // UIBEHAVIOUR_T3C3C339CD5677BA7FC27C352FED8B78052A3FE70_H
#ifndef GUITEXT_T1AAED515CF7E63F24B55C5FC988555DA14DA10F1_H
#define GUITEXT_T1AAED515CF7E63F24B55C5FC988555DA14DA10F1_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// UnityEngine.GUIText
struct  GUIText_t1AAED515CF7E63F24B55C5FC988555DA14DA10F1  : public GUIElement_t7509096A8399BAB91367BBDD2F90EB2BACB1C4C4
{
public:

public:
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
#endif // GUITEXT_T1AAED515CF7E63F24B55C5FC988555DA14DA10F1_H
#ifndef GUITEXTURE_T2A2F300B0F9D542DADB532DEC861D1711B5C46F3_H
#define GUITEXTURE_T2A2F300B0F9D542DADB532DEC861D1711B5C46F3_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// UnityEngine.GUITexture
struct  GUITexture_t2A2F300B0F9D542DADB532DEC861D1711B5C46F3  : public GUIElement_t7509096A8399BAB91367BBDD2F90EB2BACB1C4C4
{
public:

public:
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
#endif // GUITEXTURE_T2A2F300B0F9D542DADB532DEC861D1711B5C46F3_H
#ifndef MOBILEPAINT_TC25928758E48181B341DE30F410E3EA407D005E5_H
#define MOBILEPAINT_TC25928758E48181B341DE30F410E3EA407D005E5_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// unitycoder_MobilePaint.MobilePaint
struct  MobilePaint_tC25928758E48181B341DE30F410E3EA407D005E5  : public MonoBehaviour_t4A60845CF505405AF8BE8C61CC07F75CADEF6429
{
public:
	// System.Boolean unitycoder_MobilePaint.MobilePaint::enableTouch
	bool ___enableTouch_4;
	// UnityEngine.LayerMask unitycoder_MobilePaint.MobilePaint::paintLayerMask
	LayerMask_tBB9173D8B6939D476E67E849280AC9F4EC4D93B0  ___paintLayerMask_5;
	// System.Boolean unitycoder_MobilePaint.MobilePaint::createCanvasMesh
	bool ___createCanvasMesh_6;
	// UnityEngine.RectTransform unitycoder_MobilePaint.MobilePaint::referenceArea
	RectTransform_t285CBD8775B25174B75164F10618F8B9728E1B20 * ___referenceArea_7;
	// System.Single unitycoder_MobilePaint.MobilePaint::canvasScaleFactor
	float ___canvasScaleFactor_8;
	// System.Boolean unitycoder_MobilePaint.MobilePaint::connectBrushStokes
	bool ___connectBrushStokes_9;
	// UnityEngine.Color32 unitycoder_MobilePaint.MobilePaint::paintColor
	Color32_t23ABC4AE0E0BDFD2E22EE1FA0DA3904FFE5F6E23  ___paintColor_10;
	// System.Int32 unitycoder_MobilePaint.MobilePaint::brushSize
	int32_t ___brushSize_11;
	// System.Int32 unitycoder_MobilePaint.MobilePaint::brushSizeMin
	int32_t ___brushSizeMin_12;
	// System.Int32 unitycoder_MobilePaint.MobilePaint::brushSizeMax
	int32_t ___brushSizeMax_13;
	// System.Boolean unitycoder_MobilePaint.MobilePaint::hiQualityBrush
	bool ___hiQualityBrush_14;
	// System.Int32 unitycoder_MobilePaint.MobilePaint::brushSizeX1
	int32_t ___brushSizeX1_15;
	// System.Int32 unitycoder_MobilePaint.MobilePaint::brushSizeXbrushSize
	int32_t ___brushSizeXbrushSize_16;
	// System.Int32 unitycoder_MobilePaint.MobilePaint::brushSizeX4
	int32_t ___brushSizeX4_17;
	// System.Int32 unitycoder_MobilePaint.MobilePaint::brushSizeDiv4
	int32_t ___brushSizeDiv4_18;
	// System.Boolean unitycoder_MobilePaint.MobilePaint::realTimeTexUpdate
	bool ___realTimeTexUpdate_19;
	// System.Single unitycoder_MobilePaint.MobilePaint::textureUpdateSpeed
	float ___textureUpdateSpeed_20;
	// System.Single unitycoder_MobilePaint.MobilePaint::nextTextureUpdate
	float ___nextTextureUpdate_21;
	// System.Boolean unitycoder_MobilePaint.MobilePaint::useAdditiveColors
	bool ___useAdditiveColors_22;
	// System.Single unitycoder_MobilePaint.MobilePaint::brushAlphaStrength
	float ___brushAlphaStrength_23;
	// System.Single unitycoder_MobilePaint.MobilePaint::brushAlphaStrengthVal
	float ___brushAlphaStrengthVal_24;
	// System.Single unitycoder_MobilePaint.MobilePaint::alphaLerpVal
	float ___alphaLerpVal_25;
	// System.Single unitycoder_MobilePaint.MobilePaint::brushAlphaLerpVal
	float ___brushAlphaLerpVal_26;
	// unitycoder_MobilePaint.DrawMode unitycoder_MobilePaint.MobilePaint::drawMode
	int32_t ___drawMode_27;
	// System.Boolean unitycoder_MobilePaint.MobilePaint::useLockArea
	bool ___useLockArea_28;
	// System.Boolean unitycoder_MobilePaint.MobilePaint::useMaskLayerOnly
	bool ___useMaskLayerOnly_29;
	// System.Boolean unitycoder_MobilePaint.MobilePaint::smoothenMaskEdges
	bool ___smoothenMaskEdges_30;
	// System.Boolean unitycoder_MobilePaint.MobilePaint::useThreshold
	bool ___useThreshold_31;
	// System.Byte unitycoder_MobilePaint.MobilePaint::paintThreshold
	uint8_t ___paintThreshold_32;
	// unitycoder_MobilePaint.EraserMode unitycoder_MobilePaint.MobilePaint::eraserMode
	int32_t ___eraserMode_33;
	// System.Boolean unitycoder_MobilePaint.MobilePaint::getAreaSize
	bool ___getAreaSize_34;
	// System.Int32 unitycoder_MobilePaint.MobilePaint::initialX
	int32_t ___initialX_35;
	// System.Int32 unitycoder_MobilePaint.MobilePaint::initialY
	int32_t ___initialY_36;
	// unitycoder_MobilePaint.MobilePaint/AreaWasPainted unitycoder_MobilePaint.MobilePaint::AreaPaintedEvent
	AreaWasPainted_t537D2557735149202851C1AF691D54AA43D52E57 * ___AreaPaintedEvent_37;
	// System.Byte[] unitycoder_MobilePaint.MobilePaint::lockMaskPixels
	ByteU5BU5D_tD06FDBE8142446525DF1C40351D523A228373821* ___lockMaskPixels_38;
	// System.Boolean unitycoder_MobilePaint.MobilePaint::canDrawOnBlack
	bool ___canDrawOnBlack_39;
	// UnityEngine.Vector2 unitycoder_MobilePaint.MobilePaint::canvasSizeAdjust
	Vector2_tA85D2DD88578276CA8A8796756458277E72D073D  ___canvasSizeAdjust_40;
	// System.String unitycoder_MobilePaint.MobilePaint::targetTexture
	String_t* ___targetTexture_41;
	// UnityEngine.FilterMode unitycoder_MobilePaint.MobilePaint::filterMode
	int32_t ___filterMode_42;
	// UnityEngine.Color32 unitycoder_MobilePaint.MobilePaint::clearColor
	Color32_t23ABC4AE0E0BDFD2E22EE1FA0DA3904FFE5F6E23  ___clearColor_43;
	// System.Boolean unitycoder_MobilePaint.MobilePaint::useMaskImage
	bool ___useMaskImage_44;
	// UnityEngine.Texture2D unitycoder_MobilePaint.MobilePaint::maskTex
	Texture2D_tBBF96AC337723E2EF156DF17E09D4379FD05DE1C * ___maskTex_45;
	// System.Boolean unitycoder_MobilePaint.MobilePaint::useCustomBrushes
	bool ___useCustomBrushes_46;
	// UnityEngine.Texture2D[] unitycoder_MobilePaint.MobilePaint::customBrushes
	Texture2DU5BU5D_tCAC03055C735C020BAFC218D55183CF03E74C1C9* ___customBrushes_47;
	// System.Boolean unitycoder_MobilePaint.MobilePaint::overrideCustomBrushColor
	bool ___overrideCustomBrushColor_48;
	// System.Boolean unitycoder_MobilePaint.MobilePaint::useCustomBrushAlpha
	bool ___useCustomBrushAlpha_49;
	// System.Int32 unitycoder_MobilePaint.MobilePaint::selectedBrush
	int32_t ___selectedBrush_50;
	// System.Byte[] unitycoder_MobilePaint.MobilePaint::customBrushBytes
	ByteU5BU5D_tD06FDBE8142446525DF1C40351D523A228373821* ___customBrushBytes_51;
	// System.Int32 unitycoder_MobilePaint.MobilePaint::customBrushWidth
	int32_t ___customBrushWidth_52;
	// System.Int32 unitycoder_MobilePaint.MobilePaint::customBrushHeight
	int32_t ___customBrushHeight_53;
	// System.Int32 unitycoder_MobilePaint.MobilePaint::customBrushWidthHalf
	int32_t ___customBrushWidthHalf_54;
	// System.Int32 unitycoder_MobilePaint.MobilePaint::texWidthMinusCustomBrushWidth
	int32_t ___texWidthMinusCustomBrushWidth_55;
	// System.Int32 unitycoder_MobilePaint.MobilePaint::texHeightMinusCustomBrushHeight
	int32_t ___texHeightMinusCustomBrushHeight_56;
	// System.Boolean unitycoder_MobilePaint.MobilePaint::useCustomPatterns
	bool ___useCustomPatterns_57;
	// UnityEngine.Texture2D[] unitycoder_MobilePaint.MobilePaint::customPatterns
	Texture2DU5BU5D_tCAC03055C735C020BAFC218D55183CF03E74C1C9* ___customPatterns_58;
	// System.Byte[] unitycoder_MobilePaint.MobilePaint::patternBrushBytes
	ByteU5BU5D_tD06FDBE8142446525DF1C40351D523A228373821* ___patternBrushBytes_59;
	// System.Int32 unitycoder_MobilePaint.MobilePaint::customPatternWidth
	int32_t ___customPatternWidth_60;
	// System.Int32 unitycoder_MobilePaint.MobilePaint::customPatternHeight
	int32_t ___customPatternHeight_61;
	// System.Int32 unitycoder_MobilePaint.MobilePaint::selectedPattern
	int32_t ___selectedPattern_62;
	// UnityEngine.Transform unitycoder_MobilePaint.MobilePaint::previewLineCircle
	Transform_tBB9E78A2766C3C83599A8F66EDE7D1FCAFC66EDA * ___previewLineCircle_63;
	// UnityEngine.Transform unitycoder_MobilePaint.MobilePaint::previewLineCircleStart
	Transform_tBB9E78A2766C3C83599A8F66EDE7D1FCAFC66EDA * ___previewLineCircleStart_64;
	// UnityEngine.Transform unitycoder_MobilePaint.MobilePaint::previewLineCircleEnd
	Transform_tBB9E78A2766C3C83599A8F66EDE7D1FCAFC66EDA * ___previewLineCircleEnd_65;
	// System.Boolean unitycoder_MobilePaint.MobilePaint::haveStartedLine
	bool ___haveStartedLine_66;
	// System.Int32 unitycoder_MobilePaint.MobilePaint::firstClickX
	int32_t ___firstClickX_67;
	// System.Int32 unitycoder_MobilePaint.MobilePaint::firstClickY
	int32_t ___firstClickY_68;
	// UnityEngine.LineRenderer unitycoder_MobilePaint.MobilePaint::lineRenderer
	LineRenderer_tD225C480F28F28A4D737866474F21001B803B7C3 * ___lineRenderer_69;
	// System.Boolean unitycoder_MobilePaint.MobilePaint::snapLinesToGrid
	bool ___snapLinesToGrid_70;
	// System.Int32 unitycoder_MobilePaint.MobilePaint::gridResolution
	int32_t ___gridResolution_71;
	// System.Int32 unitycoder_MobilePaint.MobilePaint::gridSize
	int32_t ___gridSize_72;
	// System.Single unitycoder_MobilePaint.MobilePaint::scaleAdjust
	float ___scaleAdjust_73;
	// System.Byte[] unitycoder_MobilePaint.MobilePaint::pixels
	ByteU5BU5D_tD06FDBE8142446525DF1C40351D523A228373821* ___pixels_76;
	// System.Byte[] unitycoder_MobilePaint.MobilePaint::maskPixels
	ByteU5BU5D_tD06FDBE8142446525DF1C40351D523A228373821* ___maskPixels_77;
	// System.Byte[] unitycoder_MobilePaint.MobilePaint::clearPixels
	ByteU5BU5D_tD06FDBE8142446525DF1C40351D523A228373821* ___clearPixels_78;
	// UnityEngine.Texture2D unitycoder_MobilePaint.MobilePaint::drawingTexture
	Texture2D_tBBF96AC337723E2EF156DF17E09D4379FD05DE1C * ___drawingTexture_79;
	// System.Single unitycoder_MobilePaint.MobilePaint::resolutionScaler
	float ___resolutionScaler_80;
	// System.Boolean unitycoder_MobilePaint.MobilePaint::overrideResolution
	bool ___overrideResolution_81;
	// System.Int32 unitycoder_MobilePaint.MobilePaint::overrideWidth
	int32_t ___overrideWidth_82;
	// System.Int32 unitycoder_MobilePaint.MobilePaint::overrideHeight
	int32_t ___overrideHeight_83;
	// System.Int32 unitycoder_MobilePaint.MobilePaint::texWidth
	int32_t ___texWidth_84;
	// System.Int32 unitycoder_MobilePaint.MobilePaint::texHeight
	int32_t ___texHeight_85;
	// UnityEngine.Touch unitycoder_MobilePaint.MobilePaint::touch
	Touch_t806752C775BA713A91B6588A07CA98417CABC003  ___touch_86;
	// System.Boolean unitycoder_MobilePaint.MobilePaint::wasTouching
	bool ___wasTouching_87;
	// UnityEngine.Camera unitycoder_MobilePaint.MobilePaint::cam
	Camera_t48B2B9ECB3CE6108A98BF949A1CECF0FE3421F34 * ___cam_88;
	// UnityEngine.Renderer unitycoder_MobilePaint.MobilePaint::myRenderer
	Renderer_t0556D67DD582620D1F495627EDE30D03284151F4 * ___myRenderer_89;
	// UnityEngine.RaycastHit unitycoder_MobilePaint.MobilePaint::hit
	RaycastHit_t19695F18F9265FE5425062BBA6A4D330480538C3  ___hit_90;
	// System.Boolean unitycoder_MobilePaint.MobilePaint::wentOutside
	bool ___wentOutside_91;
	// System.Boolean unitycoder_MobilePaint.MobilePaint::usingClearingImage
	bool ___usingClearingImage_92;
	// UnityEngine.Vector2 unitycoder_MobilePaint.MobilePaint::pixelUV
	Vector2_tA85D2DD88578276CA8A8796756458277E72D073D  ___pixelUV_93;
	// UnityEngine.Vector2 unitycoder_MobilePaint.MobilePaint::pixelUVOld
	Vector2_tA85D2DD88578276CA8A8796756458277E72D073D  ___pixelUVOld_94;
	// UnityEngine.Vector2[] unitycoder_MobilePaint.MobilePaint::pixelUVs
	Vector2U5BU5D_tA065A07DFC060C1B8786BBAA5F3A6577CCEB27D6* ___pixelUVs_95;
	// UnityEngine.Vector2[] unitycoder_MobilePaint.MobilePaint::pixelUVOlds
	Vector2U5BU5D_tA065A07DFC060C1B8786BBAA5F3A6577CCEB27D6* ___pixelUVOlds_96;
	// System.Boolean unitycoder_MobilePaint.MobilePaint::textureNeedsUpdate
	bool ___textureNeedsUpdate_97;
	// System.Boolean unitycoder_MobilePaint.MobilePaint::undoEnabled
	bool ___undoEnabled_98;
	// System.Collections.Generic.List`1<System.Byte[]> unitycoder_MobilePaint.MobilePaint::undoPixels
	List_1_t8BE041DC5257EA95B6376B45901D0D957BCF7CEC * ___undoPixels_99;
	// System.Int32 unitycoder_MobilePaint.MobilePaint::maxUndoBuffers
	int32_t ___maxUndoBuffers_100;
	// UnityEngine.GameObject unitycoder_MobilePaint.MobilePaint::userInterface
	GameObject_tBD1244AD56B4E59AAD76E5E7C9282EC5CE434F0F * ___userInterface_101;
	// System.Boolean unitycoder_MobilePaint.MobilePaint::hideUIWhilePainting
	bool ___hideUIWhilePainting_102;
	// System.Boolean unitycoder_MobilePaint.MobilePaint::isUIVisible
	bool ___isUIVisible_103;
	// System.Boolean unitycoder_MobilePaint.MobilePaint::debugMode
	bool ___debugMode_104;
	// UnityEngine.EventSystems.EventSystem unitycoder_MobilePaint.MobilePaint::eventSystem
	EventSystem_t06ACEF1C8D95D44D3A7F57ED4BAA577101B4EA77 * ___eventSystem_105;
	// System.Boolean unitycoder_MobilePaint.MobilePaint::isZoomingOrPanning
	bool ___isZoomingOrPanning_106;
	// System.Int32 unitycoder_MobilePaint.MobilePaint::i
	int32_t ___i_107;

public:
	inline static int32_t get_offset_of_enableTouch_4() { return static_cast<int32_t>(offsetof(MobilePaint_tC25928758E48181B341DE30F410E3EA407D005E5, ___enableTouch_4)); }
	inline bool get_enableTouch_4() const { return ___enableTouch_4; }
	inline bool* get_address_of_enableTouch_4() { return &___enableTouch_4; }
	inline void set_enableTouch_4(bool value)
	{
		___enableTouch_4 = value;
	}

	inline static int32_t get_offset_of_paintLayerMask_5() { return static_cast<int32_t>(offsetof(MobilePaint_tC25928758E48181B341DE30F410E3EA407D005E5, ___paintLayerMask_5)); }
	inline LayerMask_tBB9173D8B6939D476E67E849280AC9F4EC4D93B0  get_paintLayerMask_5() const { return ___paintLayerMask_5; }
	inline LayerMask_tBB9173D8B6939D476E67E849280AC9F4EC4D93B0 * get_address_of_paintLayerMask_5() { return &___paintLayerMask_5; }
	inline void set_paintLayerMask_5(LayerMask_tBB9173D8B6939D476E67E849280AC9F4EC4D93B0  value)
	{
		___paintLayerMask_5 = value;
	}

	inline static int32_t get_offset_of_createCanvasMesh_6() { return static_cast<int32_t>(offsetof(MobilePaint_tC25928758E48181B341DE30F410E3EA407D005E5, ___createCanvasMesh_6)); }
	inline bool get_createCanvasMesh_6() const { return ___createCanvasMesh_6; }
	inline bool* get_address_of_createCanvasMesh_6() { return &___createCanvasMesh_6; }
	inline void set_createCanvasMesh_6(bool value)
	{
		___createCanvasMesh_6 = value;
	}

	inline static int32_t get_offset_of_referenceArea_7() { return static_cast<int32_t>(offsetof(MobilePaint_tC25928758E48181B341DE30F410E3EA407D005E5, ___referenceArea_7)); }
	inline RectTransform_t285CBD8775B25174B75164F10618F8B9728E1B20 * get_referenceArea_7() const { return ___referenceArea_7; }
	inline RectTransform_t285CBD8775B25174B75164F10618F8B9728E1B20 ** get_address_of_referenceArea_7() { return &___referenceArea_7; }
	inline void set_referenceArea_7(RectTransform_t285CBD8775B25174B75164F10618F8B9728E1B20 * value)
	{
		___referenceArea_7 = value;
		Il2CppCodeGenWriteBarrier((&___referenceArea_7), value);
	}

	inline static int32_t get_offset_of_canvasScaleFactor_8() { return static_cast<int32_t>(offsetof(MobilePaint_tC25928758E48181B341DE30F410E3EA407D005E5, ___canvasScaleFactor_8)); }
	inline float get_canvasScaleFactor_8() const { return ___canvasScaleFactor_8; }
	inline float* get_address_of_canvasScaleFactor_8() { return &___canvasScaleFactor_8; }
	inline void set_canvasScaleFactor_8(float value)
	{
		___canvasScaleFactor_8 = value;
	}

	inline static int32_t get_offset_of_connectBrushStokes_9() { return static_cast<int32_t>(offsetof(MobilePaint_tC25928758E48181B341DE30F410E3EA407D005E5, ___connectBrushStokes_9)); }
	inline bool get_connectBrushStokes_9() const { return ___connectBrushStokes_9; }
	inline bool* get_address_of_connectBrushStokes_9() { return &___connectBrushStokes_9; }
	inline void set_connectBrushStokes_9(bool value)
	{
		___connectBrushStokes_9 = value;
	}

	inline static int32_t get_offset_of_paintColor_10() { return static_cast<int32_t>(offsetof(MobilePaint_tC25928758E48181B341DE30F410E3EA407D005E5, ___paintColor_10)); }
	inline Color32_t23ABC4AE0E0BDFD2E22EE1FA0DA3904FFE5F6E23  get_paintColor_10() const { return ___paintColor_10; }
	inline Color32_t23ABC4AE0E0BDFD2E22EE1FA0DA3904FFE5F6E23 * get_address_of_paintColor_10() { return &___paintColor_10; }
	inline void set_paintColor_10(Color32_t23ABC4AE0E0BDFD2E22EE1FA0DA3904FFE5F6E23  value)
	{
		___paintColor_10 = value;
	}

	inline static int32_t get_offset_of_brushSize_11() { return static_cast<int32_t>(offsetof(MobilePaint_tC25928758E48181B341DE30F410E3EA407D005E5, ___brushSize_11)); }
	inline int32_t get_brushSize_11() const { return ___brushSize_11; }
	inline int32_t* get_address_of_brushSize_11() { return &___brushSize_11; }
	inline void set_brushSize_11(int32_t value)
	{
		___brushSize_11 = value;
	}

	inline static int32_t get_offset_of_brushSizeMin_12() { return static_cast<int32_t>(offsetof(MobilePaint_tC25928758E48181B341DE30F410E3EA407D005E5, ___brushSizeMin_12)); }
	inline int32_t get_brushSizeMin_12() const { return ___brushSizeMin_12; }
	inline int32_t* get_address_of_brushSizeMin_12() { return &___brushSizeMin_12; }
	inline void set_brushSizeMin_12(int32_t value)
	{
		___brushSizeMin_12 = value;
	}

	inline static int32_t get_offset_of_brushSizeMax_13() { return static_cast<int32_t>(offsetof(MobilePaint_tC25928758E48181B341DE30F410E3EA407D005E5, ___brushSizeMax_13)); }
	inline int32_t get_brushSizeMax_13() const { return ___brushSizeMax_13; }
	inline int32_t* get_address_of_brushSizeMax_13() { return &___brushSizeMax_13; }
	inline void set_brushSizeMax_13(int32_t value)
	{
		___brushSizeMax_13 = value;
	}

	inline static int32_t get_offset_of_hiQualityBrush_14() { return static_cast<int32_t>(offsetof(MobilePaint_tC25928758E48181B341DE30F410E3EA407D005E5, ___hiQualityBrush_14)); }
	inline bool get_hiQualityBrush_14() const { return ___hiQualityBrush_14; }
	inline bool* get_address_of_hiQualityBrush_14() { return &___hiQualityBrush_14; }
	inline void set_hiQualityBrush_14(bool value)
	{
		___hiQualityBrush_14 = value;
	}

	inline static int32_t get_offset_of_brushSizeX1_15() { return static_cast<int32_t>(offsetof(MobilePaint_tC25928758E48181B341DE30F410E3EA407D005E5, ___brushSizeX1_15)); }
	inline int32_t get_brushSizeX1_15() const { return ___brushSizeX1_15; }
	inline int32_t* get_address_of_brushSizeX1_15() { return &___brushSizeX1_15; }
	inline void set_brushSizeX1_15(int32_t value)
	{
		___brushSizeX1_15 = value;
	}

	inline static int32_t get_offset_of_brushSizeXbrushSize_16() { return static_cast<int32_t>(offsetof(MobilePaint_tC25928758E48181B341DE30F410E3EA407D005E5, ___brushSizeXbrushSize_16)); }
	inline int32_t get_brushSizeXbrushSize_16() const { return ___brushSizeXbrushSize_16; }
	inline int32_t* get_address_of_brushSizeXbrushSize_16() { return &___brushSizeXbrushSize_16; }
	inline void set_brushSizeXbrushSize_16(int32_t value)
	{
		___brushSizeXbrushSize_16 = value;
	}

	inline static int32_t get_offset_of_brushSizeX4_17() { return static_cast<int32_t>(offsetof(MobilePaint_tC25928758E48181B341DE30F410E3EA407D005E5, ___brushSizeX4_17)); }
	inline int32_t get_brushSizeX4_17() const { return ___brushSizeX4_17; }
	inline int32_t* get_address_of_brushSizeX4_17() { return &___brushSizeX4_17; }
	inline void set_brushSizeX4_17(int32_t value)
	{
		___brushSizeX4_17 = value;
	}

	inline static int32_t get_offset_of_brushSizeDiv4_18() { return static_cast<int32_t>(offsetof(MobilePaint_tC25928758E48181B341DE30F410E3EA407D005E5, ___brushSizeDiv4_18)); }
	inline int32_t get_brushSizeDiv4_18() const { return ___brushSizeDiv4_18; }
	inline int32_t* get_address_of_brushSizeDiv4_18() { return &___brushSizeDiv4_18; }
	inline void set_brushSizeDiv4_18(int32_t value)
	{
		___brushSizeDiv4_18 = value;
	}

	inline static int32_t get_offset_of_realTimeTexUpdate_19() { return static_cast<int32_t>(offsetof(MobilePaint_tC25928758E48181B341DE30F410E3EA407D005E5, ___realTimeTexUpdate_19)); }
	inline bool get_realTimeTexUpdate_19() const { return ___realTimeTexUpdate_19; }
	inline bool* get_address_of_realTimeTexUpdate_19() { return &___realTimeTexUpdate_19; }
	inline void set_realTimeTexUpdate_19(bool value)
	{
		___realTimeTexUpdate_19 = value;
	}

	inline static int32_t get_offset_of_textureUpdateSpeed_20() { return static_cast<int32_t>(offsetof(MobilePaint_tC25928758E48181B341DE30F410E3EA407D005E5, ___textureUpdateSpeed_20)); }
	inline float get_textureUpdateSpeed_20() const { return ___textureUpdateSpeed_20; }
	inline float* get_address_of_textureUpdateSpeed_20() { return &___textureUpdateSpeed_20; }
	inline void set_textureUpdateSpeed_20(float value)
	{
		___textureUpdateSpeed_20 = value;
	}

	inline static int32_t get_offset_of_nextTextureUpdate_21() { return static_cast<int32_t>(offsetof(MobilePaint_tC25928758E48181B341DE30F410E3EA407D005E5, ___nextTextureUpdate_21)); }
	inline float get_nextTextureUpdate_21() const { return ___nextTextureUpdate_21; }
	inline float* get_address_of_nextTextureUpdate_21() { return &___nextTextureUpdate_21; }
	inline void set_nextTextureUpdate_21(float value)
	{
		___nextTextureUpdate_21 = value;
	}

	inline static int32_t get_offset_of_useAdditiveColors_22() { return static_cast<int32_t>(offsetof(MobilePaint_tC25928758E48181B341DE30F410E3EA407D005E5, ___useAdditiveColors_22)); }
	inline bool get_useAdditiveColors_22() const { return ___useAdditiveColors_22; }
	inline bool* get_address_of_useAdditiveColors_22() { return &___useAdditiveColors_22; }
	inline void set_useAdditiveColors_22(bool value)
	{
		___useAdditiveColors_22 = value;
	}

	inline static int32_t get_offset_of_brushAlphaStrength_23() { return static_cast<int32_t>(offsetof(MobilePaint_tC25928758E48181B341DE30F410E3EA407D005E5, ___brushAlphaStrength_23)); }
	inline float get_brushAlphaStrength_23() const { return ___brushAlphaStrength_23; }
	inline float* get_address_of_brushAlphaStrength_23() { return &___brushAlphaStrength_23; }
	inline void set_brushAlphaStrength_23(float value)
	{
		___brushAlphaStrength_23 = value;
	}

	inline static int32_t get_offset_of_brushAlphaStrengthVal_24() { return static_cast<int32_t>(offsetof(MobilePaint_tC25928758E48181B341DE30F410E3EA407D005E5, ___brushAlphaStrengthVal_24)); }
	inline float get_brushAlphaStrengthVal_24() const { return ___brushAlphaStrengthVal_24; }
	inline float* get_address_of_brushAlphaStrengthVal_24() { return &___brushAlphaStrengthVal_24; }
	inline void set_brushAlphaStrengthVal_24(float value)
	{
		___brushAlphaStrengthVal_24 = value;
	}

	inline static int32_t get_offset_of_alphaLerpVal_25() { return static_cast<int32_t>(offsetof(MobilePaint_tC25928758E48181B341DE30F410E3EA407D005E5, ___alphaLerpVal_25)); }
	inline float get_alphaLerpVal_25() const { return ___alphaLerpVal_25; }
	inline float* get_address_of_alphaLerpVal_25() { return &___alphaLerpVal_25; }
	inline void set_alphaLerpVal_25(float value)
	{
		___alphaLerpVal_25 = value;
	}

	inline static int32_t get_offset_of_brushAlphaLerpVal_26() { return static_cast<int32_t>(offsetof(MobilePaint_tC25928758E48181B341DE30F410E3EA407D005E5, ___brushAlphaLerpVal_26)); }
	inline float get_brushAlphaLerpVal_26() const { return ___brushAlphaLerpVal_26; }
	inline float* get_address_of_brushAlphaLerpVal_26() { return &___brushAlphaLerpVal_26; }
	inline void set_brushAlphaLerpVal_26(float value)
	{
		___brushAlphaLerpVal_26 = value;
	}

	inline static int32_t get_offset_of_drawMode_27() { return static_cast<int32_t>(offsetof(MobilePaint_tC25928758E48181B341DE30F410E3EA407D005E5, ___drawMode_27)); }
	inline int32_t get_drawMode_27() const { return ___drawMode_27; }
	inline int32_t* get_address_of_drawMode_27() { return &___drawMode_27; }
	inline void set_drawMode_27(int32_t value)
	{
		___drawMode_27 = value;
	}

	inline static int32_t get_offset_of_useLockArea_28() { return static_cast<int32_t>(offsetof(MobilePaint_tC25928758E48181B341DE30F410E3EA407D005E5, ___useLockArea_28)); }
	inline bool get_useLockArea_28() const { return ___useLockArea_28; }
	inline bool* get_address_of_useLockArea_28() { return &___useLockArea_28; }
	inline void set_useLockArea_28(bool value)
	{
		___useLockArea_28 = value;
	}

	inline static int32_t get_offset_of_useMaskLayerOnly_29() { return static_cast<int32_t>(offsetof(MobilePaint_tC25928758E48181B341DE30F410E3EA407D005E5, ___useMaskLayerOnly_29)); }
	inline bool get_useMaskLayerOnly_29() const { return ___useMaskLayerOnly_29; }
	inline bool* get_address_of_useMaskLayerOnly_29() { return &___useMaskLayerOnly_29; }
	inline void set_useMaskLayerOnly_29(bool value)
	{
		___useMaskLayerOnly_29 = value;
	}

	inline static int32_t get_offset_of_smoothenMaskEdges_30() { return static_cast<int32_t>(offsetof(MobilePaint_tC25928758E48181B341DE30F410E3EA407D005E5, ___smoothenMaskEdges_30)); }
	inline bool get_smoothenMaskEdges_30() const { return ___smoothenMaskEdges_30; }
	inline bool* get_address_of_smoothenMaskEdges_30() { return &___smoothenMaskEdges_30; }
	inline void set_smoothenMaskEdges_30(bool value)
	{
		___smoothenMaskEdges_30 = value;
	}

	inline static int32_t get_offset_of_useThreshold_31() { return static_cast<int32_t>(offsetof(MobilePaint_tC25928758E48181B341DE30F410E3EA407D005E5, ___useThreshold_31)); }
	inline bool get_useThreshold_31() const { return ___useThreshold_31; }
	inline bool* get_address_of_useThreshold_31() { return &___useThreshold_31; }
	inline void set_useThreshold_31(bool value)
	{
		___useThreshold_31 = value;
	}

	inline static int32_t get_offset_of_paintThreshold_32() { return static_cast<int32_t>(offsetof(MobilePaint_tC25928758E48181B341DE30F410E3EA407D005E5, ___paintThreshold_32)); }
	inline uint8_t get_paintThreshold_32() const { return ___paintThreshold_32; }
	inline uint8_t* get_address_of_paintThreshold_32() { return &___paintThreshold_32; }
	inline void set_paintThreshold_32(uint8_t value)
	{
		___paintThreshold_32 = value;
	}

	inline static int32_t get_offset_of_eraserMode_33() { return static_cast<int32_t>(offsetof(MobilePaint_tC25928758E48181B341DE30F410E3EA407D005E5, ___eraserMode_33)); }
	inline int32_t get_eraserMode_33() const { return ___eraserMode_33; }
	inline int32_t* get_address_of_eraserMode_33() { return &___eraserMode_33; }
	inline void set_eraserMode_33(int32_t value)
	{
		___eraserMode_33 = value;
	}

	inline static int32_t get_offset_of_getAreaSize_34() { return static_cast<int32_t>(offsetof(MobilePaint_tC25928758E48181B341DE30F410E3EA407D005E5, ___getAreaSize_34)); }
	inline bool get_getAreaSize_34() const { return ___getAreaSize_34; }
	inline bool* get_address_of_getAreaSize_34() { return &___getAreaSize_34; }
	inline void set_getAreaSize_34(bool value)
	{
		___getAreaSize_34 = value;
	}

	inline static int32_t get_offset_of_initialX_35() { return static_cast<int32_t>(offsetof(MobilePaint_tC25928758E48181B341DE30F410E3EA407D005E5, ___initialX_35)); }
	inline int32_t get_initialX_35() const { return ___initialX_35; }
	inline int32_t* get_address_of_initialX_35() { return &___initialX_35; }
	inline void set_initialX_35(int32_t value)
	{
		___initialX_35 = value;
	}

	inline static int32_t get_offset_of_initialY_36() { return static_cast<int32_t>(offsetof(MobilePaint_tC25928758E48181B341DE30F410E3EA407D005E5, ___initialY_36)); }
	inline int32_t get_initialY_36() const { return ___initialY_36; }
	inline int32_t* get_address_of_initialY_36() { return &___initialY_36; }
	inline void set_initialY_36(int32_t value)
	{
		___initialY_36 = value;
	}

	inline static int32_t get_offset_of_AreaPaintedEvent_37() { return static_cast<int32_t>(offsetof(MobilePaint_tC25928758E48181B341DE30F410E3EA407D005E5, ___AreaPaintedEvent_37)); }
	inline AreaWasPainted_t537D2557735149202851C1AF691D54AA43D52E57 * get_AreaPaintedEvent_37() const { return ___AreaPaintedEvent_37; }
	inline AreaWasPainted_t537D2557735149202851C1AF691D54AA43D52E57 ** get_address_of_AreaPaintedEvent_37() { return &___AreaPaintedEvent_37; }
	inline void set_AreaPaintedEvent_37(AreaWasPainted_t537D2557735149202851C1AF691D54AA43D52E57 * value)
	{
		___AreaPaintedEvent_37 = value;
		Il2CppCodeGenWriteBarrier((&___AreaPaintedEvent_37), value);
	}

	inline static int32_t get_offset_of_lockMaskPixels_38() { return static_cast<int32_t>(offsetof(MobilePaint_tC25928758E48181B341DE30F410E3EA407D005E5, ___lockMaskPixels_38)); }
	inline ByteU5BU5D_tD06FDBE8142446525DF1C40351D523A228373821* get_lockMaskPixels_38() const { return ___lockMaskPixels_38; }
	inline ByteU5BU5D_tD06FDBE8142446525DF1C40351D523A228373821** get_address_of_lockMaskPixels_38() { return &___lockMaskPixels_38; }
	inline void set_lockMaskPixels_38(ByteU5BU5D_tD06FDBE8142446525DF1C40351D523A228373821* value)
	{
		___lockMaskPixels_38 = value;
		Il2CppCodeGenWriteBarrier((&___lockMaskPixels_38), value);
	}

	inline static int32_t get_offset_of_canDrawOnBlack_39() { return static_cast<int32_t>(offsetof(MobilePaint_tC25928758E48181B341DE30F410E3EA407D005E5, ___canDrawOnBlack_39)); }
	inline bool get_canDrawOnBlack_39() const { return ___canDrawOnBlack_39; }
	inline bool* get_address_of_canDrawOnBlack_39() { return &___canDrawOnBlack_39; }
	inline void set_canDrawOnBlack_39(bool value)
	{
		___canDrawOnBlack_39 = value;
	}

	inline static int32_t get_offset_of_canvasSizeAdjust_40() { return static_cast<int32_t>(offsetof(MobilePaint_tC25928758E48181B341DE30F410E3EA407D005E5, ___canvasSizeAdjust_40)); }
	inline Vector2_tA85D2DD88578276CA8A8796756458277E72D073D  get_canvasSizeAdjust_40() const { return ___canvasSizeAdjust_40; }
	inline Vector2_tA85D2DD88578276CA8A8796756458277E72D073D * get_address_of_canvasSizeAdjust_40() { return &___canvasSizeAdjust_40; }
	inline void set_canvasSizeAdjust_40(Vector2_tA85D2DD88578276CA8A8796756458277E72D073D  value)
	{
		___canvasSizeAdjust_40 = value;
	}

	inline static int32_t get_offset_of_targetTexture_41() { return static_cast<int32_t>(offsetof(MobilePaint_tC25928758E48181B341DE30F410E3EA407D005E5, ___targetTexture_41)); }
	inline String_t* get_targetTexture_41() const { return ___targetTexture_41; }
	inline String_t** get_address_of_targetTexture_41() { return &___targetTexture_41; }
	inline void set_targetTexture_41(String_t* value)
	{
		___targetTexture_41 = value;
		Il2CppCodeGenWriteBarrier((&___targetTexture_41), value);
	}

	inline static int32_t get_offset_of_filterMode_42() { return static_cast<int32_t>(offsetof(MobilePaint_tC25928758E48181B341DE30F410E3EA407D005E5, ___filterMode_42)); }
	inline int32_t get_filterMode_42() const { return ___filterMode_42; }
	inline int32_t* get_address_of_filterMode_42() { return &___filterMode_42; }
	inline void set_filterMode_42(int32_t value)
	{
		___filterMode_42 = value;
	}

	inline static int32_t get_offset_of_clearColor_43() { return static_cast<int32_t>(offsetof(MobilePaint_tC25928758E48181B341DE30F410E3EA407D005E5, ___clearColor_43)); }
	inline Color32_t23ABC4AE0E0BDFD2E22EE1FA0DA3904FFE5F6E23  get_clearColor_43() const { return ___clearColor_43; }
	inline Color32_t23ABC4AE0E0BDFD2E22EE1FA0DA3904FFE5F6E23 * get_address_of_clearColor_43() { return &___clearColor_43; }
	inline void set_clearColor_43(Color32_t23ABC4AE0E0BDFD2E22EE1FA0DA3904FFE5F6E23  value)
	{
		___clearColor_43 = value;
	}

	inline static int32_t get_offset_of_useMaskImage_44() { return static_cast<int32_t>(offsetof(MobilePaint_tC25928758E48181B341DE30F410E3EA407D005E5, ___useMaskImage_44)); }
	inline bool get_useMaskImage_44() const { return ___useMaskImage_44; }
	inline bool* get_address_of_useMaskImage_44() { return &___useMaskImage_44; }
	inline void set_useMaskImage_44(bool value)
	{
		___useMaskImage_44 = value;
	}

	inline static int32_t get_offset_of_maskTex_45() { return static_cast<int32_t>(offsetof(MobilePaint_tC25928758E48181B341DE30F410E3EA407D005E5, ___maskTex_45)); }
	inline Texture2D_tBBF96AC337723E2EF156DF17E09D4379FD05DE1C * get_maskTex_45() const { return ___maskTex_45; }
	inline Texture2D_tBBF96AC337723E2EF156DF17E09D4379FD05DE1C ** get_address_of_maskTex_45() { return &___maskTex_45; }
	inline void set_maskTex_45(Texture2D_tBBF96AC337723E2EF156DF17E09D4379FD05DE1C * value)
	{
		___maskTex_45 = value;
		Il2CppCodeGenWriteBarrier((&___maskTex_45), value);
	}

	inline static int32_t get_offset_of_useCustomBrushes_46() { return static_cast<int32_t>(offsetof(MobilePaint_tC25928758E48181B341DE30F410E3EA407D005E5, ___useCustomBrushes_46)); }
	inline bool get_useCustomBrushes_46() const { return ___useCustomBrushes_46; }
	inline bool* get_address_of_useCustomBrushes_46() { return &___useCustomBrushes_46; }
	inline void set_useCustomBrushes_46(bool value)
	{
		___useCustomBrushes_46 = value;
	}

	inline static int32_t get_offset_of_customBrushes_47() { return static_cast<int32_t>(offsetof(MobilePaint_tC25928758E48181B341DE30F410E3EA407D005E5, ___customBrushes_47)); }
	inline Texture2DU5BU5D_tCAC03055C735C020BAFC218D55183CF03E74C1C9* get_customBrushes_47() const { return ___customBrushes_47; }
	inline Texture2DU5BU5D_tCAC03055C735C020BAFC218D55183CF03E74C1C9** get_address_of_customBrushes_47() { return &___customBrushes_47; }
	inline void set_customBrushes_47(Texture2DU5BU5D_tCAC03055C735C020BAFC218D55183CF03E74C1C9* value)
	{
		___customBrushes_47 = value;
		Il2CppCodeGenWriteBarrier((&___customBrushes_47), value);
	}

	inline static int32_t get_offset_of_overrideCustomBrushColor_48() { return static_cast<int32_t>(offsetof(MobilePaint_tC25928758E48181B341DE30F410E3EA407D005E5, ___overrideCustomBrushColor_48)); }
	inline bool get_overrideCustomBrushColor_48() const { return ___overrideCustomBrushColor_48; }
	inline bool* get_address_of_overrideCustomBrushColor_48() { return &___overrideCustomBrushColor_48; }
	inline void set_overrideCustomBrushColor_48(bool value)
	{
		___overrideCustomBrushColor_48 = value;
	}

	inline static int32_t get_offset_of_useCustomBrushAlpha_49() { return static_cast<int32_t>(offsetof(MobilePaint_tC25928758E48181B341DE30F410E3EA407D005E5, ___useCustomBrushAlpha_49)); }
	inline bool get_useCustomBrushAlpha_49() const { return ___useCustomBrushAlpha_49; }
	inline bool* get_address_of_useCustomBrushAlpha_49() { return &___useCustomBrushAlpha_49; }
	inline void set_useCustomBrushAlpha_49(bool value)
	{
		___useCustomBrushAlpha_49 = value;
	}

	inline static int32_t get_offset_of_selectedBrush_50() { return static_cast<int32_t>(offsetof(MobilePaint_tC25928758E48181B341DE30F410E3EA407D005E5, ___selectedBrush_50)); }
	inline int32_t get_selectedBrush_50() const { return ___selectedBrush_50; }
	inline int32_t* get_address_of_selectedBrush_50() { return &___selectedBrush_50; }
	inline void set_selectedBrush_50(int32_t value)
	{
		___selectedBrush_50 = value;
	}

	inline static int32_t get_offset_of_customBrushBytes_51() { return static_cast<int32_t>(offsetof(MobilePaint_tC25928758E48181B341DE30F410E3EA407D005E5, ___customBrushBytes_51)); }
	inline ByteU5BU5D_tD06FDBE8142446525DF1C40351D523A228373821* get_customBrushBytes_51() const { return ___customBrushBytes_51; }
	inline ByteU5BU5D_tD06FDBE8142446525DF1C40351D523A228373821** get_address_of_customBrushBytes_51() { return &___customBrushBytes_51; }
	inline void set_customBrushBytes_51(ByteU5BU5D_tD06FDBE8142446525DF1C40351D523A228373821* value)
	{
		___customBrushBytes_51 = value;
		Il2CppCodeGenWriteBarrier((&___customBrushBytes_51), value);
	}

	inline static int32_t get_offset_of_customBrushWidth_52() { return static_cast<int32_t>(offsetof(MobilePaint_tC25928758E48181B341DE30F410E3EA407D005E5, ___customBrushWidth_52)); }
	inline int32_t get_customBrushWidth_52() const { return ___customBrushWidth_52; }
	inline int32_t* get_address_of_customBrushWidth_52() { return &___customBrushWidth_52; }
	inline void set_customBrushWidth_52(int32_t value)
	{
		___customBrushWidth_52 = value;
	}

	inline static int32_t get_offset_of_customBrushHeight_53() { return static_cast<int32_t>(offsetof(MobilePaint_tC25928758E48181B341DE30F410E3EA407D005E5, ___customBrushHeight_53)); }
	inline int32_t get_customBrushHeight_53() const { return ___customBrushHeight_53; }
	inline int32_t* get_address_of_customBrushHeight_53() { return &___customBrushHeight_53; }
	inline void set_customBrushHeight_53(int32_t value)
	{
		___customBrushHeight_53 = value;
	}

	inline static int32_t get_offset_of_customBrushWidthHalf_54() { return static_cast<int32_t>(offsetof(MobilePaint_tC25928758E48181B341DE30F410E3EA407D005E5, ___customBrushWidthHalf_54)); }
	inline int32_t get_customBrushWidthHalf_54() const { return ___customBrushWidthHalf_54; }
	inline int32_t* get_address_of_customBrushWidthHalf_54() { return &___customBrushWidthHalf_54; }
	inline void set_customBrushWidthHalf_54(int32_t value)
	{
		___customBrushWidthHalf_54 = value;
	}

	inline static int32_t get_offset_of_texWidthMinusCustomBrushWidth_55() { return static_cast<int32_t>(offsetof(MobilePaint_tC25928758E48181B341DE30F410E3EA407D005E5, ___texWidthMinusCustomBrushWidth_55)); }
	inline int32_t get_texWidthMinusCustomBrushWidth_55() const { return ___texWidthMinusCustomBrushWidth_55; }
	inline int32_t* get_address_of_texWidthMinusCustomBrushWidth_55() { return &___texWidthMinusCustomBrushWidth_55; }
	inline void set_texWidthMinusCustomBrushWidth_55(int32_t value)
	{
		___texWidthMinusCustomBrushWidth_55 = value;
	}

	inline static int32_t get_offset_of_texHeightMinusCustomBrushHeight_56() { return static_cast<int32_t>(offsetof(MobilePaint_tC25928758E48181B341DE30F410E3EA407D005E5, ___texHeightMinusCustomBrushHeight_56)); }
	inline int32_t get_texHeightMinusCustomBrushHeight_56() const { return ___texHeightMinusCustomBrushHeight_56; }
	inline int32_t* get_address_of_texHeightMinusCustomBrushHeight_56() { return &___texHeightMinusCustomBrushHeight_56; }
	inline void set_texHeightMinusCustomBrushHeight_56(int32_t value)
	{
		___texHeightMinusCustomBrushHeight_56 = value;
	}

	inline static int32_t get_offset_of_useCustomPatterns_57() { return static_cast<int32_t>(offsetof(MobilePaint_tC25928758E48181B341DE30F410E3EA407D005E5, ___useCustomPatterns_57)); }
	inline bool get_useCustomPatterns_57() const { return ___useCustomPatterns_57; }
	inline bool* get_address_of_useCustomPatterns_57() { return &___useCustomPatterns_57; }
	inline void set_useCustomPatterns_57(bool value)
	{
		___useCustomPatterns_57 = value;
	}

	inline static int32_t get_offset_of_customPatterns_58() { return static_cast<int32_t>(offsetof(MobilePaint_tC25928758E48181B341DE30F410E3EA407D005E5, ___customPatterns_58)); }
	inline Texture2DU5BU5D_tCAC03055C735C020BAFC218D55183CF03E74C1C9* get_customPatterns_58() const { return ___customPatterns_58; }
	inline Texture2DU5BU5D_tCAC03055C735C020BAFC218D55183CF03E74C1C9** get_address_of_customPatterns_58() { return &___customPatterns_58; }
	inline void set_customPatterns_58(Texture2DU5BU5D_tCAC03055C735C020BAFC218D55183CF03E74C1C9* value)
	{
		___customPatterns_58 = value;
		Il2CppCodeGenWriteBarrier((&___customPatterns_58), value);
	}

	inline static int32_t get_offset_of_patternBrushBytes_59() { return static_cast<int32_t>(offsetof(MobilePaint_tC25928758E48181B341DE30F410E3EA407D005E5, ___patternBrushBytes_59)); }
	inline ByteU5BU5D_tD06FDBE8142446525DF1C40351D523A228373821* get_patternBrushBytes_59() const { return ___patternBrushBytes_59; }
	inline ByteU5BU5D_tD06FDBE8142446525DF1C40351D523A228373821** get_address_of_patternBrushBytes_59() { return &___patternBrushBytes_59; }
	inline void set_patternBrushBytes_59(ByteU5BU5D_tD06FDBE8142446525DF1C40351D523A228373821* value)
	{
		___patternBrushBytes_59 = value;
		Il2CppCodeGenWriteBarrier((&___patternBrushBytes_59), value);
	}

	inline static int32_t get_offset_of_customPatternWidth_60() { return static_cast<int32_t>(offsetof(MobilePaint_tC25928758E48181B341DE30F410E3EA407D005E5, ___customPatternWidth_60)); }
	inline int32_t get_customPatternWidth_60() const { return ___customPatternWidth_60; }
	inline int32_t* get_address_of_customPatternWidth_60() { return &___customPatternWidth_60; }
	inline void set_customPatternWidth_60(int32_t value)
	{
		___customPatternWidth_60 = value;
	}

	inline static int32_t get_offset_of_customPatternHeight_61() { return static_cast<int32_t>(offsetof(MobilePaint_tC25928758E48181B341DE30F410E3EA407D005E5, ___customPatternHeight_61)); }
	inline int32_t get_customPatternHeight_61() const { return ___customPatternHeight_61; }
	inline int32_t* get_address_of_customPatternHeight_61() { return &___customPatternHeight_61; }
	inline void set_customPatternHeight_61(int32_t value)
	{
		___customPatternHeight_61 = value;
	}

	inline static int32_t get_offset_of_selectedPattern_62() { return static_cast<int32_t>(offsetof(MobilePaint_tC25928758E48181B341DE30F410E3EA407D005E5, ___selectedPattern_62)); }
	inline int32_t get_selectedPattern_62() const { return ___selectedPattern_62; }
	inline int32_t* get_address_of_selectedPattern_62() { return &___selectedPattern_62; }
	inline void set_selectedPattern_62(int32_t value)
	{
		___selectedPattern_62 = value;
	}

	inline static int32_t get_offset_of_previewLineCircle_63() { return static_cast<int32_t>(offsetof(MobilePaint_tC25928758E48181B341DE30F410E3EA407D005E5, ___previewLineCircle_63)); }
	inline Transform_tBB9E78A2766C3C83599A8F66EDE7D1FCAFC66EDA * get_previewLineCircle_63() const { return ___previewLineCircle_63; }
	inline Transform_tBB9E78A2766C3C83599A8F66EDE7D1FCAFC66EDA ** get_address_of_previewLineCircle_63() { return &___previewLineCircle_63; }
	inline void set_previewLineCircle_63(Transform_tBB9E78A2766C3C83599A8F66EDE7D1FCAFC66EDA * value)
	{
		___previewLineCircle_63 = value;
		Il2CppCodeGenWriteBarrier((&___previewLineCircle_63), value);
	}

	inline static int32_t get_offset_of_previewLineCircleStart_64() { return static_cast<int32_t>(offsetof(MobilePaint_tC25928758E48181B341DE30F410E3EA407D005E5, ___previewLineCircleStart_64)); }
	inline Transform_tBB9E78A2766C3C83599A8F66EDE7D1FCAFC66EDA * get_previewLineCircleStart_64() const { return ___previewLineCircleStart_64; }
	inline Transform_tBB9E78A2766C3C83599A8F66EDE7D1FCAFC66EDA ** get_address_of_previewLineCircleStart_64() { return &___previewLineCircleStart_64; }
	inline void set_previewLineCircleStart_64(Transform_tBB9E78A2766C3C83599A8F66EDE7D1FCAFC66EDA * value)
	{
		___previewLineCircleStart_64 = value;
		Il2CppCodeGenWriteBarrier((&___previewLineCircleStart_64), value);
	}

	inline static int32_t get_offset_of_previewLineCircleEnd_65() { return static_cast<int32_t>(offsetof(MobilePaint_tC25928758E48181B341DE30F410E3EA407D005E5, ___previewLineCircleEnd_65)); }
	inline Transform_tBB9E78A2766C3C83599A8F66EDE7D1FCAFC66EDA * get_previewLineCircleEnd_65() const { return ___previewLineCircleEnd_65; }
	inline Transform_tBB9E78A2766C3C83599A8F66EDE7D1FCAFC66EDA ** get_address_of_previewLineCircleEnd_65() { return &___previewLineCircleEnd_65; }
	inline void set_previewLineCircleEnd_65(Transform_tBB9E78A2766C3C83599A8F66EDE7D1FCAFC66EDA * value)
	{
		___previewLineCircleEnd_65 = value;
		Il2CppCodeGenWriteBarrier((&___previewLineCircleEnd_65), value);
	}

	inline static int32_t get_offset_of_haveStartedLine_66() { return static_cast<int32_t>(offsetof(MobilePaint_tC25928758E48181B341DE30F410E3EA407D005E5, ___haveStartedLine_66)); }
	inline bool get_haveStartedLine_66() const { return ___haveStartedLine_66; }
	inline bool* get_address_of_haveStartedLine_66() { return &___haveStartedLine_66; }
	inline void set_haveStartedLine_66(bool value)
	{
		___haveStartedLine_66 = value;
	}

	inline static int32_t get_offset_of_firstClickX_67() { return static_cast<int32_t>(offsetof(MobilePaint_tC25928758E48181B341DE30F410E3EA407D005E5, ___firstClickX_67)); }
	inline int32_t get_firstClickX_67() const { return ___firstClickX_67; }
	inline int32_t* get_address_of_firstClickX_67() { return &___firstClickX_67; }
	inline void set_firstClickX_67(int32_t value)
	{
		___firstClickX_67 = value;
	}

	inline static int32_t get_offset_of_firstClickY_68() { return static_cast<int32_t>(offsetof(MobilePaint_tC25928758E48181B341DE30F410E3EA407D005E5, ___firstClickY_68)); }
	inline int32_t get_firstClickY_68() const { return ___firstClickY_68; }
	inline int32_t* get_address_of_firstClickY_68() { return &___firstClickY_68; }
	inline void set_firstClickY_68(int32_t value)
	{
		___firstClickY_68 = value;
	}

	inline static int32_t get_offset_of_lineRenderer_69() { return static_cast<int32_t>(offsetof(MobilePaint_tC25928758E48181B341DE30F410E3EA407D005E5, ___lineRenderer_69)); }
	inline LineRenderer_tD225C480F28F28A4D737866474F21001B803B7C3 * get_lineRenderer_69() const { return ___lineRenderer_69; }
	inline LineRenderer_tD225C480F28F28A4D737866474F21001B803B7C3 ** get_address_of_lineRenderer_69() { return &___lineRenderer_69; }
	inline void set_lineRenderer_69(LineRenderer_tD225C480F28F28A4D737866474F21001B803B7C3 * value)
	{
		___lineRenderer_69 = value;
		Il2CppCodeGenWriteBarrier((&___lineRenderer_69), value);
	}

	inline static int32_t get_offset_of_snapLinesToGrid_70() { return static_cast<int32_t>(offsetof(MobilePaint_tC25928758E48181B341DE30F410E3EA407D005E5, ___snapLinesToGrid_70)); }
	inline bool get_snapLinesToGrid_70() const { return ___snapLinesToGrid_70; }
	inline bool* get_address_of_snapLinesToGrid_70() { return &___snapLinesToGrid_70; }
	inline void set_snapLinesToGrid_70(bool value)
	{
		___snapLinesToGrid_70 = value;
	}

	inline static int32_t get_offset_of_gridResolution_71() { return static_cast<int32_t>(offsetof(MobilePaint_tC25928758E48181B341DE30F410E3EA407D005E5, ___gridResolution_71)); }
	inline int32_t get_gridResolution_71() const { return ___gridResolution_71; }
	inline int32_t* get_address_of_gridResolution_71() { return &___gridResolution_71; }
	inline void set_gridResolution_71(int32_t value)
	{
		___gridResolution_71 = value;
	}

	inline static int32_t get_offset_of_gridSize_72() { return static_cast<int32_t>(offsetof(MobilePaint_tC25928758E48181B341DE30F410E3EA407D005E5, ___gridSize_72)); }
	inline int32_t get_gridSize_72() const { return ___gridSize_72; }
	inline int32_t* get_address_of_gridSize_72() { return &___gridSize_72; }
	inline void set_gridSize_72(int32_t value)
	{
		___gridSize_72 = value;
	}

	inline static int32_t get_offset_of_scaleAdjust_73() { return static_cast<int32_t>(offsetof(MobilePaint_tC25928758E48181B341DE30F410E3EA407D005E5, ___scaleAdjust_73)); }
	inline float get_scaleAdjust_73() const { return ___scaleAdjust_73; }
	inline float* get_address_of_scaleAdjust_73() { return &___scaleAdjust_73; }
	inline void set_scaleAdjust_73(float value)
	{
		___scaleAdjust_73 = value;
	}

	inline static int32_t get_offset_of_pixels_76() { return static_cast<int32_t>(offsetof(MobilePaint_tC25928758E48181B341DE30F410E3EA407D005E5, ___pixels_76)); }
	inline ByteU5BU5D_tD06FDBE8142446525DF1C40351D523A228373821* get_pixels_76() const { return ___pixels_76; }
	inline ByteU5BU5D_tD06FDBE8142446525DF1C40351D523A228373821** get_address_of_pixels_76() { return &___pixels_76; }
	inline void set_pixels_76(ByteU5BU5D_tD06FDBE8142446525DF1C40351D523A228373821* value)
	{
		___pixels_76 = value;
		Il2CppCodeGenWriteBarrier((&___pixels_76), value);
	}

	inline static int32_t get_offset_of_maskPixels_77() { return static_cast<int32_t>(offsetof(MobilePaint_tC25928758E48181B341DE30F410E3EA407D005E5, ___maskPixels_77)); }
	inline ByteU5BU5D_tD06FDBE8142446525DF1C40351D523A228373821* get_maskPixels_77() const { return ___maskPixels_77; }
	inline ByteU5BU5D_tD06FDBE8142446525DF1C40351D523A228373821** get_address_of_maskPixels_77() { return &___maskPixels_77; }
	inline void set_maskPixels_77(ByteU5BU5D_tD06FDBE8142446525DF1C40351D523A228373821* value)
	{
		___maskPixels_77 = value;
		Il2CppCodeGenWriteBarrier((&___maskPixels_77), value);
	}

	inline static int32_t get_offset_of_clearPixels_78() { return static_cast<int32_t>(offsetof(MobilePaint_tC25928758E48181B341DE30F410E3EA407D005E5, ___clearPixels_78)); }
	inline ByteU5BU5D_tD06FDBE8142446525DF1C40351D523A228373821* get_clearPixels_78() const { return ___clearPixels_78; }
	inline ByteU5BU5D_tD06FDBE8142446525DF1C40351D523A228373821** get_address_of_clearPixels_78() { return &___clearPixels_78; }
	inline void set_clearPixels_78(ByteU5BU5D_tD06FDBE8142446525DF1C40351D523A228373821* value)
	{
		___clearPixels_78 = value;
		Il2CppCodeGenWriteBarrier((&___clearPixels_78), value);
	}

	inline static int32_t get_offset_of_drawingTexture_79() { return static_cast<int32_t>(offsetof(MobilePaint_tC25928758E48181B341DE30F410E3EA407D005E5, ___drawingTexture_79)); }
	inline Texture2D_tBBF96AC337723E2EF156DF17E09D4379FD05DE1C * get_drawingTexture_79() const { return ___drawingTexture_79; }
	inline Texture2D_tBBF96AC337723E2EF156DF17E09D4379FD05DE1C ** get_address_of_drawingTexture_79() { return &___drawingTexture_79; }
	inline void set_drawingTexture_79(Texture2D_tBBF96AC337723E2EF156DF17E09D4379FD05DE1C * value)
	{
		___drawingTexture_79 = value;
		Il2CppCodeGenWriteBarrier((&___drawingTexture_79), value);
	}

	inline static int32_t get_offset_of_resolutionScaler_80() { return static_cast<int32_t>(offsetof(MobilePaint_tC25928758E48181B341DE30F410E3EA407D005E5, ___resolutionScaler_80)); }
	inline float get_resolutionScaler_80() const { return ___resolutionScaler_80; }
	inline float* get_address_of_resolutionScaler_80() { return &___resolutionScaler_80; }
	inline void set_resolutionScaler_80(float value)
	{
		___resolutionScaler_80 = value;
	}

	inline static int32_t get_offset_of_overrideResolution_81() { return static_cast<int32_t>(offsetof(MobilePaint_tC25928758E48181B341DE30F410E3EA407D005E5, ___overrideResolution_81)); }
	inline bool get_overrideResolution_81() const { return ___overrideResolution_81; }
	inline bool* get_address_of_overrideResolution_81() { return &___overrideResolution_81; }
	inline void set_overrideResolution_81(bool value)
	{
		___overrideResolution_81 = value;
	}

	inline static int32_t get_offset_of_overrideWidth_82() { return static_cast<int32_t>(offsetof(MobilePaint_tC25928758E48181B341DE30F410E3EA407D005E5, ___overrideWidth_82)); }
	inline int32_t get_overrideWidth_82() const { return ___overrideWidth_82; }
	inline int32_t* get_address_of_overrideWidth_82() { return &___overrideWidth_82; }
	inline void set_overrideWidth_82(int32_t value)
	{
		___overrideWidth_82 = value;
	}

	inline static int32_t get_offset_of_overrideHeight_83() { return static_cast<int32_t>(offsetof(MobilePaint_tC25928758E48181B341DE30F410E3EA407D005E5, ___overrideHeight_83)); }
	inline int32_t get_overrideHeight_83() const { return ___overrideHeight_83; }
	inline int32_t* get_address_of_overrideHeight_83() { return &___overrideHeight_83; }
	inline void set_overrideHeight_83(int32_t value)
	{
		___overrideHeight_83 = value;
	}

	inline static int32_t get_offset_of_texWidth_84() { return static_cast<int32_t>(offsetof(MobilePaint_tC25928758E48181B341DE30F410E3EA407D005E5, ___texWidth_84)); }
	inline int32_t get_texWidth_84() const { return ___texWidth_84; }
	inline int32_t* get_address_of_texWidth_84() { return &___texWidth_84; }
	inline void set_texWidth_84(int32_t value)
	{
		___texWidth_84 = value;
	}

	inline static int32_t get_offset_of_texHeight_85() { return static_cast<int32_t>(offsetof(MobilePaint_tC25928758E48181B341DE30F410E3EA407D005E5, ___texHeight_85)); }
	inline int32_t get_texHeight_85() const { return ___texHeight_85; }
	inline int32_t* get_address_of_texHeight_85() { return &___texHeight_85; }
	inline void set_texHeight_85(int32_t value)
	{
		___texHeight_85 = value;
	}

	inline static int32_t get_offset_of_touch_86() { return static_cast<int32_t>(offsetof(MobilePaint_tC25928758E48181B341DE30F410E3EA407D005E5, ___touch_86)); }
	inline Touch_t806752C775BA713A91B6588A07CA98417CABC003  get_touch_86() const { return ___touch_86; }
	inline Touch_t806752C775BA713A91B6588A07CA98417CABC003 * get_address_of_touch_86() { return &___touch_86; }
	inline void set_touch_86(Touch_t806752C775BA713A91B6588A07CA98417CABC003  value)
	{
		___touch_86 = value;
	}

	inline static int32_t get_offset_of_wasTouching_87() { return static_cast<int32_t>(offsetof(MobilePaint_tC25928758E48181B341DE30F410E3EA407D005E5, ___wasTouching_87)); }
	inline bool get_wasTouching_87() const { return ___wasTouching_87; }
	inline bool* get_address_of_wasTouching_87() { return &___wasTouching_87; }
	inline void set_wasTouching_87(bool value)
	{
		___wasTouching_87 = value;
	}

	inline static int32_t get_offset_of_cam_88() { return static_cast<int32_t>(offsetof(MobilePaint_tC25928758E48181B341DE30F410E3EA407D005E5, ___cam_88)); }
	inline Camera_t48B2B9ECB3CE6108A98BF949A1CECF0FE3421F34 * get_cam_88() const { return ___cam_88; }
	inline Camera_t48B2B9ECB3CE6108A98BF949A1CECF0FE3421F34 ** get_address_of_cam_88() { return &___cam_88; }
	inline void set_cam_88(Camera_t48B2B9ECB3CE6108A98BF949A1CECF0FE3421F34 * value)
	{
		___cam_88 = value;
		Il2CppCodeGenWriteBarrier((&___cam_88), value);
	}

	inline static int32_t get_offset_of_myRenderer_89() { return static_cast<int32_t>(offsetof(MobilePaint_tC25928758E48181B341DE30F410E3EA407D005E5, ___myRenderer_89)); }
	inline Renderer_t0556D67DD582620D1F495627EDE30D03284151F4 * get_myRenderer_89() const { return ___myRenderer_89; }
	inline Renderer_t0556D67DD582620D1F495627EDE30D03284151F4 ** get_address_of_myRenderer_89() { return &___myRenderer_89; }
	inline void set_myRenderer_89(Renderer_t0556D67DD582620D1F495627EDE30D03284151F4 * value)
	{
		___myRenderer_89 = value;
		Il2CppCodeGenWriteBarrier((&___myRenderer_89), value);
	}

	inline static int32_t get_offset_of_hit_90() { return static_cast<int32_t>(offsetof(MobilePaint_tC25928758E48181B341DE30F410E3EA407D005E5, ___hit_90)); }
	inline RaycastHit_t19695F18F9265FE5425062BBA6A4D330480538C3  get_hit_90() const { return ___hit_90; }
	inline RaycastHit_t19695F18F9265FE5425062BBA6A4D330480538C3 * get_address_of_hit_90() { return &___hit_90; }
	inline void set_hit_90(RaycastHit_t19695F18F9265FE5425062BBA6A4D330480538C3  value)
	{
		___hit_90 = value;
	}

	inline static int32_t get_offset_of_wentOutside_91() { return static_cast<int32_t>(offsetof(MobilePaint_tC25928758E48181B341DE30F410E3EA407D005E5, ___wentOutside_91)); }
	inline bool get_wentOutside_91() const { return ___wentOutside_91; }
	inline bool* get_address_of_wentOutside_91() { return &___wentOutside_91; }
	inline void set_wentOutside_91(bool value)
	{
		___wentOutside_91 = value;
	}

	inline static int32_t get_offset_of_usingClearingImage_92() { return static_cast<int32_t>(offsetof(MobilePaint_tC25928758E48181B341DE30F410E3EA407D005E5, ___usingClearingImage_92)); }
	inline bool get_usingClearingImage_92() const { return ___usingClearingImage_92; }
	inline bool* get_address_of_usingClearingImage_92() { return &___usingClearingImage_92; }
	inline void set_usingClearingImage_92(bool value)
	{
		___usingClearingImage_92 = value;
	}

	inline static int32_t get_offset_of_pixelUV_93() { return static_cast<int32_t>(offsetof(MobilePaint_tC25928758E48181B341DE30F410E3EA407D005E5, ___pixelUV_93)); }
	inline Vector2_tA85D2DD88578276CA8A8796756458277E72D073D  get_pixelUV_93() const { return ___pixelUV_93; }
	inline Vector2_tA85D2DD88578276CA8A8796756458277E72D073D * get_address_of_pixelUV_93() { return &___pixelUV_93; }
	inline void set_pixelUV_93(Vector2_tA85D2DD88578276CA8A8796756458277E72D073D  value)
	{
		___pixelUV_93 = value;
	}

	inline static int32_t get_offset_of_pixelUVOld_94() { return static_cast<int32_t>(offsetof(MobilePaint_tC25928758E48181B341DE30F410E3EA407D005E5, ___pixelUVOld_94)); }
	inline Vector2_tA85D2DD88578276CA8A8796756458277E72D073D  get_pixelUVOld_94() const { return ___pixelUVOld_94; }
	inline Vector2_tA85D2DD88578276CA8A8796756458277E72D073D * get_address_of_pixelUVOld_94() { return &___pixelUVOld_94; }
	inline void set_pixelUVOld_94(Vector2_tA85D2DD88578276CA8A8796756458277E72D073D  value)
	{
		___pixelUVOld_94 = value;
	}

	inline static int32_t get_offset_of_pixelUVs_95() { return static_cast<int32_t>(offsetof(MobilePaint_tC25928758E48181B341DE30F410E3EA407D005E5, ___pixelUVs_95)); }
	inline Vector2U5BU5D_tA065A07DFC060C1B8786BBAA5F3A6577CCEB27D6* get_pixelUVs_95() const { return ___pixelUVs_95; }
	inline Vector2U5BU5D_tA065A07DFC060C1B8786BBAA5F3A6577CCEB27D6** get_address_of_pixelUVs_95() { return &___pixelUVs_95; }
	inline void set_pixelUVs_95(Vector2U5BU5D_tA065A07DFC060C1B8786BBAA5F3A6577CCEB27D6* value)
	{
		___pixelUVs_95 = value;
		Il2CppCodeGenWriteBarrier((&___pixelUVs_95), value);
	}

	inline static int32_t get_offset_of_pixelUVOlds_96() { return static_cast<int32_t>(offsetof(MobilePaint_tC25928758E48181B341DE30F410E3EA407D005E5, ___pixelUVOlds_96)); }
	inline Vector2U5BU5D_tA065A07DFC060C1B8786BBAA5F3A6577CCEB27D6* get_pixelUVOlds_96() const { return ___pixelUVOlds_96; }
	inline Vector2U5BU5D_tA065A07DFC060C1B8786BBAA5F3A6577CCEB27D6** get_address_of_pixelUVOlds_96() { return &___pixelUVOlds_96; }
	inline void set_pixelUVOlds_96(Vector2U5BU5D_tA065A07DFC060C1B8786BBAA5F3A6577CCEB27D6* value)
	{
		___pixelUVOlds_96 = value;
		Il2CppCodeGenWriteBarrier((&___pixelUVOlds_96), value);
	}

	inline static int32_t get_offset_of_textureNeedsUpdate_97() { return static_cast<int32_t>(offsetof(MobilePaint_tC25928758E48181B341DE30F410E3EA407D005E5, ___textureNeedsUpdate_97)); }
	inline bool get_textureNeedsUpdate_97() const { return ___textureNeedsUpdate_97; }
	inline bool* get_address_of_textureNeedsUpdate_97() { return &___textureNeedsUpdate_97; }
	inline void set_textureNeedsUpdate_97(bool value)
	{
		___textureNeedsUpdate_97 = value;
	}

	inline static int32_t get_offset_of_undoEnabled_98() { return static_cast<int32_t>(offsetof(MobilePaint_tC25928758E48181B341DE30F410E3EA407D005E5, ___undoEnabled_98)); }
	inline bool get_undoEnabled_98() const { return ___undoEnabled_98; }
	inline bool* get_address_of_undoEnabled_98() { return &___undoEnabled_98; }
	inline void set_undoEnabled_98(bool value)
	{
		___undoEnabled_98 = value;
	}

	inline static int32_t get_offset_of_undoPixels_99() { return static_cast<int32_t>(offsetof(MobilePaint_tC25928758E48181B341DE30F410E3EA407D005E5, ___undoPixels_99)); }
	inline List_1_t8BE041DC5257EA95B6376B45901D0D957BCF7CEC * get_undoPixels_99() const { return ___undoPixels_99; }
	inline List_1_t8BE041DC5257EA95B6376B45901D0D957BCF7CEC ** get_address_of_undoPixels_99() { return &___undoPixels_99; }
	inline void set_undoPixels_99(List_1_t8BE041DC5257EA95B6376B45901D0D957BCF7CEC * value)
	{
		___undoPixels_99 = value;
		Il2CppCodeGenWriteBarrier((&___undoPixels_99), value);
	}

	inline static int32_t get_offset_of_maxUndoBuffers_100() { return static_cast<int32_t>(offsetof(MobilePaint_tC25928758E48181B341DE30F410E3EA407D005E5, ___maxUndoBuffers_100)); }
	inline int32_t get_maxUndoBuffers_100() const { return ___maxUndoBuffers_100; }
	inline int32_t* get_address_of_maxUndoBuffers_100() { return &___maxUndoBuffers_100; }
	inline void set_maxUndoBuffers_100(int32_t value)
	{
		___maxUndoBuffers_100 = value;
	}

	inline static int32_t get_offset_of_userInterface_101() { return static_cast<int32_t>(offsetof(MobilePaint_tC25928758E48181B341DE30F410E3EA407D005E5, ___userInterface_101)); }
	inline GameObject_tBD1244AD56B4E59AAD76E5E7C9282EC5CE434F0F * get_userInterface_101() const { return ___userInterface_101; }
	inline GameObject_tBD1244AD56B4E59AAD76E5E7C9282EC5CE434F0F ** get_address_of_userInterface_101() { return &___userInterface_101; }
	inline void set_userInterface_101(GameObject_tBD1244AD56B4E59AAD76E5E7C9282EC5CE434F0F * value)
	{
		___userInterface_101 = value;
		Il2CppCodeGenWriteBarrier((&___userInterface_101), value);
	}

	inline static int32_t get_offset_of_hideUIWhilePainting_102() { return static_cast<int32_t>(offsetof(MobilePaint_tC25928758E48181B341DE30F410E3EA407D005E5, ___hideUIWhilePainting_102)); }
	inline bool get_hideUIWhilePainting_102() const { return ___hideUIWhilePainting_102; }
	inline bool* get_address_of_hideUIWhilePainting_102() { return &___hideUIWhilePainting_102; }
	inline void set_hideUIWhilePainting_102(bool value)
	{
		___hideUIWhilePainting_102 = value;
	}

	inline static int32_t get_offset_of_isUIVisible_103() { return static_cast<int32_t>(offsetof(MobilePaint_tC25928758E48181B341DE30F410E3EA407D005E5, ___isUIVisible_103)); }
	inline bool get_isUIVisible_103() const { return ___isUIVisible_103; }
	inline bool* get_address_of_isUIVisible_103() { return &___isUIVisible_103; }
	inline void set_isUIVisible_103(bool value)
	{
		___isUIVisible_103 = value;
	}

	inline static int32_t get_offset_of_debugMode_104() { return static_cast<int32_t>(offsetof(MobilePaint_tC25928758E48181B341DE30F410E3EA407D005E5, ___debugMode_104)); }
	inline bool get_debugMode_104() const { return ___debugMode_104; }
	inline bool* get_address_of_debugMode_104() { return &___debugMode_104; }
	inline void set_debugMode_104(bool value)
	{
		___debugMode_104 = value;
	}

	inline static int32_t get_offset_of_eventSystem_105() { return static_cast<int32_t>(offsetof(MobilePaint_tC25928758E48181B341DE30F410E3EA407D005E5, ___eventSystem_105)); }
	inline EventSystem_t06ACEF1C8D95D44D3A7F57ED4BAA577101B4EA77 * get_eventSystem_105() const { return ___eventSystem_105; }
	inline EventSystem_t06ACEF1C8D95D44D3A7F57ED4BAA577101B4EA77 ** get_address_of_eventSystem_105() { return &___eventSystem_105; }
	inline void set_eventSystem_105(EventSystem_t06ACEF1C8D95D44D3A7F57ED4BAA577101B4EA77 * value)
	{
		___eventSystem_105 = value;
		Il2CppCodeGenWriteBarrier((&___eventSystem_105), value);
	}

	inline static int32_t get_offset_of_isZoomingOrPanning_106() { return static_cast<int32_t>(offsetof(MobilePaint_tC25928758E48181B341DE30F410E3EA407D005E5, ___isZoomingOrPanning_106)); }
	inline bool get_isZoomingOrPanning_106() const { return ___isZoomingOrPanning_106; }
	inline bool* get_address_of_isZoomingOrPanning_106() { return &___isZoomingOrPanning_106; }
	inline void set_isZoomingOrPanning_106(bool value)
	{
		___isZoomingOrPanning_106 = value;
	}

	inline static int32_t get_offset_of_i_107() { return static_cast<int32_t>(offsetof(MobilePaint_tC25928758E48181B341DE30F410E3EA407D005E5, ___i_107)); }
	inline int32_t get_i_107() const { return ___i_107; }
	inline int32_t* get_address_of_i_107() { return &___i_107; }
	inline void set_i_107(int32_t value)
	{
		___i_107 = value;
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
#endif // MOBILEPAINT_TC25928758E48181B341DE30F410E3EA407D005E5_H
#ifndef PAINTMANAGER_T8C7F3BD113E1D28F982A05D0397A369E09266BEE_H
#define PAINTMANAGER_T8C7F3BD113E1D28F982A05D0397A369E09266BEE_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// unitycoder_MobilePaint.PaintManager
struct  PaintManager_t8C7F3BD113E1D28F982A05D0397A369E09266BEE  : public MonoBehaviour_t4A60845CF505405AF8BE8C61CC07F75CADEF6429
{
public:
	// unitycoder_MobilePaint.MobilePaint unitycoder_MobilePaint.PaintManager::mobilePaintReference
	MobilePaint_tC25928758E48181B341DE30F410E3EA407D005E5 * ___mobilePaintReference_4;

public:
	inline static int32_t get_offset_of_mobilePaintReference_4() { return static_cast<int32_t>(offsetof(PaintManager_t8C7F3BD113E1D28F982A05D0397A369E09266BEE, ___mobilePaintReference_4)); }
	inline MobilePaint_tC25928758E48181B341DE30F410E3EA407D005E5 * get_mobilePaintReference_4() const { return ___mobilePaintReference_4; }
	inline MobilePaint_tC25928758E48181B341DE30F410E3EA407D005E5 ** get_address_of_mobilePaintReference_4() { return &___mobilePaintReference_4; }
	inline void set_mobilePaintReference_4(MobilePaint_tC25928758E48181B341DE30F410E3EA407D005E5 * value)
	{
		___mobilePaintReference_4 = value;
		Il2CppCodeGenWriteBarrier((&___mobilePaintReference_4), value);
	}
};

struct PaintManager_t8C7F3BD113E1D28F982A05D0397A369E09266BEE_StaticFields
{
public:
	// unitycoder_MobilePaint.MobilePaint unitycoder_MobilePaint.PaintManager::mobilePaint
	MobilePaint_tC25928758E48181B341DE30F410E3EA407D005E5 * ___mobilePaint_5;

public:
	inline static int32_t get_offset_of_mobilePaint_5() { return static_cast<int32_t>(offsetof(PaintManager_t8C7F3BD113E1D28F982A05D0397A369E09266BEE_StaticFields, ___mobilePaint_5)); }
	inline MobilePaint_tC25928758E48181B341DE30F410E3EA407D005E5 * get_mobilePaint_5() const { return ___mobilePaint_5; }
	inline MobilePaint_tC25928758E48181B341DE30F410E3EA407D005E5 ** get_address_of_mobilePaint_5() { return &___mobilePaint_5; }
	inline void set_mobilePaint_5(MobilePaint_tC25928758E48181B341DE30F410E3EA407D005E5 * value)
	{
		___mobilePaint_5 = value;
		Il2CppCodeGenWriteBarrier((&___mobilePaint_5), value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
#endif // PAINTMANAGER_T8C7F3BD113E1D28F982A05D0397A369E09266BEE_H
#ifndef SETNEWCANVASIMAGEEXAMPLE_TABE5A79B521E9F4F1676A55FC042C693FB2647D7_H
#define SETNEWCANVASIMAGEEXAMPLE_TABE5A79B521E9F4F1676A55FC042C693FB2647D7_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// unitycoder_MobilePaint.SetNewCanvasImageExample
struct  SetNewCanvasImageExample_tABE5A79B521E9F4F1676A55FC042C693FB2647D7  : public MonoBehaviour_t4A60845CF505405AF8BE8C61CC07F75CADEF6429
{
public:
	// unitycoder_MobilePaint.MobilePaint unitycoder_MobilePaint.SetNewCanvasImageExample::mobilePaint
	MobilePaint_tC25928758E48181B341DE30F410E3EA407D005E5 * ___mobilePaint_4;
	// UnityEngine.Texture2D[] unitycoder_MobilePaint.SetNewCanvasImageExample::images
	Texture2DU5BU5D_tCAC03055C735C020BAFC218D55183CF03E74C1C9* ___images_5;
	// System.Int32 unitycoder_MobilePaint.SetNewCanvasImageExample::index
	int32_t ___index_6;

public:
	inline static int32_t get_offset_of_mobilePaint_4() { return static_cast<int32_t>(offsetof(SetNewCanvasImageExample_tABE5A79B521E9F4F1676A55FC042C693FB2647D7, ___mobilePaint_4)); }
	inline MobilePaint_tC25928758E48181B341DE30F410E3EA407D005E5 * get_mobilePaint_4() const { return ___mobilePaint_4; }
	inline MobilePaint_tC25928758E48181B341DE30F410E3EA407D005E5 ** get_address_of_mobilePaint_4() { return &___mobilePaint_4; }
	inline void set_mobilePaint_4(MobilePaint_tC25928758E48181B341DE30F410E3EA407D005E5 * value)
	{
		___mobilePaint_4 = value;
		Il2CppCodeGenWriteBarrier((&___mobilePaint_4), value);
	}

	inline static int32_t get_offset_of_images_5() { return static_cast<int32_t>(offsetof(SetNewCanvasImageExample_tABE5A79B521E9F4F1676A55FC042C693FB2647D7, ___images_5)); }
	inline Texture2DU5BU5D_tCAC03055C735C020BAFC218D55183CF03E74C1C9* get_images_5() const { return ___images_5; }
	inline Texture2DU5BU5D_tCAC03055C735C020BAFC218D55183CF03E74C1C9** get_address_of_images_5() { return &___images_5; }
	inline void set_images_5(Texture2DU5BU5D_tCAC03055C735C020BAFC218D55183CF03E74C1C9* value)
	{
		___images_5 = value;
		Il2CppCodeGenWriteBarrier((&___images_5), value);
	}

	inline static int32_t get_offset_of_index_6() { return static_cast<int32_t>(offsetof(SetNewCanvasImageExample_tABE5A79B521E9F4F1676A55FC042C693FB2647D7, ___index_6)); }
	inline int32_t get_index_6() const { return ___index_6; }
	inline int32_t* get_address_of_index_6() { return &___index_6; }
	inline void set_index_6(int32_t value)
	{
		___index_6 = value;
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
#endif // SETNEWCANVASIMAGEEXAMPLE_TABE5A79B521E9F4F1676A55FC042C693FB2647D7_H
#ifndef SETNEWMASKIMAGE_T27DC57C9D9F2DC004D6F077B092BC52CE8D0AE8A_H
#define SETNEWMASKIMAGE_T27DC57C9D9F2DC004D6F077B092BC52CE8D0AE8A_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// unitycoder_MobilePaint.SetNewMaskImage
struct  SetNewMaskImage_t27DC57C9D9F2DC004D6F077B092BC52CE8D0AE8A  : public MonoBehaviour_t4A60845CF505405AF8BE8C61CC07F75CADEF6429
{
public:
	// unitycoder_MobilePaint.MobilePaint unitycoder_MobilePaint.SetNewMaskImage::mobilePaint
	MobilePaint_tC25928758E48181B341DE30F410E3EA407D005E5 * ___mobilePaint_4;
	// UnityEngine.Texture2D[] unitycoder_MobilePaint.SetNewMaskImage::images
	Texture2DU5BU5D_tCAC03055C735C020BAFC218D55183CF03E74C1C9* ___images_5;
	// System.Int32 unitycoder_MobilePaint.SetNewMaskImage::index
	int32_t ___index_6;

public:
	inline static int32_t get_offset_of_mobilePaint_4() { return static_cast<int32_t>(offsetof(SetNewMaskImage_t27DC57C9D9F2DC004D6F077B092BC52CE8D0AE8A, ___mobilePaint_4)); }
	inline MobilePaint_tC25928758E48181B341DE30F410E3EA407D005E5 * get_mobilePaint_4() const { return ___mobilePaint_4; }
	inline MobilePaint_tC25928758E48181B341DE30F410E3EA407D005E5 ** get_address_of_mobilePaint_4() { return &___mobilePaint_4; }
	inline void set_mobilePaint_4(MobilePaint_tC25928758E48181B341DE30F410E3EA407D005E5 * value)
	{
		___mobilePaint_4 = value;
		Il2CppCodeGenWriteBarrier((&___mobilePaint_4), value);
	}

	inline static int32_t get_offset_of_images_5() { return static_cast<int32_t>(offsetof(SetNewMaskImage_t27DC57C9D9F2DC004D6F077B092BC52CE8D0AE8A, ___images_5)); }
	inline Texture2DU5BU5D_tCAC03055C735C020BAFC218D55183CF03E74C1C9* get_images_5() const { return ___images_5; }
	inline Texture2DU5BU5D_tCAC03055C735C020BAFC218D55183CF03E74C1C9** get_address_of_images_5() { return &___images_5; }
	inline void set_images_5(Texture2DU5BU5D_tCAC03055C735C020BAFC218D55183CF03E74C1C9* value)
	{
		___images_5 = value;
		Il2CppCodeGenWriteBarrier((&___images_5), value);
	}

	inline static int32_t get_offset_of_index_6() { return static_cast<int32_t>(offsetof(SetNewMaskImage_t27DC57C9D9F2DC004D6F077B092BC52CE8D0AE8A, ___index_6)); }
	inline int32_t get_index_6() const { return ___index_6; }
	inline int32_t* get_address_of_index_6() { return &___index_6; }
	inline void set_index_6(int32_t value)
	{
		___index_6 = value;
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
#endif // SETNEWMASKIMAGE_T27DC57C9D9F2DC004D6F077B092BC52CE8D0AE8A_H
#ifndef TOGGLEBRUSHMODEUI_T4B6DF517F8B4743603417CD2EB16093A8DE0758B_H
#define TOGGLEBRUSHMODEUI_T4B6DF517F8B4743603417CD2EB16093A8DE0758B_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// unitycoder_MobilePaint.ToggleBrushModeUI
struct  ToggleBrushModeUI_t4B6DF517F8B4743603417CD2EB16093A8DE0758B  : public MonoBehaviour_t4A60845CF505405AF8BE8C61CC07F75CADEF6429
{
public:
	// unitycoder_MobilePaint.MobilePaint unitycoder_MobilePaint.ToggleBrushModeUI::mobilePaint
	MobilePaint_tC25928758E48181B341DE30F410E3EA407D005E5 * ___mobilePaint_4;

public:
	inline static int32_t get_offset_of_mobilePaint_4() { return static_cast<int32_t>(offsetof(ToggleBrushModeUI_t4B6DF517F8B4743603417CD2EB16093A8DE0758B, ___mobilePaint_4)); }
	inline MobilePaint_tC25928758E48181B341DE30F410E3EA407D005E5 * get_mobilePaint_4() const { return ___mobilePaint_4; }
	inline MobilePaint_tC25928758E48181B341DE30F410E3EA407D005E5 ** get_address_of_mobilePaint_4() { return &___mobilePaint_4; }
	inline void set_mobilePaint_4(MobilePaint_tC25928758E48181B341DE30F410E3EA407D005E5 * value)
	{
		___mobilePaint_4 = value;
		Il2CppCodeGenWriteBarrier((&___mobilePaint_4), value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
#endif // TOGGLEBRUSHMODEUI_T4B6DF517F8B4743603417CD2EB16093A8DE0758B_H
#ifndef TOGGLECUSTOMPATTERNMODEUI_TF5121E1792E8D86FB425CACACF9513D2B6E470AA_H
#define TOGGLECUSTOMPATTERNMODEUI_TF5121E1792E8D86FB425CACACF9513D2B6E470AA_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// unitycoder_MobilePaint.ToggleCustomPatternModeUI
struct  ToggleCustomPatternModeUI_tF5121E1792E8D86FB425CACACF9513D2B6E470AA  : public MonoBehaviour_t4A60845CF505405AF8BE8C61CC07F75CADEF6429
{
public:
	// unitycoder_MobilePaint.MobilePaint unitycoder_MobilePaint.ToggleCustomPatternModeUI::mobilePaint
	MobilePaint_tC25928758E48181B341DE30F410E3EA407D005E5 * ___mobilePaint_4;
	// UnityEngine.GameObject unitycoder_MobilePaint.ToggleCustomPatternModeUI::customPanel
	GameObject_tBD1244AD56B4E59AAD76E5E7C9282EC5CE434F0F * ___customPanel_5;

public:
	inline static int32_t get_offset_of_mobilePaint_4() { return static_cast<int32_t>(offsetof(ToggleCustomPatternModeUI_tF5121E1792E8D86FB425CACACF9513D2B6E470AA, ___mobilePaint_4)); }
	inline MobilePaint_tC25928758E48181B341DE30F410E3EA407D005E5 * get_mobilePaint_4() const { return ___mobilePaint_4; }
	inline MobilePaint_tC25928758E48181B341DE30F410E3EA407D005E5 ** get_address_of_mobilePaint_4() { return &___mobilePaint_4; }
	inline void set_mobilePaint_4(MobilePaint_tC25928758E48181B341DE30F410E3EA407D005E5 * value)
	{
		___mobilePaint_4 = value;
		Il2CppCodeGenWriteBarrier((&___mobilePaint_4), value);
	}

	inline static int32_t get_offset_of_customPanel_5() { return static_cast<int32_t>(offsetof(ToggleCustomPatternModeUI_tF5121E1792E8D86FB425CACACF9513D2B6E470AA, ___customPanel_5)); }
	inline GameObject_tBD1244AD56B4E59AAD76E5E7C9282EC5CE434F0F * get_customPanel_5() const { return ___customPanel_5; }
	inline GameObject_tBD1244AD56B4E59AAD76E5E7C9282EC5CE434F0F ** get_address_of_customPanel_5() { return &___customPanel_5; }
	inline void set_customPanel_5(GameObject_tBD1244AD56B4E59AAD76E5E7C9282EC5CE434F0F * value)
	{
		___customPanel_5 = value;
		Il2CppCodeGenWriteBarrier((&___customPanel_5), value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
#endif // TOGGLECUSTOMPATTERNMODEUI_TF5121E1792E8D86FB425CACACF9513D2B6E470AA_H
#ifndef TOGGLECUSTOMSHAPEMODEUI_T5DABF74118B1166FDBB31E08F25358F0FC907BF2_H
#define TOGGLECUSTOMSHAPEMODEUI_T5DABF74118B1166FDBB31E08F25358F0FC907BF2_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// unitycoder_MobilePaint.ToggleCustomShapeModeUI
struct  ToggleCustomShapeModeUI_t5DABF74118B1166FDBB31E08F25358F0FC907BF2  : public MonoBehaviour_t4A60845CF505405AF8BE8C61CC07F75CADEF6429
{
public:
	// unitycoder_MobilePaint.MobilePaint unitycoder_MobilePaint.ToggleCustomShapeModeUI::mobilePaint
	MobilePaint_tC25928758E48181B341DE30F410E3EA407D005E5 * ___mobilePaint_4;
	// UnityEngine.GameObject unitycoder_MobilePaint.ToggleCustomShapeModeUI::customBrushPanel
	GameObject_tBD1244AD56B4E59AAD76E5E7C9282EC5CE434F0F * ___customBrushPanel_5;

public:
	inline static int32_t get_offset_of_mobilePaint_4() { return static_cast<int32_t>(offsetof(ToggleCustomShapeModeUI_t5DABF74118B1166FDBB31E08F25358F0FC907BF2, ___mobilePaint_4)); }
	inline MobilePaint_tC25928758E48181B341DE30F410E3EA407D005E5 * get_mobilePaint_4() const { return ___mobilePaint_4; }
	inline MobilePaint_tC25928758E48181B341DE30F410E3EA407D005E5 ** get_address_of_mobilePaint_4() { return &___mobilePaint_4; }
	inline void set_mobilePaint_4(MobilePaint_tC25928758E48181B341DE30F410E3EA407D005E5 * value)
	{
		___mobilePaint_4 = value;
		Il2CppCodeGenWriteBarrier((&___mobilePaint_4), value);
	}

	inline static int32_t get_offset_of_customBrushPanel_5() { return static_cast<int32_t>(offsetof(ToggleCustomShapeModeUI_t5DABF74118B1166FDBB31E08F25358F0FC907BF2, ___customBrushPanel_5)); }
	inline GameObject_tBD1244AD56B4E59AAD76E5E7C9282EC5CE434F0F * get_customBrushPanel_5() const { return ___customBrushPanel_5; }
	inline GameObject_tBD1244AD56B4E59AAD76E5E7C9282EC5CE434F0F ** get_address_of_customBrushPanel_5() { return &___customBrushPanel_5; }
	inline void set_customBrushPanel_5(GameObject_tBD1244AD56B4E59AAD76E5E7C9282EC5CE434F0F * value)
	{
		___customBrushPanel_5 = value;
		Il2CppCodeGenWriteBarrier((&___customBrushPanel_5), value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
#endif // TOGGLECUSTOMSHAPEMODEUI_T5DABF74118B1166FDBB31E08F25358F0FC907BF2_H
#ifndef TOGGLEERASERMODEUI_T12A48F99C7CA25B41997882C81CCF6274E6B09D2_H
#define TOGGLEERASERMODEUI_T12A48F99C7CA25B41997882C81CCF6274E6B09D2_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// unitycoder_MobilePaint.ToggleEraserModeUI
struct  ToggleEraserModeUI_t12A48F99C7CA25B41997882C81CCF6274E6B09D2  : public MonoBehaviour_t4A60845CF505405AF8BE8C61CC07F75CADEF6429
{
public:
	// unitycoder_MobilePaint.MobilePaint unitycoder_MobilePaint.ToggleEraserModeUI::mobilePaint
	MobilePaint_tC25928758E48181B341DE30F410E3EA407D005E5 * ___mobilePaint_4;

public:
	inline static int32_t get_offset_of_mobilePaint_4() { return static_cast<int32_t>(offsetof(ToggleEraserModeUI_t12A48F99C7CA25B41997882C81CCF6274E6B09D2, ___mobilePaint_4)); }
	inline MobilePaint_tC25928758E48181B341DE30F410E3EA407D005E5 * get_mobilePaint_4() const { return ___mobilePaint_4; }
	inline MobilePaint_tC25928758E48181B341DE30F410E3EA407D005E5 ** get_address_of_mobilePaint_4() { return &___mobilePaint_4; }
	inline void set_mobilePaint_4(MobilePaint_tC25928758E48181B341DE30F410E3EA407D005E5 * value)
	{
		___mobilePaint_4 = value;
		Il2CppCodeGenWriteBarrier((&___mobilePaint_4), value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
#endif // TOGGLEERASERMODEUI_T12A48F99C7CA25B41997882C81CCF6274E6B09D2_H
#ifndef TOGGLEFLOODFILLMODEUI_TF40BA330FD9EEC86BEA5CD7943EC4599BAD93095_H
#define TOGGLEFLOODFILLMODEUI_TF40BA330FD9EEC86BEA5CD7943EC4599BAD93095_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// unitycoder_MobilePaint.ToggleFloodFillModeUI
struct  ToggleFloodFillModeUI_tF40BA330FD9EEC86BEA5CD7943EC4599BAD93095  : public MonoBehaviour_t4A60845CF505405AF8BE8C61CC07F75CADEF6429
{
public:
	// unitycoder_MobilePaint.MobilePaint unitycoder_MobilePaint.ToggleFloodFillModeUI::mobilePaint
	MobilePaint_tC25928758E48181B341DE30F410E3EA407D005E5 * ___mobilePaint_4;

public:
	inline static int32_t get_offset_of_mobilePaint_4() { return static_cast<int32_t>(offsetof(ToggleFloodFillModeUI_tF40BA330FD9EEC86BEA5CD7943EC4599BAD93095, ___mobilePaint_4)); }
	inline MobilePaint_tC25928758E48181B341DE30F410E3EA407D005E5 * get_mobilePaint_4() const { return ___mobilePaint_4; }
	inline MobilePaint_tC25928758E48181B341DE30F410E3EA407D005E5 ** get_address_of_mobilePaint_4() { return &___mobilePaint_4; }
	inline void set_mobilePaint_4(MobilePaint_tC25928758E48181B341DE30F410E3EA407D005E5 * value)
	{
		___mobilePaint_4 = value;
		Il2CppCodeGenWriteBarrier((&___mobilePaint_4), value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
#endif // TOGGLEFLOODFILLMODEUI_TF40BA330FD9EEC86BEA5CD7943EC4599BAD93095_H
#ifndef TOGGLELINEMODEUI_TB4F725C4D6DD648C397DB3AC4AAB347EC4AA94C4_H
#define TOGGLELINEMODEUI_TB4F725C4D6DD648C397DB3AC4AAB347EC4AA94C4_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// unitycoder_MobilePaint.ToggleLineModeUI
struct  ToggleLineModeUI_tB4F725C4D6DD648C397DB3AC4AAB347EC4AA94C4  : public MonoBehaviour_t4A60845CF505405AF8BE8C61CC07F75CADEF6429
{
public:
	// unitycoder_MobilePaint.MobilePaint unitycoder_MobilePaint.ToggleLineModeUI::mobilePaint
	MobilePaint_tC25928758E48181B341DE30F410E3EA407D005E5 * ___mobilePaint_4;

public:
	inline static int32_t get_offset_of_mobilePaint_4() { return static_cast<int32_t>(offsetof(ToggleLineModeUI_tB4F725C4D6DD648C397DB3AC4AAB347EC4AA94C4, ___mobilePaint_4)); }
	inline MobilePaint_tC25928758E48181B341DE30F410E3EA407D005E5 * get_mobilePaint_4() const { return ___mobilePaint_4; }
	inline MobilePaint_tC25928758E48181B341DE30F410E3EA407D005E5 ** get_address_of_mobilePaint_4() { return &___mobilePaint_4; }
	inline void set_mobilePaint_4(MobilePaint_tC25928758E48181B341DE30F410E3EA407D005E5 * value)
	{
		___mobilePaint_4 = value;
		Il2CppCodeGenWriteBarrier((&___mobilePaint_4), value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
#endif // TOGGLELINEMODEUI_TB4F725C4D6DD648C397DB3AC4AAB347EC4AA94C4_H
#ifndef TOGGLEMODE_T93881258140C0924B93E76F32A64D736B08607F9_H
#define TOGGLEMODE_T93881258140C0924B93E76F32A64D736B08607F9_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// unitycoder_MobilePaint.ToggleMode
struct  ToggleMode_t93881258140C0924B93E76F32A64D736B08607F9  : public MonoBehaviour_t4A60845CF505405AF8BE8C61CC07F75CADEF6429
{
public:
	// UnityEngine.GameObject unitycoder_MobilePaint.ToggleMode::canvas
	GameObject_tBD1244AD56B4E59AAD76E5E7C9282EC5CE434F0F * ___canvas_4;
	// UnityEngine.GameObject unitycoder_MobilePaint.ToggleMode::otherButton1
	GameObject_tBD1244AD56B4E59AAD76E5E7C9282EC5CE434F0F * ___otherButton1_5;
	// UnityEngine.GameObject unitycoder_MobilePaint.ToggleMode::otherButton2
	GameObject_tBD1244AD56B4E59AAD76E5E7C9282EC5CE434F0F * ___otherButton2_6;
	// UnityEngine.GameObject unitycoder_MobilePaint.ToggleMode::sizeGUI1
	GameObject_tBD1244AD56B4E59AAD76E5E7C9282EC5CE434F0F * ___sizeGUI1_7;
	// unitycoder_MobilePaint.DrawMode unitycoder_MobilePaint.ToggleMode::mode
	int32_t ___mode_8;

public:
	inline static int32_t get_offset_of_canvas_4() { return static_cast<int32_t>(offsetof(ToggleMode_t93881258140C0924B93E76F32A64D736B08607F9, ___canvas_4)); }
	inline GameObject_tBD1244AD56B4E59AAD76E5E7C9282EC5CE434F0F * get_canvas_4() const { return ___canvas_4; }
	inline GameObject_tBD1244AD56B4E59AAD76E5E7C9282EC5CE434F0F ** get_address_of_canvas_4() { return &___canvas_4; }
	inline void set_canvas_4(GameObject_tBD1244AD56B4E59AAD76E5E7C9282EC5CE434F0F * value)
	{
		___canvas_4 = value;
		Il2CppCodeGenWriteBarrier((&___canvas_4), value);
	}

	inline static int32_t get_offset_of_otherButton1_5() { return static_cast<int32_t>(offsetof(ToggleMode_t93881258140C0924B93E76F32A64D736B08607F9, ___otherButton1_5)); }
	inline GameObject_tBD1244AD56B4E59AAD76E5E7C9282EC5CE434F0F * get_otherButton1_5() const { return ___otherButton1_5; }
	inline GameObject_tBD1244AD56B4E59AAD76E5E7C9282EC5CE434F0F ** get_address_of_otherButton1_5() { return &___otherButton1_5; }
	inline void set_otherButton1_5(GameObject_tBD1244AD56B4E59AAD76E5E7C9282EC5CE434F0F * value)
	{
		___otherButton1_5 = value;
		Il2CppCodeGenWriteBarrier((&___otherButton1_5), value);
	}

	inline static int32_t get_offset_of_otherButton2_6() { return static_cast<int32_t>(offsetof(ToggleMode_t93881258140C0924B93E76F32A64D736B08607F9, ___otherButton2_6)); }
	inline GameObject_tBD1244AD56B4E59AAD76E5E7C9282EC5CE434F0F * get_otherButton2_6() const { return ___otherButton2_6; }
	inline GameObject_tBD1244AD56B4E59AAD76E5E7C9282EC5CE434F0F ** get_address_of_otherButton2_6() { return &___otherButton2_6; }
	inline void set_otherButton2_6(GameObject_tBD1244AD56B4E59AAD76E5E7C9282EC5CE434F0F * value)
	{
		___otherButton2_6 = value;
		Il2CppCodeGenWriteBarrier((&___otherButton2_6), value);
	}

	inline static int32_t get_offset_of_sizeGUI1_7() { return static_cast<int32_t>(offsetof(ToggleMode_t93881258140C0924B93E76F32A64D736B08607F9, ___sizeGUI1_7)); }
	inline GameObject_tBD1244AD56B4E59AAD76E5E7C9282EC5CE434F0F * get_sizeGUI1_7() const { return ___sizeGUI1_7; }
	inline GameObject_tBD1244AD56B4E59AAD76E5E7C9282EC5CE434F0F ** get_address_of_sizeGUI1_7() { return &___sizeGUI1_7; }
	inline void set_sizeGUI1_7(GameObject_tBD1244AD56B4E59AAD76E5E7C9282EC5CE434F0F * value)
	{
		___sizeGUI1_7 = value;
		Il2CppCodeGenWriteBarrier((&___sizeGUI1_7), value);
	}

	inline static int32_t get_offset_of_mode_8() { return static_cast<int32_t>(offsetof(ToggleMode_t93881258140C0924B93E76F32A64D736B08607F9, ___mode_8)); }
	inline int32_t get_mode_8() const { return ___mode_8; }
	inline int32_t* get_address_of_mode_8() { return &___mode_8; }
	inline void set_mode_8(int32_t value)
	{
		___mode_8 = value;
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
#endif // TOGGLEMODE_T93881258140C0924B93E76F32A64D736B08607F9_H
#ifndef TOGGLEPANZOOMMODEUI_T7EA98A500D67F4E63FCA50307325D99362E30F00_H
#define TOGGLEPANZOOMMODEUI_T7EA98A500D67F4E63FCA50307325D99362E30F00_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// unitycoder_MobilePaint.TogglePanZoomModeUI
struct  TogglePanZoomModeUI_t7EA98A500D67F4E63FCA50307325D99362E30F00  : public MonoBehaviour_t4A60845CF505405AF8BE8C61CC07F75CADEF6429
{
public:
	// unitycoder_MobilePaint.MobilePaint unitycoder_MobilePaint.TogglePanZoomModeUI::mobilePaint
	MobilePaint_tC25928758E48181B341DE30F410E3EA407D005E5 * ___mobilePaint_4;

public:
	inline static int32_t get_offset_of_mobilePaint_4() { return static_cast<int32_t>(offsetof(TogglePanZoomModeUI_t7EA98A500D67F4E63FCA50307325D99362E30F00, ___mobilePaint_4)); }
	inline MobilePaint_tC25928758E48181B341DE30F410E3EA407D005E5 * get_mobilePaint_4() const { return ___mobilePaint_4; }
	inline MobilePaint_tC25928758E48181B341DE30F410E3EA407D005E5 ** get_address_of_mobilePaint_4() { return &___mobilePaint_4; }
	inline void set_mobilePaint_4(MobilePaint_tC25928758E48181B341DE30F410E3EA407D005E5 * value)
	{
		___mobilePaint_4 = value;
		Il2CppCodeGenWriteBarrier((&___mobilePaint_4), value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
#endif // TOGGLEPANZOOMMODEUI_T7EA98A500D67F4E63FCA50307325D99362E30F00_H
#ifndef GUISCALER_T6D470D8BFC2F4807DA1811C43EB35472B4D0C13F_H
#define GUISCALER_T6D470D8BFC2F4807DA1811C43EB35472B4D0C13F_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// unitycoder_MobilePaint_samples.GUIScaler
struct  GUIScaler_t6D470D8BFC2F4807DA1811C43EB35472B4D0C13F  : public MonoBehaviour_t4A60845CF505405AF8BE8C61CC07F75CADEF6429
{
public:
	// System.Single unitycoder_MobilePaint_samples.GUIScaler::scaleAdjust
	float ___scaleAdjust_4;

public:
	inline static int32_t get_offset_of_scaleAdjust_4() { return static_cast<int32_t>(offsetof(GUIScaler_t6D470D8BFC2F4807DA1811C43EB35472B4D0C13F, ___scaleAdjust_4)); }
	inline float get_scaleAdjust_4() const { return ___scaleAdjust_4; }
	inline float* get_address_of_scaleAdjust_4() { return &___scaleAdjust_4; }
	inline void set_scaleAdjust_4(float value)
	{
		___scaleAdjust_4 = value;
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
#endif // GUISCALER_T6D470D8BFC2F4807DA1811C43EB35472B4D0C13F_H
#ifndef LOADIMAGEFROMDISK_T25E1AF3A9B41761AA5B2368589B30DE107BB0DFD_H
#define LOADIMAGEFROMDISK_T25E1AF3A9B41761AA5B2368589B30DE107BB0DFD_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// unitycoder_MobilePaint_samples.LoadImageFromDisk
struct  LoadImageFromDisk_t25E1AF3A9B41761AA5B2368589B30DE107BB0DFD  : public MonoBehaviour_t4A60845CF505405AF8BE8C61CC07F75CADEF6429
{
public:
	// unitycoder_MobilePaint.MobilePaint unitycoder_MobilePaint_samples.LoadImageFromDisk::mobilePaint
	MobilePaint_tC25928758E48181B341DE30F410E3EA407D005E5 * ___mobilePaint_4;
	// UnityEngine.KeyCode unitycoder_MobilePaint_samples.LoadImageFromDisk::loadFileKey
	int32_t ___loadFileKey_5;
	// System.String unitycoder_MobilePaint_samples.LoadImageFromDisk::imageFolder
	String_t* ___imageFolder_6;

public:
	inline static int32_t get_offset_of_mobilePaint_4() { return static_cast<int32_t>(offsetof(LoadImageFromDisk_t25E1AF3A9B41761AA5B2368589B30DE107BB0DFD, ___mobilePaint_4)); }
	inline MobilePaint_tC25928758E48181B341DE30F410E3EA407D005E5 * get_mobilePaint_4() const { return ___mobilePaint_4; }
	inline MobilePaint_tC25928758E48181B341DE30F410E3EA407D005E5 ** get_address_of_mobilePaint_4() { return &___mobilePaint_4; }
	inline void set_mobilePaint_4(MobilePaint_tC25928758E48181B341DE30F410E3EA407D005E5 * value)
	{
		___mobilePaint_4 = value;
		Il2CppCodeGenWriteBarrier((&___mobilePaint_4), value);
	}

	inline static int32_t get_offset_of_loadFileKey_5() { return static_cast<int32_t>(offsetof(LoadImageFromDisk_t25E1AF3A9B41761AA5B2368589B30DE107BB0DFD, ___loadFileKey_5)); }
	inline int32_t get_loadFileKey_5() const { return ___loadFileKey_5; }
	inline int32_t* get_address_of_loadFileKey_5() { return &___loadFileKey_5; }
	inline void set_loadFileKey_5(int32_t value)
	{
		___loadFileKey_5 = value;
	}

	inline static int32_t get_offset_of_imageFolder_6() { return static_cast<int32_t>(offsetof(LoadImageFromDisk_t25E1AF3A9B41761AA5B2368589B30DE107BB0DFD, ___imageFolder_6)); }
	inline String_t* get_imageFolder_6() const { return ___imageFolder_6; }
	inline String_t** get_address_of_imageFolder_6() { return &___imageFolder_6; }
	inline void set_imageFolder_6(String_t* value)
	{
		___imageFolder_6 = value;
		Il2CppCodeGenWriteBarrier((&___imageFolder_6), value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
#endif // LOADIMAGEFROMDISK_T25E1AF3A9B41761AA5B2368589B30DE107BB0DFD_H
#ifndef LOADTEXTUREFROMWEB_TFC746A6E41B9DB9A0D76CE18D58637FA36CA3F18_H
#define LOADTEXTUREFROMWEB_TFC746A6E41B9DB9A0D76CE18D58637FA36CA3F18_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// unitycoder_MobilePaint_samples.LoadTextureFromWeb
struct  LoadTextureFromWeb_tFC746A6E41B9DB9A0D76CE18D58637FA36CA3F18  : public MonoBehaviour_t4A60845CF505405AF8BE8C61CC07F75CADEF6429
{
public:
	// unitycoder_MobilePaint.MobilePaint unitycoder_MobilePaint_samples.LoadTextureFromWeb::mobilePaint
	MobilePaint_tC25928758E48181B341DE30F410E3EA407D005E5 * ___mobilePaint_4;
	// System.String unitycoder_MobilePaint_samples.LoadTextureFromWeb::url
	String_t* ___url_5;

public:
	inline static int32_t get_offset_of_mobilePaint_4() { return static_cast<int32_t>(offsetof(LoadTextureFromWeb_tFC746A6E41B9DB9A0D76CE18D58637FA36CA3F18, ___mobilePaint_4)); }
	inline MobilePaint_tC25928758E48181B341DE30F410E3EA407D005E5 * get_mobilePaint_4() const { return ___mobilePaint_4; }
	inline MobilePaint_tC25928758E48181B341DE30F410E3EA407D005E5 ** get_address_of_mobilePaint_4() { return &___mobilePaint_4; }
	inline void set_mobilePaint_4(MobilePaint_tC25928758E48181B341DE30F410E3EA407D005E5 * value)
	{
		___mobilePaint_4 = value;
		Il2CppCodeGenWriteBarrier((&___mobilePaint_4), value);
	}

	inline static int32_t get_offset_of_url_5() { return static_cast<int32_t>(offsetof(LoadTextureFromWeb_tFC746A6E41B9DB9A0D76CE18D58637FA36CA3F18, ___url_5)); }
	inline String_t* get_url_5() const { return ___url_5; }
	inline String_t** get_address_of_url_5() { return &___url_5; }
	inline void set_url_5(String_t* value)
	{
		___url_5 = value;
		Il2CppCodeGenWriteBarrier((&___url_5), value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
#endif // LOADTEXTUREFROMWEB_TFC746A6E41B9DB9A0D76CE18D58637FA36CA3F18_H
#ifndef OBJECTROTATOR_T95B32158CE027C61B581320C3C6D806CC68AC258_H
#define OBJECTROTATOR_T95B32158CE027C61B581320C3C6D806CC68AC258_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// unitycoder_MobilePaint_samples.ObjectRotator
struct  ObjectRotator_t95B32158CE027C61B581320C3C6D806CC68AC258  : public MonoBehaviour_t4A60845CF505405AF8BE8C61CC07F75CADEF6429
{
public:
	// System.Single unitycoder_MobilePaint_samples.ObjectRotator::rotateSpeed
	float ___rotateSpeed_4;

public:
	inline static int32_t get_offset_of_rotateSpeed_4() { return static_cast<int32_t>(offsetof(ObjectRotator_t95B32158CE027C61B581320C3C6D806CC68AC258, ___rotateSpeed_4)); }
	inline float get_rotateSpeed_4() const { return ___rotateSpeed_4; }
	inline float* get_address_of_rotateSpeed_4() { return &___rotateSpeed_4; }
	inline void set_rotateSpeed_4(float value)
	{
		___rotateSpeed_4 = value;
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
#endif // OBJECTROTATOR_T95B32158CE027C61B581320C3C6D806CC68AC258_H
#ifndef RANDOMPAINTER_T2FDDE913E008D1D01B3534CE3173C7E05EFD3D10_H
#define RANDOMPAINTER_T2FDDE913E008D1D01B3534CE3173C7E05EFD3D10_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// unitycoder_MobilePaint_samples.RandomPainter
struct  RandomPainter_t2FDDE913E008D1D01B3534CE3173C7E05EFD3D10  : public MonoBehaviour_t4A60845CF505405AF8BE8C61CC07F75CADEF6429
{
public:
	// unitycoder_MobilePaint.MobilePaint unitycoder_MobilePaint_samples.RandomPainter::mobilePaint
	MobilePaint_tC25928758E48181B341DE30F410E3EA407D005E5 * ___mobilePaint_4;

public:
	inline static int32_t get_offset_of_mobilePaint_4() { return static_cast<int32_t>(offsetof(RandomPainter_t2FDDE913E008D1D01B3534CE3173C7E05EFD3D10, ___mobilePaint_4)); }
	inline MobilePaint_tC25928758E48181B341DE30F410E3EA407D005E5 * get_mobilePaint_4() const { return ___mobilePaint_4; }
	inline MobilePaint_tC25928758E48181B341DE30F410E3EA407D005E5 ** get_address_of_mobilePaint_4() { return &___mobilePaint_4; }
	inline void set_mobilePaint_4(MobilePaint_tC25928758E48181B341DE30F410E3EA407D005E5 * value)
	{
		___mobilePaint_4 = value;
		Il2CppCodeGenWriteBarrier((&___mobilePaint_4), value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
#endif // RANDOMPAINTER_T2FDDE913E008D1D01B3534CE3173C7E05EFD3D10_H
#ifndef SAVEIMAGETOFILE_TA64B2DAC4D2AF5B3E183119D7B8EB1C53770B018_H
#define SAVEIMAGETOFILE_TA64B2DAC4D2AF5B3E183119D7B8EB1C53770B018_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// unitycoder_MobilePaint_samples.SaveImageToFile
struct  SaveImageToFile_tA64B2DAC4D2AF5B3E183119D7B8EB1C53770B018  : public MonoBehaviour_t4A60845CF505405AF8BE8C61CC07F75CADEF6429
{
public:
	// unitycoder_MobilePaint.MobilePaint unitycoder_MobilePaint_samples.SaveImageToFile::mobilePaint
	MobilePaint_tC25928758E48181B341DE30F410E3EA407D005E5 * ___mobilePaint_4;
	// UnityEngine.KeyCode unitycoder_MobilePaint_samples.SaveImageToFile::screenshotKey
	int32_t ___screenshotKey_5;

public:
	inline static int32_t get_offset_of_mobilePaint_4() { return static_cast<int32_t>(offsetof(SaveImageToFile_tA64B2DAC4D2AF5B3E183119D7B8EB1C53770B018, ___mobilePaint_4)); }
	inline MobilePaint_tC25928758E48181B341DE30F410E3EA407D005E5 * get_mobilePaint_4() const { return ___mobilePaint_4; }
	inline MobilePaint_tC25928758E48181B341DE30F410E3EA407D005E5 ** get_address_of_mobilePaint_4() { return &___mobilePaint_4; }
	inline void set_mobilePaint_4(MobilePaint_tC25928758E48181B341DE30F410E3EA407D005E5 * value)
	{
		___mobilePaint_4 = value;
		Il2CppCodeGenWriteBarrier((&___mobilePaint_4), value);
	}

	inline static int32_t get_offset_of_screenshotKey_5() { return static_cast<int32_t>(offsetof(SaveImageToFile_tA64B2DAC4D2AF5B3E183119D7B8EB1C53770B018, ___screenshotKey_5)); }
	inline int32_t get_screenshotKey_5() const { return ___screenshotKey_5; }
	inline int32_t* get_address_of_screenshotKey_5() { return &___screenshotKey_5; }
	inline void set_screenshotKey_5(int32_t value)
	{
		___screenshotKey_5 = value;
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
#endif // SAVEIMAGETOFILE_TA64B2DAC4D2AF5B3E183119D7B8EB1C53770B018_H
#ifndef SETSORTINGORDERANDLAYER_TBB2A36BC15162AB6518A830659C7B4623AE6B8D2_H
#define SETSORTINGORDERANDLAYER_TBB2A36BC15162AB6518A830659C7B4623AE6B8D2_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// unitycoder_MobilePaint_samples.SetSortingOrderAndLayer
struct  SetSortingOrderAndLayer_tBB2A36BC15162AB6518A830659C7B4623AE6B8D2  : public MonoBehaviour_t4A60845CF505405AF8BE8C61CC07F75CADEF6429
{
public:
	// System.Int32 unitycoder_MobilePaint_samples.SetSortingOrderAndLayer::sortingOrder
	int32_t ___sortingOrder_4;
	// System.String unitycoder_MobilePaint_samples.SetSortingOrderAndLayer::layerName
	String_t* ___layerName_5;

public:
	inline static int32_t get_offset_of_sortingOrder_4() { return static_cast<int32_t>(offsetof(SetSortingOrderAndLayer_tBB2A36BC15162AB6518A830659C7B4623AE6B8D2, ___sortingOrder_4)); }
	inline int32_t get_sortingOrder_4() const { return ___sortingOrder_4; }
	inline int32_t* get_address_of_sortingOrder_4() { return &___sortingOrder_4; }
	inline void set_sortingOrder_4(int32_t value)
	{
		___sortingOrder_4 = value;
	}

	inline static int32_t get_offset_of_layerName_5() { return static_cast<int32_t>(offsetof(SetSortingOrderAndLayer_tBB2A36BC15162AB6518A830659C7B4623AE6B8D2, ___layerName_5)); }
	inline String_t* get_layerName_5() const { return ___layerName_5; }
	inline String_t** get_address_of_layerName_5() { return &___layerName_5; }
	inline void set_layerName_5(String_t* value)
	{
		___layerName_5 = value;
		Il2CppCodeGenWriteBarrier((&___layerName_5), value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
#endif // SETSORTINGORDERANDLAYER_TBB2A36BC15162AB6518A830659C7B4623AE6B8D2_H
#ifndef TANGENTSOLVER_T655698722F48FC1DDDB372D35BC32042835C9FE8_H
#define TANGENTSOLVER_T655698722F48FC1DDDB372D35BC32042835C9FE8_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// unitycoder_MobilePaint_samples.TangentSolver
struct  TangentSolver_t655698722F48FC1DDDB372D35BC32042835C9FE8  : public MonoBehaviour_t4A60845CF505405AF8BE8C61CC07F75CADEF6429
{
public:

public:
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
#endif // TANGENTSOLVER_T655698722F48FC1DDDB372D35BC32042835C9FE8_H
#ifndef SELECTABLE_TAA9065030FE0468018DEC880302F95FEA9C0133A_H
#define SELECTABLE_TAA9065030FE0468018DEC880302F95FEA9C0133A_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// UnityEngine.UI.Selectable
struct  Selectable_tAA9065030FE0468018DEC880302F95FEA9C0133A  : public UIBehaviour_t3C3C339CD5677BA7FC27C352FED8B78052A3FE70
{
public:
	// UnityEngine.UI.Navigation UnityEngine.UI.Selectable::m_Navigation
	Navigation_t761250C05C09773B75F5E0D52DDCBBFE60288A07  ___m_Navigation_5;
	// UnityEngine.UI.Selectable/Transition UnityEngine.UI.Selectable::m_Transition
	int32_t ___m_Transition_6;
	// UnityEngine.UI.ColorBlock UnityEngine.UI.Selectable::m_Colors
	ColorBlock_t93B54DF6E8D65D24CEA9726CA745E48C53E3B1EA  ___m_Colors_7;
	// UnityEngine.UI.SpriteState UnityEngine.UI.Selectable::m_SpriteState
	SpriteState_t58B9DD66A79CD69AB4CFC3AD0C41E45DC2192C0A  ___m_SpriteState_8;
	// UnityEngine.UI.AnimationTriggers UnityEngine.UI.Selectable::m_AnimationTriggers
	AnimationTriggers_t164EF8B310E294B7D0F6BF1A87376731EBD06DC5 * ___m_AnimationTriggers_9;
	// System.Boolean UnityEngine.UI.Selectable::m_Interactable
	bool ___m_Interactable_10;
	// UnityEngine.UI.Graphic UnityEngine.UI.Selectable::m_TargetGraphic
	Graphic_tBA2C3EF11D3DAEBB57F6879AB0BB4F8BD40D00D8 * ___m_TargetGraphic_11;
	// System.Boolean UnityEngine.UI.Selectable::m_GroupsAllowInteraction
	bool ___m_GroupsAllowInteraction_12;
	// UnityEngine.UI.Selectable/SelectionState UnityEngine.UI.Selectable::m_CurrentSelectionState
	int32_t ___m_CurrentSelectionState_13;
	// System.Boolean UnityEngine.UI.Selectable::<isPointerInside>k__BackingField
	bool ___U3CisPointerInsideU3Ek__BackingField_14;
	// System.Boolean UnityEngine.UI.Selectable::<isPointerDown>k__BackingField
	bool ___U3CisPointerDownU3Ek__BackingField_15;
	// System.Boolean UnityEngine.UI.Selectable::<hasSelection>k__BackingField
	bool ___U3ChasSelectionU3Ek__BackingField_16;
	// System.Collections.Generic.List`1<UnityEngine.CanvasGroup> UnityEngine.UI.Selectable::m_CanvasGroupCache
	List_1_t64BA96BFC713F221050385E91C868CE455C245D6 * ___m_CanvasGroupCache_17;

public:
	inline static int32_t get_offset_of_m_Navigation_5() { return static_cast<int32_t>(offsetof(Selectable_tAA9065030FE0468018DEC880302F95FEA9C0133A, ___m_Navigation_5)); }
	inline Navigation_t761250C05C09773B75F5E0D52DDCBBFE60288A07  get_m_Navigation_5() const { return ___m_Navigation_5; }
	inline Navigation_t761250C05C09773B75F5E0D52DDCBBFE60288A07 * get_address_of_m_Navigation_5() { return &___m_Navigation_5; }
	inline void set_m_Navigation_5(Navigation_t761250C05C09773B75F5E0D52DDCBBFE60288A07  value)
	{
		___m_Navigation_5 = value;
	}

	inline static int32_t get_offset_of_m_Transition_6() { return static_cast<int32_t>(offsetof(Selectable_tAA9065030FE0468018DEC880302F95FEA9C0133A, ___m_Transition_6)); }
	inline int32_t get_m_Transition_6() const { return ___m_Transition_6; }
	inline int32_t* get_address_of_m_Transition_6() { return &___m_Transition_6; }
	inline void set_m_Transition_6(int32_t value)
	{
		___m_Transition_6 = value;
	}

	inline static int32_t get_offset_of_m_Colors_7() { return static_cast<int32_t>(offsetof(Selectable_tAA9065030FE0468018DEC880302F95FEA9C0133A, ___m_Colors_7)); }
	inline ColorBlock_t93B54DF6E8D65D24CEA9726CA745E48C53E3B1EA  get_m_Colors_7() const { return ___m_Colors_7; }
	inline ColorBlock_t93B54DF6E8D65D24CEA9726CA745E48C53E3B1EA * get_address_of_m_Colors_7() { return &___m_Colors_7; }
	inline void set_m_Colors_7(ColorBlock_t93B54DF6E8D65D24CEA9726CA745E48C53E3B1EA  value)
	{
		___m_Colors_7 = value;
	}

	inline static int32_t get_offset_of_m_SpriteState_8() { return static_cast<int32_t>(offsetof(Selectable_tAA9065030FE0468018DEC880302F95FEA9C0133A, ___m_SpriteState_8)); }
	inline SpriteState_t58B9DD66A79CD69AB4CFC3AD0C41E45DC2192C0A  get_m_SpriteState_8() const { return ___m_SpriteState_8; }
	inline SpriteState_t58B9DD66A79CD69AB4CFC3AD0C41E45DC2192C0A * get_address_of_m_SpriteState_8() { return &___m_SpriteState_8; }
	inline void set_m_SpriteState_8(SpriteState_t58B9DD66A79CD69AB4CFC3AD0C41E45DC2192C0A  value)
	{
		___m_SpriteState_8 = value;
	}

	inline static int32_t get_offset_of_m_AnimationTriggers_9() { return static_cast<int32_t>(offsetof(Selectable_tAA9065030FE0468018DEC880302F95FEA9C0133A, ___m_AnimationTriggers_9)); }
	inline AnimationTriggers_t164EF8B310E294B7D0F6BF1A87376731EBD06DC5 * get_m_AnimationTriggers_9() const { return ___m_AnimationTriggers_9; }
	inline AnimationTriggers_t164EF8B310E294B7D0F6BF1A87376731EBD06DC5 ** get_address_of_m_AnimationTriggers_9() { return &___m_AnimationTriggers_9; }
	inline void set_m_AnimationTriggers_9(AnimationTriggers_t164EF8B310E294B7D0F6BF1A87376731EBD06DC5 * value)
	{
		___m_AnimationTriggers_9 = value;
		Il2CppCodeGenWriteBarrier((&___m_AnimationTriggers_9), value);
	}

	inline static int32_t get_offset_of_m_Interactable_10() { return static_cast<int32_t>(offsetof(Selectable_tAA9065030FE0468018DEC880302F95FEA9C0133A, ___m_Interactable_10)); }
	inline bool get_m_Interactable_10() const { return ___m_Interactable_10; }
	inline bool* get_address_of_m_Interactable_10() { return &___m_Interactable_10; }
	inline void set_m_Interactable_10(bool value)
	{
		___m_Interactable_10 = value;
	}

	inline static int32_t get_offset_of_m_TargetGraphic_11() { return static_cast<int32_t>(offsetof(Selectable_tAA9065030FE0468018DEC880302F95FEA9C0133A, ___m_TargetGraphic_11)); }
	inline Graphic_tBA2C3EF11D3DAEBB57F6879AB0BB4F8BD40D00D8 * get_m_TargetGraphic_11() const { return ___m_TargetGraphic_11; }
	inline Graphic_tBA2C3EF11D3DAEBB57F6879AB0BB4F8BD40D00D8 ** get_address_of_m_TargetGraphic_11() { return &___m_TargetGraphic_11; }
	inline void set_m_TargetGraphic_11(Graphic_tBA2C3EF11D3DAEBB57F6879AB0BB4F8BD40D00D8 * value)
	{
		___m_TargetGraphic_11 = value;
		Il2CppCodeGenWriteBarrier((&___m_TargetGraphic_11), value);
	}

	inline static int32_t get_offset_of_m_GroupsAllowInteraction_12() { return static_cast<int32_t>(offsetof(Selectable_tAA9065030FE0468018DEC880302F95FEA9C0133A, ___m_GroupsAllowInteraction_12)); }
	inline bool get_m_GroupsAllowInteraction_12() const { return ___m_GroupsAllowInteraction_12; }
	inline bool* get_address_of_m_GroupsAllowInteraction_12() { return &___m_GroupsAllowInteraction_12; }
	inline void set_m_GroupsAllowInteraction_12(bool value)
	{
		___m_GroupsAllowInteraction_12 = value;
	}

	inline static int32_t get_offset_of_m_CurrentSelectionState_13() { return static_cast<int32_t>(offsetof(Selectable_tAA9065030FE0468018DEC880302F95FEA9C0133A, ___m_CurrentSelectionState_13)); }
	inline int32_t get_m_CurrentSelectionState_13() const { return ___m_CurrentSelectionState_13; }
	inline int32_t* get_address_of_m_CurrentSelectionState_13() { return &___m_CurrentSelectionState_13; }
	inline void set_m_CurrentSelectionState_13(int32_t value)
	{
		___m_CurrentSelectionState_13 = value;
	}

	inline static int32_t get_offset_of_U3CisPointerInsideU3Ek__BackingField_14() { return static_cast<int32_t>(offsetof(Selectable_tAA9065030FE0468018DEC880302F95FEA9C0133A, ___U3CisPointerInsideU3Ek__BackingField_14)); }
	inline bool get_U3CisPointerInsideU3Ek__BackingField_14() const { return ___U3CisPointerInsideU3Ek__BackingField_14; }
	inline bool* get_address_of_U3CisPointerInsideU3Ek__BackingField_14() { return &___U3CisPointerInsideU3Ek__BackingField_14; }
	inline void set_U3CisPointerInsideU3Ek__BackingField_14(bool value)
	{
		___U3CisPointerInsideU3Ek__BackingField_14 = value;
	}

	inline static int32_t get_offset_of_U3CisPointerDownU3Ek__BackingField_15() { return static_cast<int32_t>(offsetof(Selectable_tAA9065030FE0468018DEC880302F95FEA9C0133A, ___U3CisPointerDownU3Ek__BackingField_15)); }
	inline bool get_U3CisPointerDownU3Ek__BackingField_15() const { return ___U3CisPointerDownU3Ek__BackingField_15; }
	inline bool* get_address_of_U3CisPointerDownU3Ek__BackingField_15() { return &___U3CisPointerDownU3Ek__BackingField_15; }
	inline void set_U3CisPointerDownU3Ek__BackingField_15(bool value)
	{
		___U3CisPointerDownU3Ek__BackingField_15 = value;
	}

	inline static int32_t get_offset_of_U3ChasSelectionU3Ek__BackingField_16() { return static_cast<int32_t>(offsetof(Selectable_tAA9065030FE0468018DEC880302F95FEA9C0133A, ___U3ChasSelectionU3Ek__BackingField_16)); }
	inline bool get_U3ChasSelectionU3Ek__BackingField_16() const { return ___U3ChasSelectionU3Ek__BackingField_16; }
	inline bool* get_address_of_U3ChasSelectionU3Ek__BackingField_16() { return &___U3ChasSelectionU3Ek__BackingField_16; }
	inline void set_U3ChasSelectionU3Ek__BackingField_16(bool value)
	{
		___U3ChasSelectionU3Ek__BackingField_16 = value;
	}

	inline static int32_t get_offset_of_m_CanvasGroupCache_17() { return static_cast<int32_t>(offsetof(Selectable_tAA9065030FE0468018DEC880302F95FEA9C0133A, ___m_CanvasGroupCache_17)); }
	inline List_1_t64BA96BFC713F221050385E91C868CE455C245D6 * get_m_CanvasGroupCache_17() const { return ___m_CanvasGroupCache_17; }
	inline List_1_t64BA96BFC713F221050385E91C868CE455C245D6 ** get_address_of_m_CanvasGroupCache_17() { return &___m_CanvasGroupCache_17; }
	inline void set_m_CanvasGroupCache_17(List_1_t64BA96BFC713F221050385E91C868CE455C245D6 * value)
	{
		___m_CanvasGroupCache_17 = value;
		Il2CppCodeGenWriteBarrier((&___m_CanvasGroupCache_17), value);
	}
};

struct Selectable_tAA9065030FE0468018DEC880302F95FEA9C0133A_StaticFields
{
public:
	// System.Collections.Generic.List`1<UnityEngine.UI.Selectable> UnityEngine.UI.Selectable::s_List
	List_1_tC6550F4D86CF67D987B6B46F46941B36D02A9680 * ___s_List_4;

public:
	inline static int32_t get_offset_of_s_List_4() { return static_cast<int32_t>(offsetof(Selectable_tAA9065030FE0468018DEC880302F95FEA9C0133A_StaticFields, ___s_List_4)); }
	inline List_1_tC6550F4D86CF67D987B6B46F46941B36D02A9680 * get_s_List_4() const { return ___s_List_4; }
	inline List_1_tC6550F4D86CF67D987B6B46F46941B36D02A9680 ** get_address_of_s_List_4() { return &___s_List_4; }
	inline void set_s_List_4(List_1_tC6550F4D86CF67D987B6B46F46941B36D02A9680 * value)
	{
		___s_List_4 = value;
		Il2CppCodeGenWriteBarrier((&___s_List_4), value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
#endif // SELECTABLE_TAA9065030FE0468018DEC880302F95FEA9C0133A_H
#ifndef OVERRIDETESTFORUI_TBE0191B652C971AB79ED3E133FEF14489D422394_H
#define OVERRIDETESTFORUI_TBE0191B652C971AB79ED3E133FEF14489D422394_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// unitycoder_MobilePaint.OverrideTestForUI
struct  OverrideTestForUI_tBE0191B652C971AB79ED3E133FEF14489D422394  : public MobilePaint_tC25928758E48181B341DE30F410E3EA407D005E5
{
public:

public:
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
#endif // OVERRIDETESTFORUI_TBE0191B652C971AB79ED3E133FEF14489D422394_H
#ifndef TOGGLE_T9ADD572046F831945ED0E48A01B50FEA1CA52106_H
#define TOGGLE_T9ADD572046F831945ED0E48A01B50FEA1CA52106_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// UnityEngine.UI.Toggle
struct  Toggle_t9ADD572046F831945ED0E48A01B50FEA1CA52106  : public Selectable_tAA9065030FE0468018DEC880302F95FEA9C0133A
{
public:
	// UnityEngine.UI.Toggle/ToggleTransition UnityEngine.UI.Toggle::toggleTransition
	int32_t ___toggleTransition_18;
	// UnityEngine.UI.Graphic UnityEngine.UI.Toggle::graphic
	Graphic_tBA2C3EF11D3DAEBB57F6879AB0BB4F8BD40D00D8 * ___graphic_19;
	// UnityEngine.UI.ToggleGroup UnityEngine.UI.Toggle::m_Group
	ToggleGroup_t11E2B254D3C968C7D0DA11C606CC06D7D7F0D786 * ___m_Group_20;
	// UnityEngine.UI.Toggle/ToggleEvent UnityEngine.UI.Toggle::onValueChanged
	ToggleEvent_t50D925F8E220FB47DA738411CEF9C57FF7E1DC43 * ___onValueChanged_21;
	// System.Boolean UnityEngine.UI.Toggle::m_IsOn
	bool ___m_IsOn_22;

public:
	inline static int32_t get_offset_of_toggleTransition_18() { return static_cast<int32_t>(offsetof(Toggle_t9ADD572046F831945ED0E48A01B50FEA1CA52106, ___toggleTransition_18)); }
	inline int32_t get_toggleTransition_18() const { return ___toggleTransition_18; }
	inline int32_t* get_address_of_toggleTransition_18() { return &___toggleTransition_18; }
	inline void set_toggleTransition_18(int32_t value)
	{
		___toggleTransition_18 = value;
	}

	inline static int32_t get_offset_of_graphic_19() { return static_cast<int32_t>(offsetof(Toggle_t9ADD572046F831945ED0E48A01B50FEA1CA52106, ___graphic_19)); }
	inline Graphic_tBA2C3EF11D3DAEBB57F6879AB0BB4F8BD40D00D8 * get_graphic_19() const { return ___graphic_19; }
	inline Graphic_tBA2C3EF11D3DAEBB57F6879AB0BB4F8BD40D00D8 ** get_address_of_graphic_19() { return &___graphic_19; }
	inline void set_graphic_19(Graphic_tBA2C3EF11D3DAEBB57F6879AB0BB4F8BD40D00D8 * value)
	{
		___graphic_19 = value;
		Il2CppCodeGenWriteBarrier((&___graphic_19), value);
	}

	inline static int32_t get_offset_of_m_Group_20() { return static_cast<int32_t>(offsetof(Toggle_t9ADD572046F831945ED0E48A01B50FEA1CA52106, ___m_Group_20)); }
	inline ToggleGroup_t11E2B254D3C968C7D0DA11C606CC06D7D7F0D786 * get_m_Group_20() const { return ___m_Group_20; }
	inline ToggleGroup_t11E2B254D3C968C7D0DA11C606CC06D7D7F0D786 ** get_address_of_m_Group_20() { return &___m_Group_20; }
	inline void set_m_Group_20(ToggleGroup_t11E2B254D3C968C7D0DA11C606CC06D7D7F0D786 * value)
	{
		___m_Group_20 = value;
		Il2CppCodeGenWriteBarrier((&___m_Group_20), value);
	}

	inline static int32_t get_offset_of_onValueChanged_21() { return static_cast<int32_t>(offsetof(Toggle_t9ADD572046F831945ED0E48A01B50FEA1CA52106, ___onValueChanged_21)); }
	inline ToggleEvent_t50D925F8E220FB47DA738411CEF9C57FF7E1DC43 * get_onValueChanged_21() const { return ___onValueChanged_21; }
	inline ToggleEvent_t50D925F8E220FB47DA738411CEF9C57FF7E1DC43 ** get_address_of_onValueChanged_21() { return &___onValueChanged_21; }
	inline void set_onValueChanged_21(ToggleEvent_t50D925F8E220FB47DA738411CEF9C57FF7E1DC43 * value)
	{
		___onValueChanged_21 = value;
		Il2CppCodeGenWriteBarrier((&___onValueChanged_21), value);
	}

	inline static int32_t get_offset_of_m_IsOn_22() { return static_cast<int32_t>(offsetof(Toggle_t9ADD572046F831945ED0E48A01B50FEA1CA52106, ___m_IsOn_22)); }
	inline bool get_m_IsOn_22() const { return ___m_IsOn_22; }
	inline bool* get_address_of_m_IsOn_22() { return &___m_IsOn_22; }
	inline void set_m_IsOn_22(bool value)
	{
		___m_IsOn_22 = value;
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
#endif // TOGGLE_T9ADD572046F831945ED0E48A01B50FEA1CA52106_H
// System.Delegate[]
struct DelegateU5BU5D_tDFCDEE2A6322F96C0FE49AF47E9ADB8C4B294E86  : public RuntimeArray
{
public:
	ALIGN_FIELD (8) Delegate_t * m_Items[1];

public:
	inline Delegate_t * GetAt(il2cpp_array_size_t index) const
	{
		IL2CPP_ARRAY_BOUNDS_CHECK(index, (uint32_t)(this)->max_length);
		return m_Items[index];
	}
	inline Delegate_t ** GetAddressAt(il2cpp_array_size_t index)
	{
		IL2CPP_ARRAY_BOUNDS_CHECK(index, (uint32_t)(this)->max_length);
		return m_Items + index;
	}
	inline void SetAt(il2cpp_array_size_t index, Delegate_t * value)
	{
		IL2CPP_ARRAY_BOUNDS_CHECK(index, (uint32_t)(this)->max_length);
		m_Items[index] = value;
		Il2CppCodeGenWriteBarrier(m_Items + index, value);
	}
	inline Delegate_t * GetAtUnchecked(il2cpp_array_size_t index) const
	{
		return m_Items[index];
	}
	inline Delegate_t ** GetAddressAtUnchecked(il2cpp_array_size_t index)
	{
		return m_Items + index;
	}
	inline void SetAtUnchecked(il2cpp_array_size_t index, Delegate_t * value)
	{
		m_Items[index] = value;
		Il2CppCodeGenWriteBarrier(m_Items + index, value);
	}
};
// UnityEngine.Texture2D[]
struct Texture2DU5BU5D_tCAC03055C735C020BAFC218D55183CF03E74C1C9  : public RuntimeArray
{
public:
	ALIGN_FIELD (8) Texture2D_tBBF96AC337723E2EF156DF17E09D4379FD05DE1C * m_Items[1];

public:
	inline Texture2D_tBBF96AC337723E2EF156DF17E09D4379FD05DE1C * GetAt(il2cpp_array_size_t index) const
	{
		IL2CPP_ARRAY_BOUNDS_CHECK(index, (uint32_t)(this)->max_length);
		return m_Items[index];
	}
	inline Texture2D_tBBF96AC337723E2EF156DF17E09D4379FD05DE1C ** GetAddressAt(il2cpp_array_size_t index)
	{
		IL2CPP_ARRAY_BOUNDS_CHECK(index, (uint32_t)(this)->max_length);
		return m_Items + index;
	}
	inline void SetAt(il2cpp_array_size_t index, Texture2D_tBBF96AC337723E2EF156DF17E09D4379FD05DE1C * value)
	{
		IL2CPP_ARRAY_BOUNDS_CHECK(index, (uint32_t)(this)->max_length);
		m_Items[index] = value;
		Il2CppCodeGenWriteBarrier(m_Items + index, value);
	}
	inline Texture2D_tBBF96AC337723E2EF156DF17E09D4379FD05DE1C * GetAtUnchecked(il2cpp_array_size_t index) const
	{
		return m_Items[index];
	}
	inline Texture2D_tBBF96AC337723E2EF156DF17E09D4379FD05DE1C ** GetAddressAtUnchecked(il2cpp_array_size_t index)
	{
		return m_Items + index;
	}
	inline void SetAtUnchecked(il2cpp_array_size_t index, Texture2D_tBBF96AC337723E2EF156DF17E09D4379FD05DE1C * value)
	{
		m_Items[index] = value;
		Il2CppCodeGenWriteBarrier(m_Items + index, value);
	}
};
// System.Byte[]
struct ByteU5BU5D_tD06FDBE8142446525DF1C40351D523A228373821  : public RuntimeArray
{
public:
	ALIGN_FIELD (8) uint8_t m_Items[1];

public:
	inline uint8_t GetAt(il2cpp_array_size_t index) const
	{
		IL2CPP_ARRAY_BOUNDS_CHECK(index, (uint32_t)(this)->max_length);
		return m_Items[index];
	}
	inline uint8_t* GetAddressAt(il2cpp_array_size_t index)
	{
		IL2CPP_ARRAY_BOUNDS_CHECK(index, (uint32_t)(this)->max_length);
		return m_Items + index;
	}
	inline void SetAt(il2cpp_array_size_t index, uint8_t value)
	{
		IL2CPP_ARRAY_BOUNDS_CHECK(index, (uint32_t)(this)->max_length);
		m_Items[index] = value;
	}
	inline uint8_t GetAtUnchecked(il2cpp_array_size_t index) const
	{
		return m_Items[index];
	}
	inline uint8_t* GetAddressAtUnchecked(il2cpp_array_size_t index)
	{
		return m_Items + index;
	}
	inline void SetAtUnchecked(il2cpp_array_size_t index, uint8_t value)
	{
		m_Items[index] = value;
	}
};
// UnityEngine.Vector4[]
struct Vector4U5BU5D_t51402C154FFFCF7217A9BEC4B834F0B726C10F66  : public RuntimeArray
{
public:
	ALIGN_FIELD (8) Vector4_tD148D6428C3F8FF6CD998F82090113C2B490B76E  m_Items[1];

public:
	inline Vector4_tD148D6428C3F8FF6CD998F82090113C2B490B76E  GetAt(il2cpp_array_size_t index) const
	{
		IL2CPP_ARRAY_BOUNDS_CHECK(index, (uint32_t)(this)->max_length);
		return m_Items[index];
	}
	inline Vector4_tD148D6428C3F8FF6CD998F82090113C2B490B76E * GetAddressAt(il2cpp_array_size_t index)
	{
		IL2CPP_ARRAY_BOUNDS_CHECK(index, (uint32_t)(this)->max_length);
		return m_Items + index;
	}
	inline void SetAt(il2cpp_array_size_t index, Vector4_tD148D6428C3F8FF6CD998F82090113C2B490B76E  value)
	{
		IL2CPP_ARRAY_BOUNDS_CHECK(index, (uint32_t)(this)->max_length);
		m_Items[index] = value;
	}
	inline Vector4_tD148D6428C3F8FF6CD998F82090113C2B490B76E  GetAtUnchecked(il2cpp_array_size_t index) const
	{
		return m_Items[index];
	}
	inline Vector4_tD148D6428C3F8FF6CD998F82090113C2B490B76E * GetAddressAtUnchecked(il2cpp_array_size_t index)
	{
		return m_Items + index;
	}
	inline void SetAtUnchecked(il2cpp_array_size_t index, Vector4_tD148D6428C3F8FF6CD998F82090113C2B490B76E  value)
	{
		m_Items[index] = value;
	}
};
// UnityEngine.Vector3[]
struct Vector3U5BU5D_tB9EC3346CC4A0EA5447D968E84A9AC1F6F372C28  : public RuntimeArray
{
public:
	ALIGN_FIELD (8) Vector3_tDCF05E21F632FE2BA260C06E0D10CA81513E6720  m_Items[1];

public:
	inline Vector3_tDCF05E21F632FE2BA260C06E0D10CA81513E6720  GetAt(il2cpp_array_size_t index) const
	{
		IL2CPP_ARRAY_BOUNDS_CHECK(index, (uint32_t)(this)->max_length);
		return m_Items[index];
	}
	inline Vector3_tDCF05E21F632FE2BA260C06E0D10CA81513E6720 * GetAddressAt(il2cpp_array_size_t index)
	{
		IL2CPP_ARRAY_BOUNDS_CHECK(index, (uint32_t)(this)->max_length);
		return m_Items + index;
	}
	inline void SetAt(il2cpp_array_size_t index, Vector3_tDCF05E21F632FE2BA260C06E0D10CA81513E6720  value)
	{
		IL2CPP_ARRAY_BOUNDS_CHECK(index, (uint32_t)(this)->max_length);
		m_Items[index] = value;
	}
	inline Vector3_tDCF05E21F632FE2BA260C06E0D10CA81513E6720  GetAtUnchecked(il2cpp_array_size_t index) const
	{
		return m_Items[index];
	}
	inline Vector3_tDCF05E21F632FE2BA260C06E0D10CA81513E6720 * GetAddressAtUnchecked(il2cpp_array_size_t index)
	{
		return m_Items + index;
	}
	inline void SetAtUnchecked(il2cpp_array_size_t index, Vector3_tDCF05E21F632FE2BA260C06E0D10CA81513E6720  value)
	{
		m_Items[index] = value;
	}
};
// UnityEngine.Vector2[]
struct Vector2U5BU5D_tA065A07DFC060C1B8786BBAA5F3A6577CCEB27D6  : public RuntimeArray
{
public:
	ALIGN_FIELD (8) Vector2_tA85D2DD88578276CA8A8796756458277E72D073D  m_Items[1];

public:
	inline Vector2_tA85D2DD88578276CA8A8796756458277E72D073D  GetAt(il2cpp_array_size_t index) const
	{
		IL2CPP_ARRAY_BOUNDS_CHECK(index, (uint32_t)(this)->max_length);
		return m_Items[index];
	}
	inline Vector2_tA85D2DD88578276CA8A8796756458277E72D073D * GetAddressAt(il2cpp_array_size_t index)
	{
		IL2CPP_ARRAY_BOUNDS_CHECK(index, (uint32_t)(this)->max_length);
		return m_Items + index;
	}
	inline void SetAt(il2cpp_array_size_t index, Vector2_tA85D2DD88578276CA8A8796756458277E72D073D  value)
	{
		IL2CPP_ARRAY_BOUNDS_CHECK(index, (uint32_t)(this)->max_length);
		m_Items[index] = value;
	}
	inline Vector2_tA85D2DD88578276CA8A8796756458277E72D073D  GetAtUnchecked(il2cpp_array_size_t index) const
	{
		return m_Items[index];
	}
	inline Vector2_tA85D2DD88578276CA8A8796756458277E72D073D * GetAddressAtUnchecked(il2cpp_array_size_t index)
	{
		return m_Items + index;
	}
	inline void SetAtUnchecked(il2cpp_array_size_t index, Vector2_tA85D2DD88578276CA8A8796756458277E72D073D  value)
	{
		m_Items[index] = value;
	}
};
// System.Int32[]
struct Int32U5BU5D_t2B9E4FDDDB9F0A00EC0AC631BA2DA915EB1ECF83  : public RuntimeArray
{
public:
	ALIGN_FIELD (8) int32_t m_Items[1];

public:
	inline int32_t GetAt(il2cpp_array_size_t index) const
	{
		IL2CPP_ARRAY_BOUNDS_CHECK(index, (uint32_t)(this)->max_length);
		return m_Items[index];
	}
	inline int32_t* GetAddressAt(il2cpp_array_size_t index)
	{
		IL2CPP_ARRAY_BOUNDS_CHECK(index, (uint32_t)(this)->max_length);
		return m_Items + index;
	}
	inline void SetAt(il2cpp_array_size_t index, int32_t value)
	{
		IL2CPP_ARRAY_BOUNDS_CHECK(index, (uint32_t)(this)->max_length);
		m_Items[index] = value;
	}
	inline int32_t GetAtUnchecked(il2cpp_array_size_t index) const
	{
		return m_Items[index];
	}
	inline int32_t* GetAddressAtUnchecked(il2cpp_array_size_t index)
	{
		return m_Items + index;
	}
	inline void SetAtUnchecked(il2cpp_array_size_t index, int32_t value)
	{
		m_Items[index] = value;
	}
};


// !!0 UnityEngine.Component::GetComponent<System.Object>()
extern "C" IL2CPP_METHOD_ATTR RuntimeObject * Component_GetComponent_TisRuntimeObject_m3FED1FF44F93EF1C3A07526800331B638EF4105B_gshared (Component_t05064EF382ABCAF4B8C94F8A350EA85184C26621 * __this, const RuntimeMethod* method);
// System.Void UnityEngine.Events.UnityAction`1<System.Boolean>::.ctor(System.Object,System.IntPtr)
extern "C" IL2CPP_METHOD_ATTR void UnityAction_1__ctor_m846CC5F9F2FD2F58CD1E78E7A4EB55DC5D6CA696_gshared (UnityAction_1_tB994D127B02789CE2010397AEF756615E5F84FDC * __this, RuntimeObject * p0, intptr_t p1, const RuntimeMethod* method);
// System.Void UnityEngine.Events.UnityEvent`1<System.Boolean>::AddListener(UnityEngine.Events.UnityAction`1<!0>)
extern "C" IL2CPP_METHOD_ATTR void UnityEvent_1_AddListener_mBCA646AF6B22F9F8190175F6AFF5195A9BED3FCA_gshared (UnityEvent_1_t6FE5C79FD433599728A9AA732E588823AB88FDB5 * __this, UnityAction_1_tB994D127B02789CE2010397AEF756615E5F84FDC * p0, const RuntimeMethod* method);
// !!0 UnityEngine.GameObject::GetComponent<System.Object>()
extern "C" IL2CPP_METHOD_ATTR RuntimeObject * GameObject_GetComponent_TisRuntimeObject_m41E09C4CA476451FE275573062956CED105CB79A_gshared (GameObject_tBD1244AD56B4E59AAD76E5E7C9282EC5CE434F0F * __this, const RuntimeMethod* method);

// System.Void UnityEngine.Debug::Log(System.Object)
extern "C" IL2CPP_METHOD_ATTR void Debug_Log_m4B7C70BAFD477C6BDB59C88A0934F0B018D03708 (RuntimeObject * p0, const RuntimeMethod* method);
// System.Void unitycoder_MobilePaint.MobilePaint::.ctor()
extern "C" IL2CPP_METHOD_ATTR void MobilePaint__ctor_mDDC635FD438A7A429D15304566C8B852DA8023C7 (MobilePaint_tC25928758E48181B341DE30F410E3EA407D005E5 * __this, const RuntimeMethod* method);
// System.Boolean UnityEngine.Object::op_Equality(UnityEngine.Object,UnityEngine.Object)
extern "C" IL2CPP_METHOD_ATTR bool Object_op_Equality_mBC2401774F3BE33E8CF6F0A8148E66C95D6CFF1C (Object_tAE11E5E46CD5C37C9F3E8950C00CD8B45666A2D0 * p0, Object_tAE11E5E46CD5C37C9F3E8950C00CD8B45666A2D0 * p1, const RuntimeMethod* method);
// UnityEngine.Transform UnityEngine.Component::get_transform()
extern "C" IL2CPP_METHOD_ATTR Transform_tBB9E78A2766C3C83599A8F66EDE7D1FCAFC66EDA * Component_get_transform_m00F05BD782F920C301A7EBA480F3B7A904C07EC9 (Component_t05064EF382ABCAF4B8C94F8A350EA85184C26621 * __this, const RuntimeMethod* method);
// System.String UnityEngine.Object::get_name()
extern "C" IL2CPP_METHOD_ATTR String_t* Object_get_name_mA2D400141CB3C991C87A2556429781DE961A83CE (Object_tAE11E5E46CD5C37C9F3E8950C00CD8B45666A2D0 * __this, const RuntimeMethod* method);
// System.String System.String::Concat(System.String,System.String)
extern "C" IL2CPP_METHOD_ATTR String_t* String_Concat_mB78D0094592718DA6D5DB6C712A9C225631666BE (String_t* p0, String_t* p1, const RuntimeMethod* method);
// UnityEngine.GameObject UnityEngine.Component::get_gameObject()
extern "C" IL2CPP_METHOD_ATTR GameObject_tBD1244AD56B4E59AAD76E5E7C9282EC5CE434F0F * Component_get_gameObject_m0B0570BA8DDD3CD78A9DB568EA18D7317686603C (Component_t05064EF382ABCAF4B8C94F8A350EA85184C26621 * __this, const RuntimeMethod* method);
// System.Void UnityEngine.Debug::LogError(System.Object,UnityEngine.Object)
extern "C" IL2CPP_METHOD_ATTR void Debug_LogError_m97139CB2EE76D5CD8308C1AD0499A5F163FC7F51 (RuntimeObject * p0, Object_tAE11E5E46CD5C37C9F3E8950C00CD8B45666A2D0 * p1, const RuntimeMethod* method);
// System.Void UnityEngine.MonoBehaviour::.ctor()
extern "C" IL2CPP_METHOD_ATTR void MonoBehaviour__ctor_mEAEC84B222C60319D593E456D769B3311DFCEF97 (MonoBehaviour_t4A60845CF505405AF8BE8C61CC07F75CADEF6429 * __this, const RuntimeMethod* method);
// System.Void unitycoder_MobilePaint.MobilePaint::SetCanvasImage(UnityEngine.Texture2D)
extern "C" IL2CPP_METHOD_ATTR void MobilePaint_SetCanvasImage_mD9FB8536EE50E16FC25A827A84DCF2B3A6FB5D9C (MobilePaint_tC25928758E48181B341DE30F410E3EA407D005E5 * __this, Texture2D_tBBF96AC337723E2EF156DF17E09D4379FD05DE1C * ___newTexture0, const RuntimeMethod* method);
// System.Void unitycoder_MobilePaint.MobilePaint::SetMaskImage(UnityEngine.Texture2D)
extern "C" IL2CPP_METHOD_ATTR void MobilePaint_SetMaskImage_m80E98353C9F9EF9C4A76658F6734A9375FC329D7 (MobilePaint_tC25928758E48181B341DE30F410E3EA407D005E5 * __this, Texture2D_tBBF96AC337723E2EF156DF17E09D4379FD05DE1C * ___newTexture0, const RuntimeMethod* method);
// !!0 UnityEngine.Component::GetComponent<UnityEngine.UI.Toggle>()
inline Toggle_t9ADD572046F831945ED0E48A01B50FEA1CA52106 * Component_GetComponent_TisToggle_t9ADD572046F831945ED0E48A01B50FEA1CA52106_m89C4B9EA41130113FE63C1D06704BB4B91AD779B (Component_t05064EF382ABCAF4B8C94F8A350EA85184C26621 * __this, const RuntimeMethod* method)
{
	return ((  Toggle_t9ADD572046F831945ED0E48A01B50FEA1CA52106 * (*) (Component_t05064EF382ABCAF4B8C94F8A350EA85184C26621 *, const RuntimeMethod*))Component_GetComponent_TisRuntimeObject_m3FED1FF44F93EF1C3A07526800331B638EF4105B_gshared)(__this, method);
}
// System.Void UnityEngine.Events.UnityAction`1<System.Boolean>::.ctor(System.Object,System.IntPtr)
inline void UnityAction_1__ctor_m846CC5F9F2FD2F58CD1E78E7A4EB55DC5D6CA696 (UnityAction_1_tB994D127B02789CE2010397AEF756615E5F84FDC * __this, RuntimeObject * p0, intptr_t p1, const RuntimeMethod* method)
{
	((  void (*) (UnityAction_1_tB994D127B02789CE2010397AEF756615E5F84FDC *, RuntimeObject *, intptr_t, const RuntimeMethod*))UnityAction_1__ctor_m846CC5F9F2FD2F58CD1E78E7A4EB55DC5D6CA696_gshared)(__this, p0, p1, method);
}
// System.Void UnityEngine.Events.UnityEvent`1<System.Boolean>::AddListener(UnityEngine.Events.UnityAction`1<!0>)
inline void UnityEvent_1_AddListener_mBCA646AF6B22F9F8190175F6AFF5195A9BED3FCA (UnityEvent_1_t6FE5C79FD433599728A9AA732E588823AB88FDB5 * __this, UnityAction_1_tB994D127B02789CE2010397AEF756615E5F84FDC * p0, const RuntimeMethod* method)
{
	((  void (*) (UnityEvent_1_t6FE5C79FD433599728A9AA732E588823AB88FDB5 *, UnityAction_1_tB994D127B02789CE2010397AEF756615E5F84FDC *, const RuntimeMethod*))UnityEvent_1_AddListener_mBCA646AF6B22F9F8190175F6AFF5195A9BED3FCA_gshared)(__this, p0, method);
}
// System.Boolean UnityEngine.UI.Toggle::get_isOn()
extern "C" IL2CPP_METHOD_ATTR bool Toggle_get_isOn_mE13D628534F60138373B3E52CC93301DE59DB616 (Toggle_t9ADD572046F831945ED0E48A01B50FEA1CA52106 * __this, const RuntimeMethod* method);
// System.Void unitycoder_MobilePaint.MobilePaint::SetDrawModeBrush()
extern "C" IL2CPP_METHOD_ATTR void MobilePaint_SetDrawModeBrush_m42238934F471966676329992553EF0287E5DD831 (MobilePaint_tC25928758E48181B341DE30F410E3EA407D005E5 * __this, const RuntimeMethod* method);
// System.Void unitycoder_MobilePaint.ToggleBrushModeUI::SetMode()
extern "C" IL2CPP_METHOD_ATTR void ToggleBrushModeUI_SetMode_m0D6E237D85BE989C46F3399244FB8B9065AC2BF8 (ToggleBrushModeUI_t4B6DF517F8B4743603417CD2EB16093A8DE0758B * __this, const RuntimeMethod* method);
// System.Void UnityEngine.Debug::LogWarning(System.Object,UnityEngine.Object)
extern "C" IL2CPP_METHOD_ATTR void Debug_LogWarning_mD417697331190AC1D21C463F412C475103A7256E (RuntimeObject * p0, Object_tAE11E5E46CD5C37C9F3E8950C00CD8B45666A2D0 * p1, const RuntimeMethod* method);
// System.Void UnityEngine.UI.Selectable::set_interactable(System.Boolean)
extern "C" IL2CPP_METHOD_ATTR void Selectable_set_interactable_mD5096017CC3058D280066EB9ABDDF5062983A94F (Selectable_tAA9065030FE0468018DEC880302F95FEA9C0133A * __this, bool p0, const RuntimeMethod* method);
// System.Void UnityEngine.GameObject::SetActive(System.Boolean)
extern "C" IL2CPP_METHOD_ATTR void GameObject_SetActive_m25A39F6D9FB68C51F13313F9804E85ACC937BC04 (GameObject_tBD1244AD56B4E59AAD76E5E7C9282EC5CE434F0F * __this, bool p0, const RuntimeMethod* method);
// System.Void unitycoder_MobilePaint.MobilePaint::SetDrawModePattern()
extern "C" IL2CPP_METHOD_ATTR void MobilePaint_SetDrawModePattern_m00162C11B3A1AE9E842F127361FF941186F7D91D (MobilePaint_tC25928758E48181B341DE30F410E3EA407D005E5 * __this, const RuntimeMethod* method);
// System.Void unitycoder_MobilePaint.ToggleCustomPatternModeUI::SetMode()
extern "C" IL2CPP_METHOD_ATTR void ToggleCustomPatternModeUI_SetMode_mF0225DFF7BFBCF4A096FF61DBE8631B3607BCDFD (ToggleCustomPatternModeUI_tF5121E1792E8D86FB425CACACF9513D2B6E470AA * __this, const RuntimeMethod* method);
// System.Void unitycoder_MobilePaint.MobilePaint::SetDrawModeShapes()
extern "C" IL2CPP_METHOD_ATTR void MobilePaint_SetDrawModeShapes_m25B1CE7B0F5AEB924F1768B49AC053095B243152 (MobilePaint_tC25928758E48181B341DE30F410E3EA407D005E5 * __this, const RuntimeMethod* method);
// System.Void unitycoder_MobilePaint.ToggleCustomShapeModeUI::SetMode()
extern "C" IL2CPP_METHOD_ATTR void ToggleCustomShapeModeUI_SetMode_mE58A9402216F7D890A4258BD6D6BE6D3F4FA4D2C (ToggleCustomShapeModeUI_t5DABF74118B1166FDBB31E08F25358F0FC907BF2 * __this, const RuntimeMethod* method);
// System.Void unitycoder_MobilePaint.MobilePaint::SetDrawModeEraser()
extern "C" IL2CPP_METHOD_ATTR void MobilePaint_SetDrawModeEraser_m34260FB4E137E97721E93899D2497AF253D1BEB2 (MobilePaint_tC25928758E48181B341DE30F410E3EA407D005E5 * __this, const RuntimeMethod* method);
// System.Void unitycoder_MobilePaint.ToggleEraserModeUI::SetMode()
extern "C" IL2CPP_METHOD_ATTR void ToggleEraserModeUI_SetMode_mB8CD91227A8742223015F5DBB79CC498D1AE3B6B (ToggleEraserModeUI_t12A48F99C7CA25B41997882C81CCF6274E6B09D2 * __this, const RuntimeMethod* method);
// System.Void unitycoder_MobilePaint.MobilePaint::SetDrawModeFill()
extern "C" IL2CPP_METHOD_ATTR void MobilePaint_SetDrawModeFill_mAFA44CF5AC92CEDCDC9E962946C292460F5CAF1C (MobilePaint_tC25928758E48181B341DE30F410E3EA407D005E5 * __this, const RuntimeMethod* method);
// System.Void unitycoder_MobilePaint.ToggleFloodFillModeUI::SetMode()
extern "C" IL2CPP_METHOD_ATTR void ToggleFloodFillModeUI_SetMode_m64DE801CCA5251718582F3FC81B83D279BE9F811 (ToggleFloodFillModeUI_tF40BA330FD9EEC86BEA5CD7943EC4599BAD93095 * __this, const RuntimeMethod* method);
// System.Void unitycoder_MobilePaint.MobilePaint::SetDrawModeLine()
extern "C" IL2CPP_METHOD_ATTR void MobilePaint_SetDrawModeLine_mF7D3E255A149F536C56F03AF0923747102446B19 (MobilePaint_tC25928758E48181B341DE30F410E3EA407D005E5 * __this, const RuntimeMethod* method);
// System.Void unitycoder_MobilePaint.ToggleLineModeUI::SetMode()
extern "C" IL2CPP_METHOD_ATTR void ToggleLineModeUI_SetMode_m2C8B487144B734A99D53DEA0DF9563DEFD1B5979 (ToggleLineModeUI_tB4F725C4D6DD648C397DB3AC4AAB347EC4AA94C4 * __this, const RuntimeMethod* method);
// !!0 UnityEngine.GameObject::GetComponent<unitycoder_MobilePaint.MobilePaint>()
inline MobilePaint_tC25928758E48181B341DE30F410E3EA407D005E5 * GameObject_GetComponent_TisMobilePaint_tC25928758E48181B341DE30F410E3EA407D005E5_mEC9B744C4448971CB528E3CFAB3EC41F435E2944 (GameObject_tBD1244AD56B4E59AAD76E5E7C9282EC5CE434F0F * __this, const RuntimeMethod* method)
{
	return ((  MobilePaint_tC25928758E48181B341DE30F410E3EA407D005E5 * (*) (GameObject_tBD1244AD56B4E59AAD76E5E7C9282EC5CE434F0F *, const RuntimeMethod*))GameObject_GetComponent_TisRuntimeObject_m41E09C4CA476451FE275573062956CED105CB79A_gshared)(__this, method);
}
// !!0 UnityEngine.Component::GetComponent<UnityEngine.GUITexture>()
inline GUITexture_t2A2F300B0F9D542DADB532DEC861D1711B5C46F3 * Component_GetComponent_TisGUITexture_t2A2F300B0F9D542DADB532DEC861D1711B5C46F3_m8BBADD3541C0470568F03947E759412155A68210 (Component_t05064EF382ABCAF4B8C94F8A350EA85184C26621 * __this, const RuntimeMethod* method)
{
	return ((  GUITexture_t2A2F300B0F9D542DADB532DEC861D1711B5C46F3 * (*) (Component_t05064EF382ABCAF4B8C94F8A350EA85184C26621 *, const RuntimeMethod*))Component_GetComponent_TisRuntimeObject_m3FED1FF44F93EF1C3A07526800331B638EF4105B_gshared)(__this, method);
}
// System.Void UnityEngine.Color::.ctor(System.Single,System.Single,System.Single,System.Single)
extern "C" IL2CPP_METHOD_ATTR void Color__ctor_m20DF490CEB364C4FC36D7EE392640DF5B7420D7C (Color_t119BCA590009762C7223FDD3AF9706653AC84ED2 * __this, float p0, float p1, float p2, float p3, const RuntimeMethod* method);
// System.Void UnityEngine.GUITexture::set_color(UnityEngine.Color)
extern "C" IL2CPP_METHOD_ATTR void GUITexture_set_color_mD2A5789D387F61060B6CEAE98D5F5DB3D3AF671A (GUITexture_t2A2F300B0F9D542DADB532DEC861D1711B5C46F3 * __this, Color_t119BCA590009762C7223FDD3AF9706653AC84ED2  p0, const RuntimeMethod* method);
// !!0 UnityEngine.GameObject::GetComponent<UnityEngine.GUITexture>()
inline GUITexture_t2A2F300B0F9D542DADB532DEC861D1711B5C46F3 * GameObject_GetComponent_TisGUITexture_t2A2F300B0F9D542DADB532DEC861D1711B5C46F3_m100DA46881E26B04E4A5E2906D85B4C3C7A71E94 (GameObject_tBD1244AD56B4E59AAD76E5E7C9282EC5CE434F0F * __this, const RuntimeMethod* method)
{
	return ((  GUITexture_t2A2F300B0F9D542DADB532DEC861D1711B5C46F3 * (*) (GameObject_tBD1244AD56B4E59AAD76E5E7C9282EC5CE434F0F *, const RuntimeMethod*))GameObject_GetComponent_TisRuntimeObject_m41E09C4CA476451FE275573062956CED105CB79A_gshared)(__this, method);
}
// System.Int32 UnityEngine.GameObject::get_layer()
extern "C" IL2CPP_METHOD_ATTR int32_t GameObject_get_layer_m0DE90D8A3D3AA80497A3A80FBEAC2D207C16B9C8 (GameObject_tBD1244AD56B4E59AAD76E5E7C9282EC5CE434F0F * __this, const RuntimeMethod* method);
// System.Void UnityEngine.GameObject::set_layer(System.Int32)
extern "C" IL2CPP_METHOD_ATTR void GameObject_set_layer_mDAC8037FCFD0CE62DB66004C4342EA20CF604907 (GameObject_tBD1244AD56B4E59AAD76E5E7C9282EC5CE434F0F * __this, int32_t p0, const RuntimeMethod* method);
// System.Void unitycoder_MobilePaint.MobilePaint::SetPanZoomMode(System.Boolean)
extern "C" IL2CPP_METHOD_ATTR void MobilePaint_SetPanZoomMode_m7ED4BE8EECC07D14299CAAAFEE2655C3782CA9DA (MobilePaint_tC25928758E48181B341DE30F410E3EA407D005E5 * __this, bool ___state0, const RuntimeMethod* method);
// System.Void unitycoder_MobilePaint.TogglePanZoomModeUI::ToggleZoomPan()
extern "C" IL2CPP_METHOD_ATTR void TogglePanZoomModeUI_ToggleZoomPan_m5C400FF51681E0C0ED6EAFE6CD7FFC000A2D8D81 (TogglePanZoomModeUI_t7EA98A500D67F4E63FCA50307325D99362E30F00 * __this, const RuntimeMethod* method);
// System.Int32 UnityEngine.Screen::get_height()
extern "C" IL2CPP_METHOD_ATTR int32_t Screen_get_height_mF5B64EBC4CDE0EAAA5713C1452ED2CE475F25150 (const RuntimeMethod* method);
// System.Boolean UnityEngine.Object::op_Inequality(UnityEngine.Object,UnityEngine.Object)
extern "C" IL2CPP_METHOD_ATTR bool Object_op_Inequality_m31EF58E217E8F4BDD3E409DEF79E1AEE95874FC1 (Object_tAE11E5E46CD5C37C9F3E8950C00CD8B45666A2D0 * p0, Object_tAE11E5E46CD5C37C9F3E8950C00CD8B45666A2D0 * p1, const RuntimeMethod* method);
// UnityEngine.Rect UnityEngine.GUITexture::get_pixelInset()
extern "C" IL2CPP_METHOD_ATTR Rect_t35B976DE901B5423C11705E156938EA27AB402CE  GUITexture_get_pixelInset_m566DB8F4EB5F0BB244A6C27C56B2A9B9E33479F3 (GUITexture_t2A2F300B0F9D542DADB532DEC861D1711B5C46F3 * __this, const RuntimeMethod* method);
// System.Single UnityEngine.Rect::get_x()
extern "C" IL2CPP_METHOD_ATTR float Rect_get_x_mC51A461F546D14832EB96B11A7198DADDE2597B7 (Rect_t35B976DE901B5423C11705E156938EA27AB402CE * __this, const RuntimeMethod* method);
// System.Single UnityEngine.Rect::get_y()
extern "C" IL2CPP_METHOD_ATTR float Rect_get_y_m53E3E4F62D9840FBEA751A66293038F1F5D1D45C (Rect_t35B976DE901B5423C11705E156938EA27AB402CE * __this, const RuntimeMethod* method);
// System.Single UnityEngine.Rect::get_width()
extern "C" IL2CPP_METHOD_ATTR float Rect_get_width_m54FF69FC2C086E2DC349ED091FD0D6576BFB1484 (Rect_t35B976DE901B5423C11705E156938EA27AB402CE * __this, const RuntimeMethod* method);
// System.Single UnityEngine.Rect::get_height()
extern "C" IL2CPP_METHOD_ATTR float Rect_get_height_m088C36990E0A255C5D7DCE36575DCE23ABB364B5 (Rect_t35B976DE901B5423C11705E156938EA27AB402CE * __this, const RuntimeMethod* method);
// System.Void UnityEngine.Rect::.ctor(System.Single,System.Single,System.Single,System.Single)
extern "C" IL2CPP_METHOD_ATTR void Rect__ctor_m50B92C75005C9C5A0D05E6E0EBB43AFAF7C66280 (Rect_t35B976DE901B5423C11705E156938EA27AB402CE * __this, float p0, float p1, float p2, float p3, const RuntimeMethod* method);
// System.Void UnityEngine.GUITexture::set_pixelInset(UnityEngine.Rect)
extern "C" IL2CPP_METHOD_ATTR void GUITexture_set_pixelInset_m8BFE100732874F03A136E1267124DEE2D50B32AD (GUITexture_t2A2F300B0F9D542DADB532DEC861D1711B5C46F3 * __this, Rect_t35B976DE901B5423C11705E156938EA27AB402CE  p0, const RuntimeMethod* method);
// !!0 UnityEngine.Component::GetComponent<UnityEngine.GUIText>()
inline GUIText_t1AAED515CF7E63F24B55C5FC988555DA14DA10F1 * Component_GetComponent_TisGUIText_t1AAED515CF7E63F24B55C5FC988555DA14DA10F1_m051AF02F5332F75F23DAD7A0E8AFA3DC70A92E62 (Component_t05064EF382ABCAF4B8C94F8A350EA85184C26621 * __this, const RuntimeMethod* method)
{
	return ((  GUIText_t1AAED515CF7E63F24B55C5FC988555DA14DA10F1 * (*) (Component_t05064EF382ABCAF4B8C94F8A350EA85184C26621 *, const RuntimeMethod*))Component_GetComponent_TisRuntimeObject_m3FED1FF44F93EF1C3A07526800331B638EF4105B_gshared)(__this, method);
}
// UnityEngine.Vector2 UnityEngine.GUIText::get_pixelOffset()
extern "C" IL2CPP_METHOD_ATTR Vector2_tA85D2DD88578276CA8A8796756458277E72D073D  GUIText_get_pixelOffset_m7EF7D59B5CCB113AA0476B7B5FDF7A75363D4C24 (GUIText_t1AAED515CF7E63F24B55C5FC988555DA14DA10F1 * __this, const RuntimeMethod* method);
// System.Void UnityEngine.Vector2::.ctor(System.Single,System.Single)
extern "C" IL2CPP_METHOD_ATTR void Vector2__ctor_mEE8FB117AB1F8DB746FB8B3EB4C0DA3BF2A230D0 (Vector2_tA85D2DD88578276CA8A8796756458277E72D073D * __this, float p0, float p1, const RuntimeMethod* method);
// System.Void UnityEngine.GUIText::set_pixelOffset(UnityEngine.Vector2)
extern "C" IL2CPP_METHOD_ATTR void GUIText_set_pixelOffset_m698D3D598BDBA9C58795F151994796B1C8BC5852 (GUIText_t1AAED515CF7E63F24B55C5FC988555DA14DA10F1 * __this, Vector2_tA85D2DD88578276CA8A8796756458277E72D073D  p0, const RuntimeMethod* method);
// System.Int32 UnityEngine.GUIText::get_fontSize()
extern "C" IL2CPP_METHOD_ATTR int32_t GUIText_get_fontSize_mB51DAB2EF493D7EA932EEC731603B4F0867F0F46 (GUIText_t1AAED515CF7E63F24B55C5FC988555DA14DA10F1 * __this, const RuntimeMethod* method);
// System.Void UnityEngine.GUIText::set_fontSize(System.Int32)
extern "C" IL2CPP_METHOD_ATTR void GUIText_set_fontSize_m1DD22870196D29901BD5B7691C6782E472A85FEC (GUIText_t1AAED515CF7E63F24B55C5FC988555DA14DA10F1 * __this, int32_t p0, const RuntimeMethod* method);
// System.Void UnityEngine.Object::Destroy(UnityEngine.Object)
extern "C" IL2CPP_METHOD_ATTR void Object_Destroy_m23B4562495BA35A74266D4372D45368F8C05109A (Object_tAE11E5E46CD5C37C9F3E8950C00CD8B45666A2D0 * p0, const RuntimeMethod* method);
// System.Boolean UnityEngine.Input::GetKeyDown(UnityEngine.KeyCode)
extern "C" IL2CPP_METHOD_ATTR bool Input_GetKeyDown_mD82B14BB87E1C811668BD1A2CFBC0CF3D4983FEA (int32_t p0, const RuntimeMethod* method);
// System.Void unitycoder_MobilePaint_samples.LoadImageFromDisk::LoadImageAsCanvas()
extern "C" IL2CPP_METHOD_ATTR void LoadImageFromDisk_LoadImageAsCanvas_m14529C87F9A3E52E4E057DCC3AE2FA5A543C965B (LoadImageFromDisk_t25E1AF3A9B41761AA5B2368589B30DE107BB0DFD * __this, const RuntimeMethod* method);
// System.String UnityEngine.Application::get_dataPath()
extern "C" IL2CPP_METHOD_ATTR String_t* Application_get_dataPath_m33D721D71C0687F0013C8953FDB0807B7B3F2A01 (const RuntimeMethod* method);
// System.String System.String::Concat(System.String,System.String,System.String)
extern "C" IL2CPP_METHOD_ATTR String_t* String_Concat_mF4626905368D6558695A823466A1AF65EADB9923 (String_t* p0, String_t* p1, String_t* p2, const RuntimeMethod* method);
// System.Byte[] System.IO.File::ReadAllBytes(System.String)
extern "C" IL2CPP_METHOD_ATTR ByteU5BU5D_tD06FDBE8142446525DF1C40351D523A228373821* File_ReadAllBytes_mF29468CED0B7B3B7C0971ACEBB16A38683718BEC (String_t* p0, const RuntimeMethod* method);
// System.Void UnityEngine.Texture2D::.ctor(System.Int32,System.Int32)
extern "C" IL2CPP_METHOD_ATTR void Texture2D__ctor_m0C86A87871AA8075791EF98499D34DA95ACB0E35 (Texture2D_tBBF96AC337723E2EF156DF17E09D4379FD05DE1C * __this, int32_t p0, int32_t p1, const RuntimeMethod* method);
// System.Boolean UnityEngine.ImageConversion::LoadImage(UnityEngine.Texture2D,System.Byte[])
extern "C" IL2CPP_METHOD_ATTR bool ImageConversion_LoadImage_m94295492E96C38984406A23CC2A3931758ECE86B (Texture2D_tBBF96AC337723E2EF156DF17E09D4379FD05DE1C * p0, ByteU5BU5D_tD06FDBE8142446525DF1C40351D523A228373821* p1, const RuntimeMethod* method);
// System.Void unitycoder_MobilePaint_samples.LoadTextureFromWeb/<Start>d__2::.ctor(System.Int32)
extern "C" IL2CPP_METHOD_ATTR void U3CStartU3Ed__2__ctor_m4C7368BC8363DB4492742CA6276F09D9099144E7 (U3CStartU3Ed__2_tEC4FB974F881789E25ED33C9CC1420A5662BF176 * __this, int32_t ___U3CU3E1__state0, const RuntimeMethod* method);
// System.Void System.Object::.ctor()
extern "C" IL2CPP_METHOD_ATTR void Object__ctor_m925ECA5E85CA100E3FB86A4F9E15C120E9A184C0 (RuntimeObject * __this, const RuntimeMethod* method);
// System.Void UnityEngine.WWW::.ctor(System.String)
extern "C" IL2CPP_METHOD_ATTR void WWW__ctor_m855BBB40089401B7BE6DE7A19FAD81EB070A2196 (WWW_tA50AFB5DE276783409B4CE88FE9B772322EE5664 * __this, String_t* p0, const RuntimeMethod* method);
// System.String UnityEngine.WWW::get_error()
extern "C" IL2CPP_METHOD_ATTR String_t* WWW_get_error_mED42EEAAE7847167CCEEFF2098563F78A79F8C2A (WWW_tA50AFB5DE276783409B4CE88FE9B772322EE5664 * __this, const RuntimeMethod* method);
// System.Boolean System.String::IsNullOrEmpty(System.String)
extern "C" IL2CPP_METHOD_ATTR bool String_IsNullOrEmpty_m06A85A206AC2106D1982826C5665B9BD35324229 (String_t* p0, const RuntimeMethod* method);
// UnityEngine.Texture2D UnityEngine.WWW::get_texture()
extern "C" IL2CPP_METHOD_ATTR Texture2D_tBBF96AC337723E2EF156DF17E09D4379FD05DE1C * WWW_get_texture_mD513AF1C1A59301515DFBC972E4530B886842C01 (WWW_tA50AFB5DE276783409B4CE88FE9B772322EE5664 * __this, const RuntimeMethod* method);
// System.Void System.NotSupportedException::.ctor()
extern "C" IL2CPP_METHOD_ATTR void NotSupportedException__ctor_mA121DE1CAC8F25277DEB489DC7771209D91CAE33 (NotSupportedException_tE75B318D6590A02A5D9B29FD97409B1750FA0010 * __this, const RuntimeMethod* method);
// System.Single UnityEngine.Time::get_deltaTime()
extern "C" IL2CPP_METHOD_ATTR float Time_get_deltaTime_m16F98FC9BA931581236008C288E3B25CBCB7C81E (const RuntimeMethod* method);
// System.Void UnityEngine.Transform::Rotate(System.Single,System.Single,System.Single)
extern "C" IL2CPP_METHOD_ATTR void Transform_Rotate_mEEA80F3DA5A4C93611D7165DF54763E578477EF9 (Transform_tBB9E78A2766C3C83599A8F66EDE7D1FCAFC66EDA * __this, float p0, float p1, float p2, const RuntimeMethod* method);
// System.Single UnityEngine.Random::get_value()
extern "C" IL2CPP_METHOD_ATTR float Random_get_value_mC998749E08291DD42CF31C026FAC4F14F746831C (const RuntimeMethod* method);
// UnityEngine.Color32 UnityEngine.Color32::op_Implicit(UnityEngine.Color)
extern "C" IL2CPP_METHOD_ATTR Color32_t23ABC4AE0E0BDFD2E22EE1FA0DA3904FFE5F6E23  Color32_op_Implicit_m52B034473369A651C8952BD916A2AB193E0E5B30 (Color_t119BCA590009762C7223FDD3AF9706653AC84ED2  p0, const RuntimeMethod* method);
// System.Void unitycoder_MobilePaint.MobilePaint::SetBrushSize(System.Int32)
extern "C" IL2CPP_METHOD_ATTR void MobilePaint_SetBrushSize_mC98FEF3E8DFC88C63B9E5E41C3A69E861D48148E (MobilePaint_tC25928758E48181B341DE30F410E3EA407D005E5 * __this, int32_t ___newSize0, const RuntimeMethod* method);
// System.Int32 UnityEngine.Screen::get_width()
extern "C" IL2CPP_METHOD_ATTR int32_t Screen_get_width_m8ECCEF7FF17395D1237BC0193D7A6640A3FEEAD3 (const RuntimeMethod* method);
// System.Void unitycoder_MobilePaint.MobilePaint::DrawCircle(System.Int32,System.Int32)
extern "C" IL2CPP_METHOD_ATTR void MobilePaint_DrawCircle_m4169D0E1FCA5762D225B8C993C2F1C0B0BF47194 (MobilePaint_tC25928758E48181B341DE30F410E3EA407D005E5 * __this, int32_t ___x0, int32_t ___y1, const RuntimeMethod* method);
// System.Void unitycoder_MobilePaint.MobilePaint::DrawLine(System.Int32,System.Int32,System.Int32,System.Int32)
extern "C" IL2CPP_METHOD_ATTR void MobilePaint_DrawLine_mE2DA9F1350E45B98898D478E4DE962C519D7FE0D (MobilePaint_tC25928758E48181B341DE30F410E3EA407D005E5 * __this, int32_t ___startX0, int32_t ___startY1, int32_t ___endX2, int32_t ___endY3, const RuntimeMethod* method);
// System.Collections.IEnumerator unitycoder_MobilePaint_samples.SaveImageToFile::TakeScreenShot()
extern "C" IL2CPP_METHOD_ATTR RuntimeObject* SaveImageToFile_TakeScreenShot_mF31594A7E22C2A2E632345CEC685BDEA695A3C37 (SaveImageToFile_tA64B2DAC4D2AF5B3E183119D7B8EB1C53770B018 * __this, const RuntimeMethod* method);
// UnityEngine.Coroutine UnityEngine.MonoBehaviour::StartCoroutine(System.Collections.IEnumerator)
extern "C" IL2CPP_METHOD_ATTR Coroutine_tAE7DB2FC70A0AE6477F896F852057CB0754F06EC * MonoBehaviour_StartCoroutine_mBF8044CE06A35D76A69669ADD8977D05956616B7 (MonoBehaviour_t4A60845CF505405AF8BE8C61CC07F75CADEF6429 * __this, RuntimeObject* p0, const RuntimeMethod* method);
// System.Void unitycoder_MobilePaint_samples.SaveImageToFile/<TakeScreenShot>d__4::.ctor(System.Int32)
extern "C" IL2CPP_METHOD_ATTR void U3CTakeScreenShotU3Ed__4__ctor_m9D517A82491B73CEF4B25AC3332891309EA6E820 (U3CTakeScreenShotU3Ed__4_t64EC1BB46F6C5F44D6231D42AF034F669E966DE7 * __this, int32_t ___U3CU3E1__state0, const RuntimeMethod* method);
// System.Void UnityEngine.WaitForEndOfFrame::.ctor()
extern "C" IL2CPP_METHOD_ATTR void WaitForEndOfFrame__ctor_m6CDB79476A4A84CEC62947D36ADED96E907BA20B (WaitForEndOfFrame_t75980FB3F246D6AD36A85CA2BFDF8474E5EEBCCA * __this, const RuntimeMethod* method);
// UnityEngine.Texture2D unitycoder_MobilePaint.MobilePaint::GetCanvasAsTexture()
extern "C" IL2CPP_METHOD_ATTR Texture2D_tBBF96AC337723E2EF156DF17E09D4379FD05DE1C * MobilePaint_GetCanvasAsTexture_m8A82C502673621890AC334E9590868DF74C0D15D (MobilePaint_tC25928758E48181B341DE30F410E3EA407D005E5 * __this, const RuntimeMethod* method);
// System.Byte[] UnityEngine.ImageConversion::EncodeToPNG(UnityEngine.Texture2D)
extern "C" IL2CPP_METHOD_ATTR ByteU5BU5D_tD06FDBE8142446525DF1C40351D523A228373821* ImageConversion_EncodeToPNG_m8D67A36A7D81F436CDA108CC5293E15A9CFD5617 (Texture2D_tBBF96AC337723E2EF156DF17E09D4379FD05DE1C * p0, const RuntimeMethod* method);
// System.Boolean System.IO.Directory::Exists(System.String)
extern "C" IL2CPP_METHOD_ATTR bool Directory_Exists_mB77956D89305E16FEFCBDFC55CCC98F03AEE4D84 (String_t* p0, const RuntimeMethod* method);
// System.IO.DirectoryInfo System.IO.Directory::CreateDirectory(System.String)
extern "C" IL2CPP_METHOD_ATTR DirectoryInfo_t432CD06DF148701E930708371CB985BC0E8EF87F * Directory_CreateDirectory_m0C9CAA2ECA801C4D07EA35820DA0907402ED4D41 (String_t* p0, const RuntimeMethod* method);
// System.Void System.IO.File::WriteAllBytes(System.String,System.Byte[])
extern "C" IL2CPP_METHOD_ATTR void File_WriteAllBytes_m07F13C1CA0BD0960392C78AB99E0F19564F9B594 (String_t* p0, ByteU5BU5D_tD06FDBE8142446525DF1C40351D523A228373821* p1, const RuntimeMethod* method);
// !!0 UnityEngine.Component::GetComponent<UnityEngine.Renderer>()
inline Renderer_t0556D67DD582620D1F495627EDE30D03284151F4 * Component_GetComponent_TisRenderer_t0556D67DD582620D1F495627EDE30D03284151F4_m3E0C8F08ADF98436AEF5AE9F4C56A51FF7D0A892 (Component_t05064EF382ABCAF4B8C94F8A350EA85184C26621 * __this, const RuntimeMethod* method)
{
	return ((  Renderer_t0556D67DD582620D1F495627EDE30D03284151F4 * (*) (Component_t05064EF382ABCAF4B8C94F8A350EA85184C26621 *, const RuntimeMethod*))Component_GetComponent_TisRuntimeObject_m3FED1FF44F93EF1C3A07526800331B638EF4105B_gshared)(__this, method);
}
// System.Void UnityEngine.Renderer::set_sortingOrder(System.Int32)
extern "C" IL2CPP_METHOD_ATTR void Renderer_set_sortingOrder_mBCE1207CDB46CB6BA4583B9C3FB4A2D28DC27D81 (Renderer_t0556D67DD582620D1F495627EDE30D03284151F4 * __this, int32_t p0, const RuntimeMethod* method);
// System.Void UnityEngine.Renderer::set_sortingLayerName(System.String)
extern "C" IL2CPP_METHOD_ATTR void Renderer_set_sortingLayerName_m8DCB7B753F22739F79E065922F6201E8EDD08E8F (Renderer_t0556D67DD582620D1F495627EDE30D03284151F4 * __this, String_t* p0, const RuntimeMethod* method);
// System.Int32 UnityEngine.Mesh::get_vertexCount()
extern "C" IL2CPP_METHOD_ATTR int32_t Mesh_get_vertexCount_mE6F1153EA724F831AD11F10807ABE664CC02E0AF (Mesh_t6106B8D8E4C691321581AB0445552EC78B947B8C * __this, const RuntimeMethod* method);
// UnityEngine.Vector3[] UnityEngine.Mesh::get_vertices()
extern "C" IL2CPP_METHOD_ATTR Vector3U5BU5D_tB9EC3346CC4A0EA5447D968E84A9AC1F6F372C28* Mesh_get_vertices_m7D07DC0F071C142B87F675B148FC0F7A243238B9 (Mesh_t6106B8D8E4C691321581AB0445552EC78B947B8C * __this, const RuntimeMethod* method);
// UnityEngine.Vector3[] UnityEngine.Mesh::get_normals()
extern "C" IL2CPP_METHOD_ATTR Vector3U5BU5D_tB9EC3346CC4A0EA5447D968E84A9AC1F6F372C28* Mesh_get_normals_m3CE4668899836CBD17C3F85EB24261CBCEB3EABB (Mesh_t6106B8D8E4C691321581AB0445552EC78B947B8C * __this, const RuntimeMethod* method);
// UnityEngine.Vector2[] UnityEngine.Mesh::get_uv()
extern "C" IL2CPP_METHOD_ATTR Vector2U5BU5D_tA065A07DFC060C1B8786BBAA5F3A6577CCEB27D6* Mesh_get_uv_m0EBA5CA4644C9D5F1B2125AF3FE3873EFC8A4616 (Mesh_t6106B8D8E4C691321581AB0445552EC78B947B8C * __this, const RuntimeMethod* method);
// System.Int32[] UnityEngine.Mesh::get_triangles()
extern "C" IL2CPP_METHOD_ATTR Int32U5BU5D_t2B9E4FDDDB9F0A00EC0AC631BA2DA915EB1ECF83* Mesh_get_triangles_mAAAFC770B8EE3F56992D5764EF8C2EC06EF743AC (Mesh_t6106B8D8E4C691321581AB0445552EC78B947B8C * __this, const RuntimeMethod* method);
// System.Void UnityEngine.Vector3::.ctor(System.Single,System.Single,System.Single)
extern "C" IL2CPP_METHOD_ATTR void Vector3__ctor_m08F61F548AA5836D8789843ACB4A81E4963D2EE1 (Vector3_tDCF05E21F632FE2BA260C06E0D10CA81513E6720 * __this, float p0, float p1, float p2, const RuntimeMethod* method);
// UnityEngine.Vector3 UnityEngine.Vector3::op_Addition(UnityEngine.Vector3,UnityEngine.Vector3)
extern "C" IL2CPP_METHOD_ATTR Vector3_tDCF05E21F632FE2BA260C06E0D10CA81513E6720  Vector3_op_Addition_m929F9C17E5D11B94D50B4AFF1D730B70CB59B50E (Vector3_tDCF05E21F632FE2BA260C06E0D10CA81513E6720  p0, Vector3_tDCF05E21F632FE2BA260C06E0D10CA81513E6720  p1, const RuntimeMethod* method);
// System.Void UnityEngine.Vector3::OrthoNormalize(UnityEngine.Vector3&,UnityEngine.Vector3&)
extern "C" IL2CPP_METHOD_ATTR void Vector3_OrthoNormalize_mDC6E386DEE6B035A0D0CC5A76E427F1ED3899A3E (Vector3_tDCF05E21F632FE2BA260C06E0D10CA81513E6720 * p0, Vector3_tDCF05E21F632FE2BA260C06E0D10CA81513E6720 * p1, const RuntimeMethod* method);
// UnityEngine.Vector3 UnityEngine.Vector3::Cross(UnityEngine.Vector3,UnityEngine.Vector3)
extern "C" IL2CPP_METHOD_ATTR Vector3_tDCF05E21F632FE2BA260C06E0D10CA81513E6720  Vector3_Cross_m3E9DBC445228FDB850BDBB4B01D6F61AC0111887 (Vector3_tDCF05E21F632FE2BA260C06E0D10CA81513E6720  p0, Vector3_tDCF05E21F632FE2BA260C06E0D10CA81513E6720  p1, const RuntimeMethod* method);
// System.Single UnityEngine.Vector3::Dot(UnityEngine.Vector3,UnityEngine.Vector3)
extern "C" IL2CPP_METHOD_ATTR float Vector3_Dot_m0C530E1C51278DE28B77906D56356506232272C1 (Vector3_tDCF05E21F632FE2BA260C06E0D10CA81513E6720  p0, Vector3_tDCF05E21F632FE2BA260C06E0D10CA81513E6720  p1, const RuntimeMethod* method);
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif
extern "C"  void DelegatePInvokeWrapper_AreaWasPainted_t537D2557735149202851C1AF691D54AA43D52E57 (AreaWasPainted_t537D2557735149202851C1AF691D54AA43D52E57 * __this, int32_t ___fullArea0, int32_t ___filledArea1, float ___percentageFilled2, Vector3_tDCF05E21F632FE2BA260C06E0D10CA81513E6720  ___point3, const RuntimeMethod* method)
{
	typedef void (DEFAULT_CALL *PInvokeFunc)(int32_t, int32_t, float, Vector3_tDCF05E21F632FE2BA260C06E0D10CA81513E6720 );
	PInvokeFunc il2cppPInvokeFunc = reinterpret_cast<PInvokeFunc>(il2cpp_codegen_get_method_pointer(((RuntimeDelegate*)__this)->method));

	// Native function invocation
	il2cppPInvokeFunc(___fullArea0, ___filledArea1, ___percentageFilled2, ___point3);

}
// System.Void unitycoder_MobilePaint.MobilePaint/AreaWasPainted::.ctor(System.Object,System.IntPtr)
extern "C" IL2CPP_METHOD_ATTR void AreaWasPainted__ctor_m6367CE1441D6976E16A1FE100DCBAC96DA1B8C29 (AreaWasPainted_t537D2557735149202851C1AF691D54AA43D52E57 * __this, RuntimeObject * ___object0, intptr_t ___method1, const RuntimeMethod* method)
{
	__this->set_method_ptr_0(il2cpp_codegen_get_method_pointer((RuntimeMethod*)___method1));
	__this->set_method_3(___method1);
	__this->set_m_target_2(___object0);
}
// System.Void unitycoder_MobilePaint.MobilePaint/AreaWasPainted::Invoke(System.Int32,System.Int32,System.Single,UnityEngine.Vector3)
extern "C" IL2CPP_METHOD_ATTR void AreaWasPainted_Invoke_mF4A0B6774B3D1F0B9E5D79796BEECDA8E9969F51 (AreaWasPainted_t537D2557735149202851C1AF691D54AA43D52E57 * __this, int32_t ___fullArea0, int32_t ___filledArea1, float ___percentageFilled2, Vector3_tDCF05E21F632FE2BA260C06E0D10CA81513E6720  ___point3, const RuntimeMethod* method)
{
	DelegateU5BU5D_tDFCDEE2A6322F96C0FE49AF47E9ADB8C4B294E86* delegatesToInvoke = __this->get_delegates_11();
	if (delegatesToInvoke != NULL)
	{
		il2cpp_array_size_t length = delegatesToInvoke->max_length;
		for (il2cpp_array_size_t i = 0; i < length; i++)
		{
			Delegate_t* currentDelegate = (delegatesToInvoke)->GetAtUnchecked(static_cast<il2cpp_array_size_t>(i));
			Il2CppMethodPointer targetMethodPointer = currentDelegate->get_method_ptr_0();
			RuntimeMethod* targetMethod = (RuntimeMethod*)(currentDelegate->get_method_3());
			RuntimeObject* targetThis = currentDelegate->get_m_target_2();
			if (!il2cpp_codegen_method_is_virtual(targetMethod))
			{
				il2cpp_codegen_raise_execution_engine_exception_if_method_is_not_found(targetMethod);
			}
			bool ___methodIsStatic = MethodIsStatic(targetMethod);
			int ___parameterCount = il2cpp_codegen_method_parameter_count(targetMethod);
			if (___methodIsStatic)
			{
				if (___parameterCount == 4)
				{
					// open
					typedef void (*FunctionPointerType) (int32_t, int32_t, float, Vector3_tDCF05E21F632FE2BA260C06E0D10CA81513E6720 , const RuntimeMethod*);
					((FunctionPointerType)targetMethodPointer)(___fullArea0, ___filledArea1, ___percentageFilled2, ___point3, targetMethod);
				}
				else
				{
					// closed
					typedef void (*FunctionPointerType) (void*, int32_t, int32_t, float, Vector3_tDCF05E21F632FE2BA260C06E0D10CA81513E6720 , const RuntimeMethod*);
					((FunctionPointerType)targetMethodPointer)(targetThis, ___fullArea0, ___filledArea1, ___percentageFilled2, ___point3, targetMethod);
				}
			}
			else
			{
				// closed
				if (il2cpp_codegen_method_is_virtual(targetMethod) && !il2cpp_codegen_object_is_of_sealed_type(targetThis) && il2cpp_codegen_delegate_has_invoker((Il2CppDelegate*)__this))
				{
					if (il2cpp_codegen_method_is_virtual(targetMethod) && !il2cpp_codegen_object_is_of_sealed_type(targetThis) && il2cpp_codegen_delegate_has_invoker((Il2CppDelegate*)__this))
					{
						if (targetThis == NULL)
						{
							typedef void (*FunctionPointerType) (int32_t, int32_t, float, Vector3_tDCF05E21F632FE2BA260C06E0D10CA81513E6720 , const RuntimeMethod*);
							((FunctionPointerType)targetMethodPointer)(___fullArea0, ___filledArea1, ___percentageFilled2, ___point3, targetMethod);
						}
						else if (il2cpp_codegen_method_is_generic_instance(targetMethod))
						{
							if (il2cpp_codegen_method_is_interface_method(targetMethod))
								GenericInterfaceActionInvoker4< int32_t, int32_t, float, Vector3_tDCF05E21F632FE2BA260C06E0D10CA81513E6720  >::Invoke(targetMethod, targetThis, ___fullArea0, ___filledArea1, ___percentageFilled2, ___point3);
							else
								GenericVirtActionInvoker4< int32_t, int32_t, float, Vector3_tDCF05E21F632FE2BA260C06E0D10CA81513E6720  >::Invoke(targetMethod, targetThis, ___fullArea0, ___filledArea1, ___percentageFilled2, ___point3);
						}
						else
						{
							if (il2cpp_codegen_method_is_interface_method(targetMethod))
								InterfaceActionInvoker4< int32_t, int32_t, float, Vector3_tDCF05E21F632FE2BA260C06E0D10CA81513E6720  >::Invoke(il2cpp_codegen_method_get_slot(targetMethod), il2cpp_codegen_method_get_declaring_type(targetMethod), targetThis, ___fullArea0, ___filledArea1, ___percentageFilled2, ___point3);
							else
								VirtActionInvoker4< int32_t, int32_t, float, Vector3_tDCF05E21F632FE2BA260C06E0D10CA81513E6720  >::Invoke(il2cpp_codegen_method_get_slot(targetMethod), targetThis, ___fullArea0, ___filledArea1, ___percentageFilled2, ___point3);
						}
					}
				}
				else
				{
					typedef void (*FunctionPointerType) (void*, int32_t, int32_t, float, Vector3_tDCF05E21F632FE2BA260C06E0D10CA81513E6720 , const RuntimeMethod*);
					((FunctionPointerType)targetMethodPointer)(targetThis, ___fullArea0, ___filledArea1, ___percentageFilled2, ___point3, targetMethod);
				}
			}
		}
	}
	else
	{
		Il2CppMethodPointer targetMethodPointer = __this->get_method_ptr_0();
		RuntimeMethod* targetMethod = (RuntimeMethod*)(__this->get_method_3());
		RuntimeObject* targetThis = __this->get_m_target_2();
		if (!il2cpp_codegen_method_is_virtual(targetMethod))
		{
			il2cpp_codegen_raise_execution_engine_exception_if_method_is_not_found(targetMethod);
		}
		bool ___methodIsStatic = MethodIsStatic(targetMethod);
		int ___parameterCount = il2cpp_codegen_method_parameter_count(targetMethod);
		if (___methodIsStatic)
		{
			if (___parameterCount == 4)
			{
				// open
				typedef void (*FunctionPointerType) (int32_t, int32_t, float, Vector3_tDCF05E21F632FE2BA260C06E0D10CA81513E6720 , const RuntimeMethod*);
				((FunctionPointerType)targetMethodPointer)(___fullArea0, ___filledArea1, ___percentageFilled2, ___point3, targetMethod);
			}
			else
			{
				// closed
				typedef void (*FunctionPointerType) (void*, int32_t, int32_t, float, Vector3_tDCF05E21F632FE2BA260C06E0D10CA81513E6720 , const RuntimeMethod*);
				((FunctionPointerType)targetMethodPointer)(targetThis, ___fullArea0, ___filledArea1, ___percentageFilled2, ___point3, targetMethod);
			}
		}
		else
		{
			// closed
			if (il2cpp_codegen_method_is_virtual(targetMethod) && !il2cpp_codegen_object_is_of_sealed_type(targetThis) && il2cpp_codegen_delegate_has_invoker((Il2CppDelegate*)__this))
			{
				if (il2cpp_codegen_method_is_virtual(targetMethod) && !il2cpp_codegen_object_is_of_sealed_type(targetThis) && il2cpp_codegen_delegate_has_invoker((Il2CppDelegate*)__this))
				{
					if (targetThis == NULL)
					{
						typedef void (*FunctionPointerType) (int32_t, int32_t, float, Vector3_tDCF05E21F632FE2BA260C06E0D10CA81513E6720 , const RuntimeMethod*);
						((FunctionPointerType)targetMethodPointer)(___fullArea0, ___filledArea1, ___percentageFilled2, ___point3, targetMethod);
					}
					else if (il2cpp_codegen_method_is_generic_instance(targetMethod))
					{
						if (il2cpp_codegen_method_is_interface_method(targetMethod))
							GenericInterfaceActionInvoker4< int32_t, int32_t, float, Vector3_tDCF05E21F632FE2BA260C06E0D10CA81513E6720  >::Invoke(targetMethod, targetThis, ___fullArea0, ___filledArea1, ___percentageFilled2, ___point3);
						else
							GenericVirtActionInvoker4< int32_t, int32_t, float, Vector3_tDCF05E21F632FE2BA260C06E0D10CA81513E6720  >::Invoke(targetMethod, targetThis, ___fullArea0, ___filledArea1, ___percentageFilled2, ___point3);
					}
					else
					{
						if (il2cpp_codegen_method_is_interface_method(targetMethod))
							InterfaceActionInvoker4< int32_t, int32_t, float, Vector3_tDCF05E21F632FE2BA260C06E0D10CA81513E6720  >::Invoke(il2cpp_codegen_method_get_slot(targetMethod), il2cpp_codegen_method_get_declaring_type(targetMethod), targetThis, ___fullArea0, ___filledArea1, ___percentageFilled2, ___point3);
						else
							VirtActionInvoker4< int32_t, int32_t, float, Vector3_tDCF05E21F632FE2BA260C06E0D10CA81513E6720  >::Invoke(il2cpp_codegen_method_get_slot(targetMethod), targetThis, ___fullArea0, ___filledArea1, ___percentageFilled2, ___point3);
					}
				}
			}
			else
			{
				typedef void (*FunctionPointerType) (void*, int32_t, int32_t, float, Vector3_tDCF05E21F632FE2BA260C06E0D10CA81513E6720 , const RuntimeMethod*);
				((FunctionPointerType)targetMethodPointer)(targetThis, ___fullArea0, ___filledArea1, ___percentageFilled2, ___point3, targetMethod);
			}
		}
	}
}
// System.IAsyncResult unitycoder_MobilePaint.MobilePaint/AreaWasPainted::BeginInvoke(System.Int32,System.Int32,System.Single,UnityEngine.Vector3,System.AsyncCallback,System.Object)
extern "C" IL2CPP_METHOD_ATTR RuntimeObject* AreaWasPainted_BeginInvoke_mA2B880190BEE6835AE27468ED77E7499F241A1E3 (AreaWasPainted_t537D2557735149202851C1AF691D54AA43D52E57 * __this, int32_t ___fullArea0, int32_t ___filledArea1, float ___percentageFilled2, Vector3_tDCF05E21F632FE2BA260C06E0D10CA81513E6720  ___point3, AsyncCallback_t3F3DA3BEDAEE81DD1D24125DF8EB30E85EE14DA4 * ___callback4, RuntimeObject * ___object5, const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_method (AreaWasPainted_BeginInvoke_mA2B880190BEE6835AE27468ED77E7499F241A1E3_MetadataUsageId);
		s_Il2CppMethodInitialized = true;
	}
	void *__d_args[5] = {0};
	__d_args[0] = Box(Int32_t585191389E07734F19F3156FF88FB3EF4800D102_il2cpp_TypeInfo_var, &___fullArea0);
	__d_args[1] = Box(Int32_t585191389E07734F19F3156FF88FB3EF4800D102_il2cpp_TypeInfo_var, &___filledArea1);
	__d_args[2] = Box(Single_tDDDA9169C4E4E308AC6D7A824F9B28DC82204AE1_il2cpp_TypeInfo_var, &___percentageFilled2);
	__d_args[3] = Box(Vector3_tDCF05E21F632FE2BA260C06E0D10CA81513E6720_il2cpp_TypeInfo_var, &___point3);
	return (RuntimeObject*)il2cpp_codegen_delegate_begin_invoke((RuntimeDelegate*)__this, __d_args, (RuntimeDelegate*)___callback4, (RuntimeObject*)___object5);
}
// System.Void unitycoder_MobilePaint.MobilePaint/AreaWasPainted::EndInvoke(System.IAsyncResult)
extern "C" IL2CPP_METHOD_ATTR void AreaWasPainted_EndInvoke_m21EE043FB4DC4BA51485CD42106E8B008300182A (AreaWasPainted_t537D2557735149202851C1AF691D54AA43D52E57 * __this, RuntimeObject* ___result0, const RuntimeMethod* method)
{
	il2cpp_codegen_delegate_end_invoke((Il2CppAsyncResult*) ___result0, 0);
}
#ifdef __clang__
#pragma clang diagnostic pop
#endif
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif
// System.Void unitycoder_MobilePaint.OverrideTestForUI::HideUI()
extern "C" IL2CPP_METHOD_ATTR void OverrideTestForUI_HideUI_m4ED010136011E0659730150E484E1BFAAB7F2285 (OverrideTestForUI_tBE0191B652C971AB79ED3E133FEF14489D422394 * __this, const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_method (OverrideTestForUI_HideUI_m4ED010136011E0659730150E484E1BFAAB7F2285_MetadataUsageId);
		s_Il2CppMethodInitialized = true;
	}
	{
		IL2CPP_RUNTIME_CLASS_INIT(Debug_t7B5FCB117E2FD63B6838BC52821B252E2BFB61C4_il2cpp_TypeInfo_var);
		Debug_Log_m4B7C70BAFD477C6BDB59C88A0934F0B018D03708(_stringLiteral48B34F43F564D41B959300B7677B4FFA92E6DF9A, /*hidden argument*/NULL);
		return;
	}
}
// System.Void unitycoder_MobilePaint.OverrideTestForUI::ShowUI()
extern "C" IL2CPP_METHOD_ATTR void OverrideTestForUI_ShowUI_mE1C8705850FFE69AB7B1F4C0E3FC2F9AB99E2F25 (OverrideTestForUI_tBE0191B652C971AB79ED3E133FEF14489D422394 * __this, const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_method (OverrideTestForUI_ShowUI_mE1C8705850FFE69AB7B1F4C0E3FC2F9AB99E2F25_MetadataUsageId);
		s_Il2CppMethodInitialized = true;
	}
	{
		IL2CPP_RUNTIME_CLASS_INIT(Debug_t7B5FCB117E2FD63B6838BC52821B252E2BFB61C4_il2cpp_TypeInfo_var);
		Debug_Log_m4B7C70BAFD477C6BDB59C88A0934F0B018D03708(_stringLiteralEDE796F19952CB1FC543E86FFB96733DFA0E0870, /*hidden argument*/NULL);
		return;
	}
}
// System.Void unitycoder_MobilePaint.OverrideTestForUI::.ctor()
extern "C" IL2CPP_METHOD_ATTR void OverrideTestForUI__ctor_m08820A0BFA2FFAE74F0CA3A966E1E7409C45E6C3 (OverrideTestForUI_tBE0191B652C971AB79ED3E133FEF14489D422394 * __this, const RuntimeMethod* method)
{
	{
		MobilePaint__ctor_mDDC635FD438A7A429D15304566C8B852DA8023C7(__this, /*hidden argument*/NULL);
		return;
	}
}
#ifdef __clang__
#pragma clang diagnostic pop
#endif
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif
// System.Void unitycoder_MobilePaint.PaintManager::Awake()
extern "C" IL2CPP_METHOD_ATTR void PaintManager_Awake_mB6E861990500DDA4510DAC23C2AFCB3E2C156AA9 (PaintManager_t8C7F3BD113E1D28F982A05D0397A369E09266BEE * __this, const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_method (PaintManager_Awake_mB6E861990500DDA4510DAC23C2AFCB3E2C156AA9_MetadataUsageId);
		s_Il2CppMethodInitialized = true;
	}
	{
		MobilePaint_tC25928758E48181B341DE30F410E3EA407D005E5 * L_0 = __this->get_mobilePaintReference_4();
		IL2CPP_RUNTIME_CLASS_INIT(Object_tAE11E5E46CD5C37C9F3E8950C00CD8B45666A2D0_il2cpp_TypeInfo_var);
		bool L_1 = Object_op_Equality_mBC2401774F3BE33E8CF6F0A8148E66C95D6CFF1C(L_0, (Object_tAE11E5E46CD5C37C9F3E8950C00CD8B45666A2D0 *)NULL, /*hidden argument*/NULL);
		if (!L_1)
		{
			goto IL_002e;
		}
	}
	{
		Transform_tBB9E78A2766C3C83599A8F66EDE7D1FCAFC66EDA * L_2 = Component_get_transform_m00F05BD782F920C301A7EBA480F3B7A904C07EC9(__this, /*hidden argument*/NULL);
		NullCheck(L_2);
		String_t* L_3 = Object_get_name_mA2D400141CB3C991C87A2556429781DE961A83CE(L_2, /*hidden argument*/NULL);
		String_t* L_4 = String_Concat_mB78D0094592718DA6D5DB6C712A9C225631666BE(_stringLiteral18D7B45DCCC374DAC64758C817E1917534D16F3F, L_3, /*hidden argument*/NULL);
		GameObject_tBD1244AD56B4E59AAD76E5E7C9282EC5CE434F0F * L_5 = Component_get_gameObject_m0B0570BA8DDD3CD78A9DB568EA18D7317686603C(__this, /*hidden argument*/NULL);
		IL2CPP_RUNTIME_CLASS_INIT(Debug_t7B5FCB117E2FD63B6838BC52821B252E2BFB61C4_il2cpp_TypeInfo_var);
		Debug_LogError_m97139CB2EE76D5CD8308C1AD0499A5F163FC7F51(L_4, L_5, /*hidden argument*/NULL);
	}

IL_002e:
	{
		MobilePaint_tC25928758E48181B341DE30F410E3EA407D005E5 * L_6 = __this->get_mobilePaintReference_4();
		((PaintManager_t8C7F3BD113E1D28F982A05D0397A369E09266BEE_StaticFields*)il2cpp_codegen_static_fields_for(PaintManager_t8C7F3BD113E1D28F982A05D0397A369E09266BEE_il2cpp_TypeInfo_var))->set_mobilePaint_5(L_6);
		return;
	}
}
// System.Void unitycoder_MobilePaint.PaintManager::.ctor()
extern "C" IL2CPP_METHOD_ATTR void PaintManager__ctor_m43C50426E359B526960E942042530A87ADF7BAD4 (PaintManager_t8C7F3BD113E1D28F982A05D0397A369E09266BEE * __this, const RuntimeMethod* method)
{
	{
		MonoBehaviour__ctor_mEAEC84B222C60319D593E456D769B3311DFCEF97(__this, /*hidden argument*/NULL);
		return;
	}
}
#ifdef __clang__
#pragma clang diagnostic pop
#endif
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif
// System.Int32 unitycoder_MobilePaint.PaintTools::ClampBrushInt(System.Int32,System.Int32,System.Int32)
extern "C" IL2CPP_METHOD_ATTR int32_t PaintTools_ClampBrushInt_mB82547EBDE6713A89780EEAA238AEA72D08FB562 (int32_t ___value0, int32_t ___brushSize1, int32_t ___max2, const RuntimeMethod* method)
{
	{
		int32_t L_0 = ___value0;
		int32_t L_1 = ___brushSize1;
		if ((((int32_t)L_0) < ((int32_t)L_1)))
		{
			goto IL_000c;
		}
	}
	{
		int32_t L_2 = ___value0;
		int32_t L_3 = ___max2;
		if ((((int32_t)L_2) > ((int32_t)L_3)))
		{
			goto IL_000a;
		}
	}
	{
		int32_t L_4 = ___value0;
		return L_4;
	}

IL_000a:
	{
		int32_t L_5 = ___max2;
		return L_5;
	}

IL_000c:
	{
		int32_t L_6 = ___brushSize1;
		return L_6;
	}
}
// System.Byte unitycoder_MobilePaint.PaintTools::LerpByte(System.Byte,System.Int32,System.Int32)
extern "C" IL2CPP_METHOD_ATTR uint8_t PaintTools_LerpByte_mDF9034A14A475010A1A4FB9BB2CBED8DE9AE8BF4 (uint8_t ___from0, int32_t ___to1, int32_t ___value2, const RuntimeMethod* method)
{
	{
		uint8_t L_0 = ___from0;
		int32_t L_1 = ___to1;
		if ((((int32_t)L_0) >= ((int32_t)L_1)))
		{
			goto IL_001d;
		}
	}
	{
		int32_t L_2 = ___value2;
		uint8_t L_3 = ___from0;
		if ((((int32_t)L_2) >= ((int32_t)L_3)))
		{
			goto IL_000a;
		}
	}
	{
		return (uint8_t)0;
	}

IL_000a:
	{
		int32_t L_4 = ___value2;
		int32_t L_5 = ___to1;
		if ((((int32_t)L_4) <= ((int32_t)L_5)))
		{
			goto IL_0014;
		}
	}
	{
		return (uint8_t)((int32_t)255);
	}

IL_0014:
	{
		int32_t L_6 = ___value2;
		uint8_t L_7 = ___from0;
		int32_t L_8 = ___to1;
		uint8_t L_9 = ___from0;
		return (uint8_t)(((int32_t)((uint8_t)((int32_t)((int32_t)((int32_t)il2cpp_codegen_subtract((int32_t)L_6, (int32_t)L_7))/(int32_t)((int32_t)il2cpp_codegen_subtract((int32_t)L_8, (int32_t)L_9)))))));
	}

IL_001d:
	{
		uint8_t L_10 = ___from0;
		int32_t L_11 = ___to1;
		if ((((int32_t)L_10) > ((int32_t)L_11)))
		{
			goto IL_0023;
		}
	}
	{
		return (uint8_t)0;
	}

IL_0023:
	{
		int32_t L_12 = ___value2;
		int32_t L_13 = ___to1;
		if ((((int32_t)L_12) >= ((int32_t)L_13)))
		{
			goto IL_002d;
		}
	}
	{
		return (uint8_t)((int32_t)255);
	}

IL_002d:
	{
		int32_t L_14 = ___value2;
		uint8_t L_15 = ___from0;
		if ((((int32_t)L_14) <= ((int32_t)L_15)))
		{
			goto IL_0033;
		}
	}
	{
		return (uint8_t)0;
	}

IL_0033:
	{
		int32_t L_16 = ___value2;
		int32_t L_17 = ___to1;
		uint8_t L_18 = ___from0;
		int32_t L_19 = ___to1;
		return (uint8_t)(((int32_t)((uint8_t)((int32_t)il2cpp_codegen_subtract((int32_t)((int32_t)255), (int32_t)((int32_t)((int32_t)((int32_t)il2cpp_codegen_subtract((int32_t)L_16, (int32_t)L_17))/(int32_t)((int32_t)il2cpp_codegen_subtract((int32_t)L_18, (int32_t)L_19)))))))));
	}
}
#ifdef __clang__
#pragma clang diagnostic pop
#endif
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif
// System.Void unitycoder_MobilePaint.SetNewCanvasImageExample::Start()
extern "C" IL2CPP_METHOD_ATTR void SetNewCanvasImageExample_Start_m84D721AC0E9B59996543CB42A8FBC0C4D349A7D8 (SetNewCanvasImageExample_tABE5A79B521E9F4F1676A55FC042C693FB2647D7 * __this, const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_method (SetNewCanvasImageExample_Start_m84D721AC0E9B59996543CB42A8FBC0C4D349A7D8_MetadataUsageId);
		s_Il2CppMethodInitialized = true;
	}
	{
		MobilePaint_tC25928758E48181B341DE30F410E3EA407D005E5 * L_0 = ((PaintManager_t8C7F3BD113E1D28F982A05D0397A369E09266BEE_StaticFields*)il2cpp_codegen_static_fields_for(PaintManager_t8C7F3BD113E1D28F982A05D0397A369E09266BEE_il2cpp_TypeInfo_var))->get_mobilePaint_5();
		__this->set_mobilePaint_4(L_0);
		MobilePaint_tC25928758E48181B341DE30F410E3EA407D005E5 * L_1 = __this->get_mobilePaint_4();
		IL2CPP_RUNTIME_CLASS_INIT(Object_tAE11E5E46CD5C37C9F3E8950C00CD8B45666A2D0_il2cpp_TypeInfo_var);
		bool L_2 = Object_op_Equality_mBC2401774F3BE33E8CF6F0A8148E66C95D6CFF1C(L_1, (Object_tAE11E5E46CD5C37C9F3E8950C00CD8B45666A2D0 *)NULL, /*hidden argument*/NULL);
		if (!L_2)
		{
			goto IL_0029;
		}
	}
	{
		GameObject_tBD1244AD56B4E59AAD76E5E7C9282EC5CE434F0F * L_3 = Component_get_gameObject_m0B0570BA8DDD3CD78A9DB568EA18D7317686603C(__this, /*hidden argument*/NULL);
		IL2CPP_RUNTIME_CLASS_INIT(Debug_t7B5FCB117E2FD63B6838BC52821B252E2BFB61C4_il2cpp_TypeInfo_var);
		Debug_LogError_m97139CB2EE76D5CD8308C1AD0499A5F163FC7F51(_stringLiteralCC679B8F680542478E3C9C80547777A0EED3B432, L_3, /*hidden argument*/NULL);
	}

IL_0029:
	{
		Texture2DU5BU5D_tCAC03055C735C020BAFC218D55183CF03E74C1C9* L_4 = __this->get_images_5();
		if (!L_4)
		{
			goto IL_003c;
		}
	}
	{
		Texture2DU5BU5D_tCAC03055C735C020BAFC218D55183CF03E74C1C9* L_5 = __this->get_images_5();
		NullCheck(L_5);
		if ((((int32_t)(((int32_t)((int32_t)(((RuntimeArray *)L_5)->max_length))))) >= ((int32_t)1)))
		{
			goto IL_004c;
		}
	}

IL_003c:
	{
		GameObject_tBD1244AD56B4E59AAD76E5E7C9282EC5CE434F0F * L_6 = Component_get_gameObject_m0B0570BA8DDD3CD78A9DB568EA18D7317686603C(__this, /*hidden argument*/NULL);
		IL2CPP_RUNTIME_CLASS_INIT(Debug_t7B5FCB117E2FD63B6838BC52821B252E2BFB61C4_il2cpp_TypeInfo_var);
		Debug_LogError_m97139CB2EE76D5CD8308C1AD0499A5F163FC7F51(_stringLiteral771F138D9C7A926E5BE4BA01840663EE8D31F54E, L_6, /*hidden argument*/NULL);
	}

IL_004c:
	{
		return;
	}
}
// System.Void unitycoder_MobilePaint.SetNewCanvasImageExample::NextImage()
extern "C" IL2CPP_METHOD_ATTR void SetNewCanvasImageExample_NextImage_mC1FFEC0B6A7A66DB363140E5E45C3078273CF583 (SetNewCanvasImageExample_tABE5A79B521E9F4F1676A55FC042C693FB2647D7 * __this, const RuntimeMethod* method)
{
	{
		int32_t L_0 = __this->get_index_6();
		Texture2DU5BU5D_tCAC03055C735C020BAFC218D55183CF03E74C1C9* L_1 = __this->get_images_5();
		NullCheck(L_1);
		__this->set_index_6(((int32_t)((int32_t)((int32_t)il2cpp_codegen_add((int32_t)L_0, (int32_t)1))%(int32_t)(((int32_t)((int32_t)(((RuntimeArray *)L_1)->max_length)))))));
		MobilePaint_tC25928758E48181B341DE30F410E3EA407D005E5 * L_2 = __this->get_mobilePaint_4();
		Texture2DU5BU5D_tCAC03055C735C020BAFC218D55183CF03E74C1C9* L_3 = __this->get_images_5();
		int32_t L_4 = __this->get_index_6();
		NullCheck(L_3);
		int32_t L_5 = L_4;
		Texture2D_tBBF96AC337723E2EF156DF17E09D4379FD05DE1C * L_6 = (L_3)->GetAt(static_cast<il2cpp_array_size_t>(L_5));
		NullCheck(L_2);
		MobilePaint_SetCanvasImage_mD9FB8536EE50E16FC25A827A84DCF2B3A6FB5D9C(L_2, L_6, /*hidden argument*/NULL);
		return;
	}
}
// System.Void unitycoder_MobilePaint.SetNewCanvasImageExample::.ctor()
extern "C" IL2CPP_METHOD_ATTR void SetNewCanvasImageExample__ctor_m509B7C8CB00D96C612E6AA9A518E54A301524737 (SetNewCanvasImageExample_tABE5A79B521E9F4F1676A55FC042C693FB2647D7 * __this, const RuntimeMethod* method)
{
	{
		MonoBehaviour__ctor_mEAEC84B222C60319D593E456D769B3311DFCEF97(__this, /*hidden argument*/NULL);
		return;
	}
}
#ifdef __clang__
#pragma clang diagnostic pop
#endif
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif
// System.Void unitycoder_MobilePaint.SetNewMaskImage::Start()
extern "C" IL2CPP_METHOD_ATTR void SetNewMaskImage_Start_m642F4210B7FFC91BDF37EC01E86EE76D7EE0911B (SetNewMaskImage_t27DC57C9D9F2DC004D6F077B092BC52CE8D0AE8A * __this, const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_method (SetNewMaskImage_Start_m642F4210B7FFC91BDF37EC01E86EE76D7EE0911B_MetadataUsageId);
		s_Il2CppMethodInitialized = true;
	}
	{
		MobilePaint_tC25928758E48181B341DE30F410E3EA407D005E5 * L_0 = ((PaintManager_t8C7F3BD113E1D28F982A05D0397A369E09266BEE_StaticFields*)il2cpp_codegen_static_fields_for(PaintManager_t8C7F3BD113E1D28F982A05D0397A369E09266BEE_il2cpp_TypeInfo_var))->get_mobilePaint_5();
		__this->set_mobilePaint_4(L_0);
		MobilePaint_tC25928758E48181B341DE30F410E3EA407D005E5 * L_1 = __this->get_mobilePaint_4();
		IL2CPP_RUNTIME_CLASS_INIT(Object_tAE11E5E46CD5C37C9F3E8950C00CD8B45666A2D0_il2cpp_TypeInfo_var);
		bool L_2 = Object_op_Equality_mBC2401774F3BE33E8CF6F0A8148E66C95D6CFF1C(L_1, (Object_tAE11E5E46CD5C37C9F3E8950C00CD8B45666A2D0 *)NULL, /*hidden argument*/NULL);
		if (!L_2)
		{
			goto IL_0029;
		}
	}
	{
		GameObject_tBD1244AD56B4E59AAD76E5E7C9282EC5CE434F0F * L_3 = Component_get_gameObject_m0B0570BA8DDD3CD78A9DB568EA18D7317686603C(__this, /*hidden argument*/NULL);
		IL2CPP_RUNTIME_CLASS_INIT(Debug_t7B5FCB117E2FD63B6838BC52821B252E2BFB61C4_il2cpp_TypeInfo_var);
		Debug_LogError_m97139CB2EE76D5CD8308C1AD0499A5F163FC7F51(_stringLiteralCC679B8F680542478E3C9C80547777A0EED3B432, L_3, /*hidden argument*/NULL);
	}

IL_0029:
	{
		Texture2DU5BU5D_tCAC03055C735C020BAFC218D55183CF03E74C1C9* L_4 = __this->get_images_5();
		if (!L_4)
		{
			goto IL_003c;
		}
	}
	{
		Texture2DU5BU5D_tCAC03055C735C020BAFC218D55183CF03E74C1C9* L_5 = __this->get_images_5();
		NullCheck(L_5);
		if ((((int32_t)(((int32_t)((int32_t)(((RuntimeArray *)L_5)->max_length))))) >= ((int32_t)1)))
		{
			goto IL_004c;
		}
	}

IL_003c:
	{
		GameObject_tBD1244AD56B4E59AAD76E5E7C9282EC5CE434F0F * L_6 = Component_get_gameObject_m0B0570BA8DDD3CD78A9DB568EA18D7317686603C(__this, /*hidden argument*/NULL);
		IL2CPP_RUNTIME_CLASS_INIT(Debug_t7B5FCB117E2FD63B6838BC52821B252E2BFB61C4_il2cpp_TypeInfo_var);
		Debug_LogError_m97139CB2EE76D5CD8308C1AD0499A5F163FC7F51(_stringLiteral771F138D9C7A926E5BE4BA01840663EE8D31F54E, L_6, /*hidden argument*/NULL);
	}

IL_004c:
	{
		return;
	}
}
// System.Void unitycoder_MobilePaint.SetNewMaskImage::NextMaskImage()
extern "C" IL2CPP_METHOD_ATTR void SetNewMaskImage_NextMaskImage_mE4D01CD11E38D344EE5544163F948275EAD5C992 (SetNewMaskImage_t27DC57C9D9F2DC004D6F077B092BC52CE8D0AE8A * __this, const RuntimeMethod* method)
{
	{
		int32_t L_0 = __this->get_index_6();
		Texture2DU5BU5D_tCAC03055C735C020BAFC218D55183CF03E74C1C9* L_1 = __this->get_images_5();
		NullCheck(L_1);
		__this->set_index_6(((int32_t)((int32_t)((int32_t)il2cpp_codegen_add((int32_t)L_0, (int32_t)1))%(int32_t)(((int32_t)((int32_t)(((RuntimeArray *)L_1)->max_length)))))));
		MobilePaint_tC25928758E48181B341DE30F410E3EA407D005E5 * L_2 = __this->get_mobilePaint_4();
		Texture2DU5BU5D_tCAC03055C735C020BAFC218D55183CF03E74C1C9* L_3 = __this->get_images_5();
		int32_t L_4 = __this->get_index_6();
		NullCheck(L_3);
		int32_t L_5 = L_4;
		Texture2D_tBBF96AC337723E2EF156DF17E09D4379FD05DE1C * L_6 = (L_3)->GetAt(static_cast<il2cpp_array_size_t>(L_5));
		NullCheck(L_2);
		MobilePaint_SetMaskImage_m80E98353C9F9EF9C4A76658F6734A9375FC329D7(L_2, L_6, /*hidden argument*/NULL);
		return;
	}
}
// System.Void unitycoder_MobilePaint.SetNewMaskImage::.ctor()
extern "C" IL2CPP_METHOD_ATTR void SetNewMaskImage__ctor_m011D5AA84F6FE7034899F42ACA42D4C3526A18D4 (SetNewMaskImage_t27DC57C9D9F2DC004D6F077B092BC52CE8D0AE8A * __this, const RuntimeMethod* method)
{
	{
		MonoBehaviour__ctor_mEAEC84B222C60319D593E456D769B3311DFCEF97(__this, /*hidden argument*/NULL);
		return;
	}
}
#ifdef __clang__
#pragma clang diagnostic pop
#endif
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif
// System.Void unitycoder_MobilePaint.ToggleBrushModeUI::Start()
extern "C" IL2CPP_METHOD_ATTR void ToggleBrushModeUI_Start_mE14D3D6A5D897EEA80C686D2633B9AFAE0663996 (ToggleBrushModeUI_t4B6DF517F8B4743603417CD2EB16093A8DE0758B * __this, const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_method (ToggleBrushModeUI_Start_mE14D3D6A5D897EEA80C686D2633B9AFAE0663996_MetadataUsageId);
		s_Il2CppMethodInitialized = true;
	}
	{
		MobilePaint_tC25928758E48181B341DE30F410E3EA407D005E5 * L_0 = ((PaintManager_t8C7F3BD113E1D28F982A05D0397A369E09266BEE_StaticFields*)il2cpp_codegen_static_fields_for(PaintManager_t8C7F3BD113E1D28F982A05D0397A369E09266BEE_il2cpp_TypeInfo_var))->get_mobilePaint_5();
		__this->set_mobilePaint_4(L_0);
		MobilePaint_tC25928758E48181B341DE30F410E3EA407D005E5 * L_1 = __this->get_mobilePaint_4();
		IL2CPP_RUNTIME_CLASS_INIT(Object_tAE11E5E46CD5C37C9F3E8950C00CD8B45666A2D0_il2cpp_TypeInfo_var);
		bool L_2 = Object_op_Equality_mBC2401774F3BE33E8CF6F0A8148E66C95D6CFF1C(L_1, (Object_tAE11E5E46CD5C37C9F3E8950C00CD8B45666A2D0 *)NULL, /*hidden argument*/NULL);
		if (!L_2)
		{
			goto IL_0039;
		}
	}
	{
		Transform_tBB9E78A2766C3C83599A8F66EDE7D1FCAFC66EDA * L_3 = Component_get_transform_m00F05BD782F920C301A7EBA480F3B7A904C07EC9(__this, /*hidden argument*/NULL);
		NullCheck(L_3);
		String_t* L_4 = Object_get_name_mA2D400141CB3C991C87A2556429781DE961A83CE(L_3, /*hidden argument*/NULL);
		String_t* L_5 = String_Concat_mB78D0094592718DA6D5DB6C712A9C225631666BE(_stringLiteral18D7B45DCCC374DAC64758C817E1917534D16F3F, L_4, /*hidden argument*/NULL);
		GameObject_tBD1244AD56B4E59AAD76E5E7C9282EC5CE434F0F * L_6 = Component_get_gameObject_m0B0570BA8DDD3CD78A9DB568EA18D7317686603C(__this, /*hidden argument*/NULL);
		IL2CPP_RUNTIME_CLASS_INIT(Debug_t7B5FCB117E2FD63B6838BC52821B252E2BFB61C4_il2cpp_TypeInfo_var);
		Debug_LogError_m97139CB2EE76D5CD8308C1AD0499A5F163FC7F51(L_5, L_6, /*hidden argument*/NULL);
	}

IL_0039:
	{
		Toggle_t9ADD572046F831945ED0E48A01B50FEA1CA52106 * L_7 = Component_GetComponent_TisToggle_t9ADD572046F831945ED0E48A01B50FEA1CA52106_m89C4B9EA41130113FE63C1D06704BB4B91AD779B(__this, /*hidden argument*/Component_GetComponent_TisToggle_t9ADD572046F831945ED0E48A01B50FEA1CA52106_m89C4B9EA41130113FE63C1D06704BB4B91AD779B_RuntimeMethod_var);
		NullCheck(L_7);
		ToggleEvent_t50D925F8E220FB47DA738411CEF9C57FF7E1DC43 * L_8 = L_7->get_onValueChanged_21();
		UnityAction_1_tB994D127B02789CE2010397AEF756615E5F84FDC * L_9 = (UnityAction_1_tB994D127B02789CE2010397AEF756615E5F84FDC *)il2cpp_codegen_object_new(UnityAction_1_tB994D127B02789CE2010397AEF756615E5F84FDC_il2cpp_TypeInfo_var);
		UnityAction_1__ctor_m846CC5F9F2FD2F58CD1E78E7A4EB55DC5D6CA696(L_9, __this, (intptr_t)((intptr_t)ToggleBrushModeUI_U3CStartU3Eb__1_0_m05A85D28E9E9DEE9FE480EDD51389D9CA2182F93_RuntimeMethod_var), /*hidden argument*/UnityAction_1__ctor_m846CC5F9F2FD2F58CD1E78E7A4EB55DC5D6CA696_RuntimeMethod_var);
		NullCheck(L_8);
		UnityEvent_1_AddListener_mBCA646AF6B22F9F8190175F6AFF5195A9BED3FCA(L_8, L_9, /*hidden argument*/UnityEvent_1_AddListener_mBCA646AF6B22F9F8190175F6AFF5195A9BED3FCA_RuntimeMethod_var);
		return;
	}
}
// System.Void unitycoder_MobilePaint.ToggleBrushModeUI::SetMode()
extern "C" IL2CPP_METHOD_ATTR void ToggleBrushModeUI_SetMode_m0D6E237D85BE989C46F3399244FB8B9065AC2BF8 (ToggleBrushModeUI_t4B6DF517F8B4743603417CD2EB16093A8DE0758B * __this, const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_method (ToggleBrushModeUI_SetMode_m0D6E237D85BE989C46F3399244FB8B9065AC2BF8_MetadataUsageId);
		s_Il2CppMethodInitialized = true;
	}
	{
		Toggle_t9ADD572046F831945ED0E48A01B50FEA1CA52106 * L_0 = Component_GetComponent_TisToggle_t9ADD572046F831945ED0E48A01B50FEA1CA52106_m89C4B9EA41130113FE63C1D06704BB4B91AD779B(__this, /*hidden argument*/Component_GetComponent_TisToggle_t9ADD572046F831945ED0E48A01B50FEA1CA52106_m89C4B9EA41130113FE63C1D06704BB4B91AD779B_RuntimeMethod_var);
		NullCheck(L_0);
		bool L_1 = Toggle_get_isOn_mE13D628534F60138373B3E52CC93301DE59DB616(L_0, /*hidden argument*/NULL);
		if (!L_1)
		{
			goto IL_0018;
		}
	}
	{
		MobilePaint_tC25928758E48181B341DE30F410E3EA407D005E5 * L_2 = __this->get_mobilePaint_4();
		NullCheck(L_2);
		MobilePaint_SetDrawModeBrush_m42238934F471966676329992553EF0287E5DD831(L_2, /*hidden argument*/NULL);
	}

IL_0018:
	{
		return;
	}
}
// System.Void unitycoder_MobilePaint.ToggleBrushModeUI::.ctor()
extern "C" IL2CPP_METHOD_ATTR void ToggleBrushModeUI__ctor_m5E24F7C2ECFA752DC015A8FE0C72C8C2F5989579 (ToggleBrushModeUI_t4B6DF517F8B4743603417CD2EB16093A8DE0758B * __this, const RuntimeMethod* method)
{
	{
		MonoBehaviour__ctor_mEAEC84B222C60319D593E456D769B3311DFCEF97(__this, /*hidden argument*/NULL);
		return;
	}
}
// System.Void unitycoder_MobilePaint.ToggleBrushModeUI::<Start>b__1_0(System.Boolean)
extern "C" IL2CPP_METHOD_ATTR void ToggleBrushModeUI_U3CStartU3Eb__1_0_m05A85D28E9E9DEE9FE480EDD51389D9CA2182F93 (ToggleBrushModeUI_t4B6DF517F8B4743603417CD2EB16093A8DE0758B * __this, bool ___U3Cp0U3E0, const RuntimeMethod* method)
{
	{
		ToggleBrushModeUI_SetMode_m0D6E237D85BE989C46F3399244FB8B9065AC2BF8(__this, /*hidden argument*/NULL);
		return;
	}
}
#ifdef __clang__
#pragma clang diagnostic pop
#endif
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif
// System.Void unitycoder_MobilePaint.ToggleCustomPatternModeUI::Start()
extern "C" IL2CPP_METHOD_ATTR void ToggleCustomPatternModeUI_Start_mBED1EEC50E04980751FBD5D6E57A8606F052F284 (ToggleCustomPatternModeUI_tF5121E1792E8D86FB425CACACF9513D2B6E470AA * __this, const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_method (ToggleCustomPatternModeUI_Start_mBED1EEC50E04980751FBD5D6E57A8606F052F284_MetadataUsageId);
		s_Il2CppMethodInitialized = true;
	}
	Toggle_t9ADD572046F831945ED0E48A01B50FEA1CA52106 * V_0 = NULL;
	{
		MobilePaint_tC25928758E48181B341DE30F410E3EA407D005E5 * L_0 = ((PaintManager_t8C7F3BD113E1D28F982A05D0397A369E09266BEE_StaticFields*)il2cpp_codegen_static_fields_for(PaintManager_t8C7F3BD113E1D28F982A05D0397A369E09266BEE_il2cpp_TypeInfo_var))->get_mobilePaint_5();
		__this->set_mobilePaint_4(L_0);
		MobilePaint_tC25928758E48181B341DE30F410E3EA407D005E5 * L_1 = __this->get_mobilePaint_4();
		IL2CPP_RUNTIME_CLASS_INIT(Object_tAE11E5E46CD5C37C9F3E8950C00CD8B45666A2D0_il2cpp_TypeInfo_var);
		bool L_2 = Object_op_Equality_mBC2401774F3BE33E8CF6F0A8148E66C95D6CFF1C(L_1, (Object_tAE11E5E46CD5C37C9F3E8950C00CD8B45666A2D0 *)NULL, /*hidden argument*/NULL);
		if (!L_2)
		{
			goto IL_0039;
		}
	}
	{
		Transform_tBB9E78A2766C3C83599A8F66EDE7D1FCAFC66EDA * L_3 = Component_get_transform_m00F05BD782F920C301A7EBA480F3B7A904C07EC9(__this, /*hidden argument*/NULL);
		NullCheck(L_3);
		String_t* L_4 = Object_get_name_mA2D400141CB3C991C87A2556429781DE961A83CE(L_3, /*hidden argument*/NULL);
		String_t* L_5 = String_Concat_mB78D0094592718DA6D5DB6C712A9C225631666BE(_stringLiteral18D7B45DCCC374DAC64758C817E1917534D16F3F, L_4, /*hidden argument*/NULL);
		GameObject_tBD1244AD56B4E59AAD76E5E7C9282EC5CE434F0F * L_6 = Component_get_gameObject_m0B0570BA8DDD3CD78A9DB568EA18D7317686603C(__this, /*hidden argument*/NULL);
		IL2CPP_RUNTIME_CLASS_INIT(Debug_t7B5FCB117E2FD63B6838BC52821B252E2BFB61C4_il2cpp_TypeInfo_var);
		Debug_LogError_m97139CB2EE76D5CD8308C1AD0499A5F163FC7F51(L_5, L_6, /*hidden argument*/NULL);
	}

IL_0039:
	{
		GameObject_tBD1244AD56B4E59AAD76E5E7C9282EC5CE434F0F * L_7 = __this->get_customPanel_5();
		IL2CPP_RUNTIME_CLASS_INIT(Object_tAE11E5E46CD5C37C9F3E8950C00CD8B45666A2D0_il2cpp_TypeInfo_var);
		bool L_8 = Object_op_Equality_mBC2401774F3BE33E8CF6F0A8148E66C95D6CFF1C(L_7, (Object_tAE11E5E46CD5C37C9F3E8950C00CD8B45666A2D0 *)NULL, /*hidden argument*/NULL);
		if (!L_8)
		{
			goto IL_0067;
		}
	}
	{
		Transform_tBB9E78A2766C3C83599A8F66EDE7D1FCAFC66EDA * L_9 = Component_get_transform_m00F05BD782F920C301A7EBA480F3B7A904C07EC9(__this, /*hidden argument*/NULL);
		NullCheck(L_9);
		String_t* L_10 = Object_get_name_mA2D400141CB3C991C87A2556429781DE961A83CE(L_9, /*hidden argument*/NULL);
		String_t* L_11 = String_Concat_mB78D0094592718DA6D5DB6C712A9C225631666BE(_stringLiteralD583746F12022FBC88293CCA2619D6B8A9B6472A, L_10, /*hidden argument*/NULL);
		GameObject_tBD1244AD56B4E59AAD76E5E7C9282EC5CE434F0F * L_12 = Component_get_gameObject_m0B0570BA8DDD3CD78A9DB568EA18D7317686603C(__this, /*hidden argument*/NULL);
		IL2CPP_RUNTIME_CLASS_INIT(Debug_t7B5FCB117E2FD63B6838BC52821B252E2BFB61C4_il2cpp_TypeInfo_var);
		Debug_LogError_m97139CB2EE76D5CD8308C1AD0499A5F163FC7F51(L_11, L_12, /*hidden argument*/NULL);
	}

IL_0067:
	{
		Toggle_t9ADD572046F831945ED0E48A01B50FEA1CA52106 * L_13 = Component_GetComponent_TisToggle_t9ADD572046F831945ED0E48A01B50FEA1CA52106_m89C4B9EA41130113FE63C1D06704BB4B91AD779B(__this, /*hidden argument*/Component_GetComponent_TisToggle_t9ADD572046F831945ED0E48A01B50FEA1CA52106_m89C4B9EA41130113FE63C1D06704BB4B91AD779B_RuntimeMethod_var);
		V_0 = L_13;
		Toggle_t9ADD572046F831945ED0E48A01B50FEA1CA52106 * L_14 = V_0;
		IL2CPP_RUNTIME_CLASS_INIT(Object_tAE11E5E46CD5C37C9F3E8950C00CD8B45666A2D0_il2cpp_TypeInfo_var);
		bool L_15 = Object_op_Equality_mBC2401774F3BE33E8CF6F0A8148E66C95D6CFF1C(L_14, (Object_tAE11E5E46CD5C37C9F3E8950C00CD8B45666A2D0 *)NULL, /*hidden argument*/NULL);
		if (!L_15)
		{
			goto IL_0097;
		}
	}
	{
		Transform_tBB9E78A2766C3C83599A8F66EDE7D1FCAFC66EDA * L_16 = Component_get_transform_m00F05BD782F920C301A7EBA480F3B7A904C07EC9(__this, /*hidden argument*/NULL);
		NullCheck(L_16);
		String_t* L_17 = Object_get_name_mA2D400141CB3C991C87A2556429781DE961A83CE(L_16, /*hidden argument*/NULL);
		String_t* L_18 = String_Concat_mB78D0094592718DA6D5DB6C712A9C225631666BE(_stringLiteralC91A3B0927A7298D2B845FB524A9A00216F7CD7F, L_17, /*hidden argument*/NULL);
		GameObject_tBD1244AD56B4E59AAD76E5E7C9282EC5CE434F0F * L_19 = Component_get_gameObject_m0B0570BA8DDD3CD78A9DB568EA18D7317686603C(__this, /*hidden argument*/NULL);
		IL2CPP_RUNTIME_CLASS_INIT(Debug_t7B5FCB117E2FD63B6838BC52821B252E2BFB61C4_il2cpp_TypeInfo_var);
		Debug_LogError_m97139CB2EE76D5CD8308C1AD0499A5F163FC7F51(L_18, L_19, /*hidden argument*/NULL);
	}

IL_0097:
	{
		MobilePaint_tC25928758E48181B341DE30F410E3EA407D005E5 * L_20 = __this->get_mobilePaint_4();
		NullCheck(L_20);
		bool L_21 = L_20->get_useCustomPatterns_57();
		if (!L_21)
		{
			goto IL_00bc;
		}
	}
	{
		Toggle_t9ADD572046F831945ED0E48A01B50FEA1CA52106 * L_22 = V_0;
		NullCheck(L_22);
		ToggleEvent_t50D925F8E220FB47DA738411CEF9C57FF7E1DC43 * L_23 = L_22->get_onValueChanged_21();
		UnityAction_1_tB994D127B02789CE2010397AEF756615E5F84FDC * L_24 = (UnityAction_1_tB994D127B02789CE2010397AEF756615E5F84FDC *)il2cpp_codegen_object_new(UnityAction_1_tB994D127B02789CE2010397AEF756615E5F84FDC_il2cpp_TypeInfo_var);
		UnityAction_1__ctor_m846CC5F9F2FD2F58CD1E78E7A4EB55DC5D6CA696(L_24, __this, (intptr_t)((intptr_t)ToggleCustomPatternModeUI_U3CStartU3Eb__2_0_m9D320741A979A9DEF8309511B626F4B37C5B3825_RuntimeMethod_var), /*hidden argument*/UnityAction_1__ctor_m846CC5F9F2FD2F58CD1E78E7A4EB55DC5D6CA696_RuntimeMethod_var);
		NullCheck(L_23);
		UnityEvent_1_AddListener_mBCA646AF6B22F9F8190175F6AFF5195A9BED3FCA(L_23, L_24, /*hidden argument*/UnityEvent_1_AddListener_mBCA646AF6B22F9F8190175F6AFF5195A9BED3FCA_RuntimeMethod_var);
		return;
	}

IL_00bc:
	{
		GameObject_tBD1244AD56B4E59AAD76E5E7C9282EC5CE434F0F * L_25 = Component_get_gameObject_m0B0570BA8DDD3CD78A9DB568EA18D7317686603C(__this, /*hidden argument*/NULL);
		IL2CPP_RUNTIME_CLASS_INIT(Debug_t7B5FCB117E2FD63B6838BC52821B252E2BFB61C4_il2cpp_TypeInfo_var);
		Debug_LogWarning_mD417697331190AC1D21C463F412C475103A7256E(_stringLiteral9FCBAD1C07A47FCE95E02D55974D5730506273DC, L_25, /*hidden argument*/NULL);
		Toggle_t9ADD572046F831945ED0E48A01B50FEA1CA52106 * L_26 = V_0;
		NullCheck(L_26);
		Selectable_set_interactable_mD5096017CC3058D280066EB9ABDDF5062983A94F(L_26, (bool)0, /*hidden argument*/NULL);
		return;
	}
}
// System.Void unitycoder_MobilePaint.ToggleCustomPatternModeUI::SetMode()
extern "C" IL2CPP_METHOD_ATTR void ToggleCustomPatternModeUI_SetMode_mF0225DFF7BFBCF4A096FF61DBE8631B3607BCDFD (ToggleCustomPatternModeUI_tF5121E1792E8D86FB425CACACF9513D2B6E470AA * __this, const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_method (ToggleCustomPatternModeUI_SetMode_mF0225DFF7BFBCF4A096FF61DBE8631B3607BCDFD_MetadataUsageId);
		s_Il2CppMethodInitialized = true;
	}
	{
		Toggle_t9ADD572046F831945ED0E48A01B50FEA1CA52106 * L_0 = Component_GetComponent_TisToggle_t9ADD572046F831945ED0E48A01B50FEA1CA52106_m89C4B9EA41130113FE63C1D06704BB4B91AD779B(__this, /*hidden argument*/Component_GetComponent_TisToggle_t9ADD572046F831945ED0E48A01B50FEA1CA52106_m89C4B9EA41130113FE63C1D06704BB4B91AD779B_RuntimeMethod_var);
		NullCheck(L_0);
		bool L_1 = Toggle_get_isOn_mE13D628534F60138373B3E52CC93301DE59DB616(L_0, /*hidden argument*/NULL);
		if (!L_1)
		{
			goto IL_0025;
		}
	}
	{
		GameObject_tBD1244AD56B4E59AAD76E5E7C9282EC5CE434F0F * L_2 = __this->get_customPanel_5();
		NullCheck(L_2);
		GameObject_SetActive_m25A39F6D9FB68C51F13313F9804E85ACC937BC04(L_2, (bool)1, /*hidden argument*/NULL);
		MobilePaint_tC25928758E48181B341DE30F410E3EA407D005E5 * L_3 = __this->get_mobilePaint_4();
		NullCheck(L_3);
		MobilePaint_SetDrawModePattern_m00162C11B3A1AE9E842F127361FF941186F7D91D(L_3, /*hidden argument*/NULL);
		return;
	}

IL_0025:
	{
		GameObject_tBD1244AD56B4E59AAD76E5E7C9282EC5CE434F0F * L_4 = __this->get_customPanel_5();
		NullCheck(L_4);
		GameObject_SetActive_m25A39F6D9FB68C51F13313F9804E85ACC937BC04(L_4, (bool)0, /*hidden argument*/NULL);
		return;
	}
}
// System.Void unitycoder_MobilePaint.ToggleCustomPatternModeUI::.ctor()
extern "C" IL2CPP_METHOD_ATTR void ToggleCustomPatternModeUI__ctor_mC74F2671745D56C05D50BA4E8B842BAF08B3A475 (ToggleCustomPatternModeUI_tF5121E1792E8D86FB425CACACF9513D2B6E470AA * __this, const RuntimeMethod* method)
{
	{
		MonoBehaviour__ctor_mEAEC84B222C60319D593E456D769B3311DFCEF97(__this, /*hidden argument*/NULL);
		return;
	}
}
// System.Void unitycoder_MobilePaint.ToggleCustomPatternModeUI::<Start>b__2_0(System.Boolean)
extern "C" IL2CPP_METHOD_ATTR void ToggleCustomPatternModeUI_U3CStartU3Eb__2_0_m9D320741A979A9DEF8309511B626F4B37C5B3825 (ToggleCustomPatternModeUI_tF5121E1792E8D86FB425CACACF9513D2B6E470AA * __this, bool ___U3Cp0U3E0, const RuntimeMethod* method)
{
	{
		ToggleCustomPatternModeUI_SetMode_mF0225DFF7BFBCF4A096FF61DBE8631B3607BCDFD(__this, /*hidden argument*/NULL);
		return;
	}
}
#ifdef __clang__
#pragma clang diagnostic pop
#endif
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif
// System.Void unitycoder_MobilePaint.ToggleCustomShapeModeUI::Start()
extern "C" IL2CPP_METHOD_ATTR void ToggleCustomShapeModeUI_Start_mDCF0B691794D31EFBF7C0A3744439B649449CEC7 (ToggleCustomShapeModeUI_t5DABF74118B1166FDBB31E08F25358F0FC907BF2 * __this, const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_method (ToggleCustomShapeModeUI_Start_mDCF0B691794D31EFBF7C0A3744439B649449CEC7_MetadataUsageId);
		s_Il2CppMethodInitialized = true;
	}
	Toggle_t9ADD572046F831945ED0E48A01B50FEA1CA52106 * V_0 = NULL;
	{
		MobilePaint_tC25928758E48181B341DE30F410E3EA407D005E5 * L_0 = ((PaintManager_t8C7F3BD113E1D28F982A05D0397A369E09266BEE_StaticFields*)il2cpp_codegen_static_fields_for(PaintManager_t8C7F3BD113E1D28F982A05D0397A369E09266BEE_il2cpp_TypeInfo_var))->get_mobilePaint_5();
		__this->set_mobilePaint_4(L_0);
		MobilePaint_tC25928758E48181B341DE30F410E3EA407D005E5 * L_1 = __this->get_mobilePaint_4();
		IL2CPP_RUNTIME_CLASS_INIT(Object_tAE11E5E46CD5C37C9F3E8950C00CD8B45666A2D0_il2cpp_TypeInfo_var);
		bool L_2 = Object_op_Equality_mBC2401774F3BE33E8CF6F0A8148E66C95D6CFF1C(L_1, (Object_tAE11E5E46CD5C37C9F3E8950C00CD8B45666A2D0 *)NULL, /*hidden argument*/NULL);
		if (!L_2)
		{
			goto IL_0029;
		}
	}
	{
		GameObject_tBD1244AD56B4E59AAD76E5E7C9282EC5CE434F0F * L_3 = Component_get_gameObject_m0B0570BA8DDD3CD78A9DB568EA18D7317686603C(__this, /*hidden argument*/NULL);
		IL2CPP_RUNTIME_CLASS_INIT(Debug_t7B5FCB117E2FD63B6838BC52821B252E2BFB61C4_il2cpp_TypeInfo_var);
		Debug_LogError_m97139CB2EE76D5CD8308C1AD0499A5F163FC7F51(_stringLiteralF4088DDD15F0018ADED2993A916DD07CDBA5D439, L_3, /*hidden argument*/NULL);
	}

IL_0029:
	{
		GameObject_tBD1244AD56B4E59AAD76E5E7C9282EC5CE434F0F * L_4 = __this->get_customBrushPanel_5();
		IL2CPP_RUNTIME_CLASS_INIT(Object_tAE11E5E46CD5C37C9F3E8950C00CD8B45666A2D0_il2cpp_TypeInfo_var);
		bool L_5 = Object_op_Equality_mBC2401774F3BE33E8CF6F0A8148E66C95D6CFF1C(L_4, (Object_tAE11E5E46CD5C37C9F3E8950C00CD8B45666A2D0 *)NULL, /*hidden argument*/NULL);
		if (!L_5)
		{
			goto IL_0047;
		}
	}
	{
		GameObject_tBD1244AD56B4E59AAD76E5E7C9282EC5CE434F0F * L_6 = Component_get_gameObject_m0B0570BA8DDD3CD78A9DB568EA18D7317686603C(__this, /*hidden argument*/NULL);
		IL2CPP_RUNTIME_CLASS_INIT(Debug_t7B5FCB117E2FD63B6838BC52821B252E2BFB61C4_il2cpp_TypeInfo_var);
		Debug_LogError_m97139CB2EE76D5CD8308C1AD0499A5F163FC7F51(_stringLiteral3F663A634BF9364321DB1AB11E3F43060097BF04, L_6, /*hidden argument*/NULL);
	}

IL_0047:
	{
		Toggle_t9ADD572046F831945ED0E48A01B50FEA1CA52106 * L_7 = Component_GetComponent_TisToggle_t9ADD572046F831945ED0E48A01B50FEA1CA52106_m89C4B9EA41130113FE63C1D06704BB4B91AD779B(__this, /*hidden argument*/Component_GetComponent_TisToggle_t9ADD572046F831945ED0E48A01B50FEA1CA52106_m89C4B9EA41130113FE63C1D06704BB4B91AD779B_RuntimeMethod_var);
		V_0 = L_7;
		Toggle_t9ADD572046F831945ED0E48A01B50FEA1CA52106 * L_8 = V_0;
		IL2CPP_RUNTIME_CLASS_INIT(Object_tAE11E5E46CD5C37C9F3E8950C00CD8B45666A2D0_il2cpp_TypeInfo_var);
		bool L_9 = Object_op_Equality_mBC2401774F3BE33E8CF6F0A8148E66C95D6CFF1C(L_8, (Object_tAE11E5E46CD5C37C9F3E8950C00CD8B45666A2D0 *)NULL, /*hidden argument*/NULL);
		if (!L_9)
		{
			goto IL_0067;
		}
	}
	{
		GameObject_tBD1244AD56B4E59AAD76E5E7C9282EC5CE434F0F * L_10 = Component_get_gameObject_m0B0570BA8DDD3CD78A9DB568EA18D7317686603C(__this, /*hidden argument*/NULL);
		IL2CPP_RUNTIME_CLASS_INIT(Debug_t7B5FCB117E2FD63B6838BC52821B252E2BFB61C4_il2cpp_TypeInfo_var);
		Debug_LogError_m97139CB2EE76D5CD8308C1AD0499A5F163FC7F51(_stringLiteral821B5DB5E92E7BF3D748D2268C2C912DE1019557, L_10, /*hidden argument*/NULL);
	}

IL_0067:
	{
		Toggle_t9ADD572046F831945ED0E48A01B50FEA1CA52106 * L_11 = V_0;
		MobilePaint_tC25928758E48181B341DE30F410E3EA407D005E5 * L_12 = __this->get_mobilePaint_4();
		NullCheck(L_12);
		bool L_13 = L_12->get_useCustomBrushes_46();
		NullCheck(L_11);
		Selectable_set_interactable_mD5096017CC3058D280066EB9ABDDF5062983A94F(L_11, L_13, /*hidden argument*/NULL);
		Toggle_t9ADD572046F831945ED0E48A01B50FEA1CA52106 * L_14 = V_0;
		NullCheck(L_14);
		bool L_15 = VirtFuncInvoker0< bool >::Invoke(24 /* System.Boolean UnityEngine.UI.Selectable::IsInteractable() */, L_14);
		if (!L_15)
		{
			goto IL_0097;
		}
	}
	{
		Toggle_t9ADD572046F831945ED0E48A01B50FEA1CA52106 * L_16 = V_0;
		NullCheck(L_16);
		ToggleEvent_t50D925F8E220FB47DA738411CEF9C57FF7E1DC43 * L_17 = L_16->get_onValueChanged_21();
		UnityAction_1_tB994D127B02789CE2010397AEF756615E5F84FDC * L_18 = (UnityAction_1_tB994D127B02789CE2010397AEF756615E5F84FDC *)il2cpp_codegen_object_new(UnityAction_1_tB994D127B02789CE2010397AEF756615E5F84FDC_il2cpp_TypeInfo_var);
		UnityAction_1__ctor_m846CC5F9F2FD2F58CD1E78E7A4EB55DC5D6CA696(L_18, __this, (intptr_t)((intptr_t)ToggleCustomShapeModeUI_U3CStartU3Eb__2_0_m5ED189BC7474A70EB98ADAECCED64CD95CA5B82C_RuntimeMethod_var), /*hidden argument*/UnityAction_1__ctor_m846CC5F9F2FD2F58CD1E78E7A4EB55DC5D6CA696_RuntimeMethod_var);
		NullCheck(L_17);
		UnityEvent_1_AddListener_mBCA646AF6B22F9F8190175F6AFF5195A9BED3FCA(L_17, L_18, /*hidden argument*/UnityEvent_1_AddListener_mBCA646AF6B22F9F8190175F6AFF5195A9BED3FCA_RuntimeMethod_var);
	}

IL_0097:
	{
		return;
	}
}
// System.Void unitycoder_MobilePaint.ToggleCustomShapeModeUI::SetMode()
extern "C" IL2CPP_METHOD_ATTR void ToggleCustomShapeModeUI_SetMode_mE58A9402216F7D890A4258BD6D6BE6D3F4FA4D2C (ToggleCustomShapeModeUI_t5DABF74118B1166FDBB31E08F25358F0FC907BF2 * __this, const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_method (ToggleCustomShapeModeUI_SetMode_mE58A9402216F7D890A4258BD6D6BE6D3F4FA4D2C_MetadataUsageId);
		s_Il2CppMethodInitialized = true;
	}
	{
		Toggle_t9ADD572046F831945ED0E48A01B50FEA1CA52106 * L_0 = Component_GetComponent_TisToggle_t9ADD572046F831945ED0E48A01B50FEA1CA52106_m89C4B9EA41130113FE63C1D06704BB4B91AD779B(__this, /*hidden argument*/Component_GetComponent_TisToggle_t9ADD572046F831945ED0E48A01B50FEA1CA52106_m89C4B9EA41130113FE63C1D06704BB4B91AD779B_RuntimeMethod_var);
		NullCheck(L_0);
		bool L_1 = Toggle_get_isOn_mE13D628534F60138373B3E52CC93301DE59DB616(L_0, /*hidden argument*/NULL);
		if (!L_1)
		{
			goto IL_0025;
		}
	}
	{
		GameObject_tBD1244AD56B4E59AAD76E5E7C9282EC5CE434F0F * L_2 = __this->get_customBrushPanel_5();
		NullCheck(L_2);
		GameObject_SetActive_m25A39F6D9FB68C51F13313F9804E85ACC937BC04(L_2, (bool)1, /*hidden argument*/NULL);
		MobilePaint_tC25928758E48181B341DE30F410E3EA407D005E5 * L_3 = __this->get_mobilePaint_4();
		NullCheck(L_3);
		MobilePaint_SetDrawModeShapes_m25B1CE7B0F5AEB924F1768B49AC053095B243152(L_3, /*hidden argument*/NULL);
		return;
	}

IL_0025:
	{
		GameObject_tBD1244AD56B4E59AAD76E5E7C9282EC5CE434F0F * L_4 = __this->get_customBrushPanel_5();
		NullCheck(L_4);
		GameObject_SetActive_m25A39F6D9FB68C51F13313F9804E85ACC937BC04(L_4, (bool)0, /*hidden argument*/NULL);
		return;
	}
}
// System.Void unitycoder_MobilePaint.ToggleCustomShapeModeUI::.ctor()
extern "C" IL2CPP_METHOD_ATTR void ToggleCustomShapeModeUI__ctor_mFECFB8469897CB20D8CC8265DC9C4FEFDDB3C8D3 (ToggleCustomShapeModeUI_t5DABF74118B1166FDBB31E08F25358F0FC907BF2 * __this, const RuntimeMethod* method)
{
	{
		MonoBehaviour__ctor_mEAEC84B222C60319D593E456D769B3311DFCEF97(__this, /*hidden argument*/NULL);
		return;
	}
}
// System.Void unitycoder_MobilePaint.ToggleCustomShapeModeUI::<Start>b__2_0(System.Boolean)
extern "C" IL2CPP_METHOD_ATTR void ToggleCustomShapeModeUI_U3CStartU3Eb__2_0_m5ED189BC7474A70EB98ADAECCED64CD95CA5B82C (ToggleCustomShapeModeUI_t5DABF74118B1166FDBB31E08F25358F0FC907BF2 * __this, bool ___U3Cp0U3E0, const RuntimeMethod* method)
{
	{
		ToggleCustomShapeModeUI_SetMode_mE58A9402216F7D890A4258BD6D6BE6D3F4FA4D2C(__this, /*hidden argument*/NULL);
		return;
	}
}
#ifdef __clang__
#pragma clang diagnostic pop
#endif
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif
// System.Void unitycoder_MobilePaint.ToggleEraserModeUI::Start()
extern "C" IL2CPP_METHOD_ATTR void ToggleEraserModeUI_Start_m2F5227799AEC33A72B6A5D19F1820693F618C080 (ToggleEraserModeUI_t12A48F99C7CA25B41997882C81CCF6274E6B09D2 * __this, const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_method (ToggleEraserModeUI_Start_m2F5227799AEC33A72B6A5D19F1820693F618C080_MetadataUsageId);
		s_Il2CppMethodInitialized = true;
	}
	Toggle_t9ADD572046F831945ED0E48A01B50FEA1CA52106 * V_0 = NULL;
	{
		MobilePaint_tC25928758E48181B341DE30F410E3EA407D005E5 * L_0 = ((PaintManager_t8C7F3BD113E1D28F982A05D0397A369E09266BEE_StaticFields*)il2cpp_codegen_static_fields_for(PaintManager_t8C7F3BD113E1D28F982A05D0397A369E09266BEE_il2cpp_TypeInfo_var))->get_mobilePaint_5();
		__this->set_mobilePaint_4(L_0);
		MobilePaint_tC25928758E48181B341DE30F410E3EA407D005E5 * L_1 = __this->get_mobilePaint_4();
		IL2CPP_RUNTIME_CLASS_INIT(Object_tAE11E5E46CD5C37C9F3E8950C00CD8B45666A2D0_il2cpp_TypeInfo_var);
		bool L_2 = Object_op_Equality_mBC2401774F3BE33E8CF6F0A8148E66C95D6CFF1C(L_1, (Object_tAE11E5E46CD5C37C9F3E8950C00CD8B45666A2D0 *)NULL, /*hidden argument*/NULL);
		if (!L_2)
		{
			goto IL_0029;
		}
	}
	{
		GameObject_tBD1244AD56B4E59AAD76E5E7C9282EC5CE434F0F * L_3 = Component_get_gameObject_m0B0570BA8DDD3CD78A9DB568EA18D7317686603C(__this, /*hidden argument*/NULL);
		IL2CPP_RUNTIME_CLASS_INIT(Debug_t7B5FCB117E2FD63B6838BC52821B252E2BFB61C4_il2cpp_TypeInfo_var);
		Debug_LogError_m97139CB2EE76D5CD8308C1AD0499A5F163FC7F51(_stringLiteralF4088DDD15F0018ADED2993A916DD07CDBA5D439, L_3, /*hidden argument*/NULL);
	}

IL_0029:
	{
		Toggle_t9ADD572046F831945ED0E48A01B50FEA1CA52106 * L_4 = Component_GetComponent_TisToggle_t9ADD572046F831945ED0E48A01B50FEA1CA52106_m89C4B9EA41130113FE63C1D06704BB4B91AD779B(__this, /*hidden argument*/Component_GetComponent_TisToggle_t9ADD572046F831945ED0E48A01B50FEA1CA52106_m89C4B9EA41130113FE63C1D06704BB4B91AD779B_RuntimeMethod_var);
		V_0 = L_4;
		Toggle_t9ADD572046F831945ED0E48A01B50FEA1CA52106 * L_5 = V_0;
		IL2CPP_RUNTIME_CLASS_INIT(Object_tAE11E5E46CD5C37C9F3E8950C00CD8B45666A2D0_il2cpp_TypeInfo_var);
		bool L_6 = Object_op_Equality_mBC2401774F3BE33E8CF6F0A8148E66C95D6CFF1C(L_5, (Object_tAE11E5E46CD5C37C9F3E8950C00CD8B45666A2D0 *)NULL, /*hidden argument*/NULL);
		if (!L_6)
		{
			goto IL_0049;
		}
	}
	{
		GameObject_tBD1244AD56B4E59AAD76E5E7C9282EC5CE434F0F * L_7 = Component_get_gameObject_m0B0570BA8DDD3CD78A9DB568EA18D7317686603C(__this, /*hidden argument*/NULL);
		IL2CPP_RUNTIME_CLASS_INIT(Debug_t7B5FCB117E2FD63B6838BC52821B252E2BFB61C4_il2cpp_TypeInfo_var);
		Debug_LogError_m97139CB2EE76D5CD8308C1AD0499A5F163FC7F51(_stringLiteral821B5DB5E92E7BF3D748D2268C2C912DE1019557, L_7, /*hidden argument*/NULL);
	}

IL_0049:
	{
		Toggle_t9ADD572046F831945ED0E48A01B50FEA1CA52106 * L_8 = V_0;
		NullCheck(L_8);
		bool L_9 = VirtFuncInvoker0< bool >::Invoke(24 /* System.Boolean UnityEngine.UI.Selectable::IsInteractable() */, L_8);
		if (!L_9)
		{
			goto IL_0068;
		}
	}
	{
		Toggle_t9ADD572046F831945ED0E48A01B50FEA1CA52106 * L_10 = V_0;
		NullCheck(L_10);
		ToggleEvent_t50D925F8E220FB47DA738411CEF9C57FF7E1DC43 * L_11 = L_10->get_onValueChanged_21();
		UnityAction_1_tB994D127B02789CE2010397AEF756615E5F84FDC * L_12 = (UnityAction_1_tB994D127B02789CE2010397AEF756615E5F84FDC *)il2cpp_codegen_object_new(UnityAction_1_tB994D127B02789CE2010397AEF756615E5F84FDC_il2cpp_TypeInfo_var);
		UnityAction_1__ctor_m846CC5F9F2FD2F58CD1E78E7A4EB55DC5D6CA696(L_12, __this, (intptr_t)((intptr_t)ToggleEraserModeUI_U3CStartU3Eb__1_0_m3C573D215A9FDCDF3A8EDE5F15A03DCD22B05C85_RuntimeMethod_var), /*hidden argument*/UnityAction_1__ctor_m846CC5F9F2FD2F58CD1E78E7A4EB55DC5D6CA696_RuntimeMethod_var);
		NullCheck(L_11);
		UnityEvent_1_AddListener_mBCA646AF6B22F9F8190175F6AFF5195A9BED3FCA(L_11, L_12, /*hidden argument*/UnityEvent_1_AddListener_mBCA646AF6B22F9F8190175F6AFF5195A9BED3FCA_RuntimeMethod_var);
	}

IL_0068:
	{
		return;
	}
}
// System.Void unitycoder_MobilePaint.ToggleEraserModeUI::SetMode()
extern "C" IL2CPP_METHOD_ATTR void ToggleEraserModeUI_SetMode_mB8CD91227A8742223015F5DBB79CC498D1AE3B6B (ToggleEraserModeUI_t12A48F99C7CA25B41997882C81CCF6274E6B09D2 * __this, const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_method (ToggleEraserModeUI_SetMode_mB8CD91227A8742223015F5DBB79CC498D1AE3B6B_MetadataUsageId);
		s_Il2CppMethodInitialized = true;
	}
	{
		Toggle_t9ADD572046F831945ED0E48A01B50FEA1CA52106 * L_0 = Component_GetComponent_TisToggle_t9ADD572046F831945ED0E48A01B50FEA1CA52106_m89C4B9EA41130113FE63C1D06704BB4B91AD779B(__this, /*hidden argument*/Component_GetComponent_TisToggle_t9ADD572046F831945ED0E48A01B50FEA1CA52106_m89C4B9EA41130113FE63C1D06704BB4B91AD779B_RuntimeMethod_var);
		NullCheck(L_0);
		bool L_1 = Toggle_get_isOn_mE13D628534F60138373B3E52CC93301DE59DB616(L_0, /*hidden argument*/NULL);
		if (!L_1)
		{
			goto IL_0018;
		}
	}
	{
		MobilePaint_tC25928758E48181B341DE30F410E3EA407D005E5 * L_2 = __this->get_mobilePaint_4();
		NullCheck(L_2);
		MobilePaint_SetDrawModeEraser_m34260FB4E137E97721E93899D2497AF253D1BEB2(L_2, /*hidden argument*/NULL);
	}

IL_0018:
	{
		return;
	}
}
// System.Void unitycoder_MobilePaint.ToggleEraserModeUI::.ctor()
extern "C" IL2CPP_METHOD_ATTR void ToggleEraserModeUI__ctor_m6E3309D8AFC21AE298A19DC5DF581224921D3012 (ToggleEraserModeUI_t12A48F99C7CA25B41997882C81CCF6274E6B09D2 * __this, const RuntimeMethod* method)
{
	{
		MonoBehaviour__ctor_mEAEC84B222C60319D593E456D769B3311DFCEF97(__this, /*hidden argument*/NULL);
		return;
	}
}
// System.Void unitycoder_MobilePaint.ToggleEraserModeUI::<Start>b__1_0(System.Boolean)
extern "C" IL2CPP_METHOD_ATTR void ToggleEraserModeUI_U3CStartU3Eb__1_0_m3C573D215A9FDCDF3A8EDE5F15A03DCD22B05C85 (ToggleEraserModeUI_t12A48F99C7CA25B41997882C81CCF6274E6B09D2 * __this, bool ___U3Cp0U3E0, const RuntimeMethod* method)
{
	{
		ToggleEraserModeUI_SetMode_mB8CD91227A8742223015F5DBB79CC498D1AE3B6B(__this, /*hidden argument*/NULL);
		return;
	}
}
#ifdef __clang__
#pragma clang diagnostic pop
#endif
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif
// System.Void unitycoder_MobilePaint.ToggleFloodFillModeUI::Start()
extern "C" IL2CPP_METHOD_ATTR void ToggleFloodFillModeUI_Start_mEE320A965A70D12824DC4C5ADE0C9128AF2A892F (ToggleFloodFillModeUI_tF40BA330FD9EEC86BEA5CD7943EC4599BAD93095 * __this, const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_method (ToggleFloodFillModeUI_Start_mEE320A965A70D12824DC4C5ADE0C9128AF2A892F_MetadataUsageId);
		s_Il2CppMethodInitialized = true;
	}
	{
		MobilePaint_tC25928758E48181B341DE30F410E3EA407D005E5 * L_0 = ((PaintManager_t8C7F3BD113E1D28F982A05D0397A369E09266BEE_StaticFields*)il2cpp_codegen_static_fields_for(PaintManager_t8C7F3BD113E1D28F982A05D0397A369E09266BEE_il2cpp_TypeInfo_var))->get_mobilePaint_5();
		__this->set_mobilePaint_4(L_0);
		MobilePaint_tC25928758E48181B341DE30F410E3EA407D005E5 * L_1 = __this->get_mobilePaint_4();
		IL2CPP_RUNTIME_CLASS_INIT(Object_tAE11E5E46CD5C37C9F3E8950C00CD8B45666A2D0_il2cpp_TypeInfo_var);
		bool L_2 = Object_op_Equality_mBC2401774F3BE33E8CF6F0A8148E66C95D6CFF1C(L_1, (Object_tAE11E5E46CD5C37C9F3E8950C00CD8B45666A2D0 *)NULL, /*hidden argument*/NULL);
		if (!L_2)
		{
			goto IL_0039;
		}
	}
	{
		Transform_tBB9E78A2766C3C83599A8F66EDE7D1FCAFC66EDA * L_3 = Component_get_transform_m00F05BD782F920C301A7EBA480F3B7A904C07EC9(__this, /*hidden argument*/NULL);
		NullCheck(L_3);
		String_t* L_4 = Object_get_name_mA2D400141CB3C991C87A2556429781DE961A83CE(L_3, /*hidden argument*/NULL);
		String_t* L_5 = String_Concat_mB78D0094592718DA6D5DB6C712A9C225631666BE(_stringLiteral18D7B45DCCC374DAC64758C817E1917534D16F3F, L_4, /*hidden argument*/NULL);
		GameObject_tBD1244AD56B4E59AAD76E5E7C9282EC5CE434F0F * L_6 = Component_get_gameObject_m0B0570BA8DDD3CD78A9DB568EA18D7317686603C(__this, /*hidden argument*/NULL);
		IL2CPP_RUNTIME_CLASS_INIT(Debug_t7B5FCB117E2FD63B6838BC52821B252E2BFB61C4_il2cpp_TypeInfo_var);
		Debug_LogError_m97139CB2EE76D5CD8308C1AD0499A5F163FC7F51(L_5, L_6, /*hidden argument*/NULL);
	}

IL_0039:
	{
		Toggle_t9ADD572046F831945ED0E48A01B50FEA1CA52106 * L_7 = Component_GetComponent_TisToggle_t9ADD572046F831945ED0E48A01B50FEA1CA52106_m89C4B9EA41130113FE63C1D06704BB4B91AD779B(__this, /*hidden argument*/Component_GetComponent_TisToggle_t9ADD572046F831945ED0E48A01B50FEA1CA52106_m89C4B9EA41130113FE63C1D06704BB4B91AD779B_RuntimeMethod_var);
		NullCheck(L_7);
		ToggleEvent_t50D925F8E220FB47DA738411CEF9C57FF7E1DC43 * L_8 = L_7->get_onValueChanged_21();
		UnityAction_1_tB994D127B02789CE2010397AEF756615E5F84FDC * L_9 = (UnityAction_1_tB994D127B02789CE2010397AEF756615E5F84FDC *)il2cpp_codegen_object_new(UnityAction_1_tB994D127B02789CE2010397AEF756615E5F84FDC_il2cpp_TypeInfo_var);
		UnityAction_1__ctor_m846CC5F9F2FD2F58CD1E78E7A4EB55DC5D6CA696(L_9, __this, (intptr_t)((intptr_t)ToggleFloodFillModeUI_U3CStartU3Eb__1_0_m9AB4739F25B0D0FCBACC931E811631A42A77D865_RuntimeMethod_var), /*hidden argument*/UnityAction_1__ctor_m846CC5F9F2FD2F58CD1E78E7A4EB55DC5D6CA696_RuntimeMethod_var);
		NullCheck(L_8);
		UnityEvent_1_AddListener_mBCA646AF6B22F9F8190175F6AFF5195A9BED3FCA(L_8, L_9, /*hidden argument*/UnityEvent_1_AddListener_mBCA646AF6B22F9F8190175F6AFF5195A9BED3FCA_RuntimeMethod_var);
		return;
	}
}
// System.Void unitycoder_MobilePaint.ToggleFloodFillModeUI::SetMode()
extern "C" IL2CPP_METHOD_ATTR void ToggleFloodFillModeUI_SetMode_m64DE801CCA5251718582F3FC81B83D279BE9F811 (ToggleFloodFillModeUI_tF40BA330FD9EEC86BEA5CD7943EC4599BAD93095 * __this, const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_method (ToggleFloodFillModeUI_SetMode_m64DE801CCA5251718582F3FC81B83D279BE9F811_MetadataUsageId);
		s_Il2CppMethodInitialized = true;
	}
	{
		Toggle_t9ADD572046F831945ED0E48A01B50FEA1CA52106 * L_0 = Component_GetComponent_TisToggle_t9ADD572046F831945ED0E48A01B50FEA1CA52106_m89C4B9EA41130113FE63C1D06704BB4B91AD779B(__this, /*hidden argument*/Component_GetComponent_TisToggle_t9ADD572046F831945ED0E48A01B50FEA1CA52106_m89C4B9EA41130113FE63C1D06704BB4B91AD779B_RuntimeMethod_var);
		NullCheck(L_0);
		bool L_1 = Toggle_get_isOn_mE13D628534F60138373B3E52CC93301DE59DB616(L_0, /*hidden argument*/NULL);
		if (!L_1)
		{
			goto IL_0018;
		}
	}
	{
		MobilePaint_tC25928758E48181B341DE30F410E3EA407D005E5 * L_2 = __this->get_mobilePaint_4();
		NullCheck(L_2);
		MobilePaint_SetDrawModeFill_mAFA44CF5AC92CEDCDC9E962946C292460F5CAF1C(L_2, /*hidden argument*/NULL);
	}

IL_0018:
	{
		return;
	}
}
// System.Void unitycoder_MobilePaint.ToggleFloodFillModeUI::.ctor()
extern "C" IL2CPP_METHOD_ATTR void ToggleFloodFillModeUI__ctor_m29216066C52665D135DE728FDFB8349486A56D0E (ToggleFloodFillModeUI_tF40BA330FD9EEC86BEA5CD7943EC4599BAD93095 * __this, const RuntimeMethod* method)
{
	{
		MonoBehaviour__ctor_mEAEC84B222C60319D593E456D769B3311DFCEF97(__this, /*hidden argument*/NULL);
		return;
	}
}
// System.Void unitycoder_MobilePaint.ToggleFloodFillModeUI::<Start>b__1_0(System.Boolean)
extern "C" IL2CPP_METHOD_ATTR void ToggleFloodFillModeUI_U3CStartU3Eb__1_0_m9AB4739F25B0D0FCBACC931E811631A42A77D865 (ToggleFloodFillModeUI_tF40BA330FD9EEC86BEA5CD7943EC4599BAD93095 * __this, bool ___U3Cp0U3E0, const RuntimeMethod* method)
{
	{
		ToggleFloodFillModeUI_SetMode_m64DE801CCA5251718582F3FC81B83D279BE9F811(__this, /*hidden argument*/NULL);
		return;
	}
}
#ifdef __clang__
#pragma clang diagnostic pop
#endif
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif
// System.Void unitycoder_MobilePaint.ToggleLineModeUI::Start()
extern "C" IL2CPP_METHOD_ATTR void ToggleLineModeUI_Start_mCA708BB155073CF160261F2FA5410E8B3D39B160 (ToggleLineModeUI_tB4F725C4D6DD648C397DB3AC4AAB347EC4AA94C4 * __this, const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_method (ToggleLineModeUI_Start_mCA708BB155073CF160261F2FA5410E8B3D39B160_MetadataUsageId);
		s_Il2CppMethodInitialized = true;
	}
	Toggle_t9ADD572046F831945ED0E48A01B50FEA1CA52106 * G_B4_0 = NULL;
	Toggle_t9ADD572046F831945ED0E48A01B50FEA1CA52106 * G_B3_0 = NULL;
	{
		MobilePaint_tC25928758E48181B341DE30F410E3EA407D005E5 * L_0 = ((PaintManager_t8C7F3BD113E1D28F982A05D0397A369E09266BEE_StaticFields*)il2cpp_codegen_static_fields_for(PaintManager_t8C7F3BD113E1D28F982A05D0397A369E09266BEE_il2cpp_TypeInfo_var))->get_mobilePaint_5();
		__this->set_mobilePaint_4(L_0);
		MobilePaint_tC25928758E48181B341DE30F410E3EA407D005E5 * L_1 = __this->get_mobilePaint_4();
		IL2CPP_RUNTIME_CLASS_INIT(Object_tAE11E5E46CD5C37C9F3E8950C00CD8B45666A2D0_il2cpp_TypeInfo_var);
		bool L_2 = Object_op_Equality_mBC2401774F3BE33E8CF6F0A8148E66C95D6CFF1C(L_1, (Object_tAE11E5E46CD5C37C9F3E8950C00CD8B45666A2D0 *)NULL, /*hidden argument*/NULL);
		if (!L_2)
		{
			goto IL_0039;
		}
	}
	{
		Transform_tBB9E78A2766C3C83599A8F66EDE7D1FCAFC66EDA * L_3 = Component_get_transform_m00F05BD782F920C301A7EBA480F3B7A904C07EC9(__this, /*hidden argument*/NULL);
		NullCheck(L_3);
		String_t* L_4 = Object_get_name_mA2D400141CB3C991C87A2556429781DE961A83CE(L_3, /*hidden argument*/NULL);
		String_t* L_5 = String_Concat_mB78D0094592718DA6D5DB6C712A9C225631666BE(_stringLiteral18D7B45DCCC374DAC64758C817E1917534D16F3F, L_4, /*hidden argument*/NULL);
		GameObject_tBD1244AD56B4E59AAD76E5E7C9282EC5CE434F0F * L_6 = Component_get_gameObject_m0B0570BA8DDD3CD78A9DB568EA18D7317686603C(__this, /*hidden argument*/NULL);
		IL2CPP_RUNTIME_CLASS_INIT(Debug_t7B5FCB117E2FD63B6838BC52821B252E2BFB61C4_il2cpp_TypeInfo_var);
		Debug_LogError_m97139CB2EE76D5CD8308C1AD0499A5F163FC7F51(L_5, L_6, /*hidden argument*/NULL);
	}

IL_0039:
	{
		Toggle_t9ADD572046F831945ED0E48A01B50FEA1CA52106 * L_7 = Component_GetComponent_TisToggle_t9ADD572046F831945ED0E48A01B50FEA1CA52106_m89C4B9EA41130113FE63C1D06704BB4B91AD779B(__this, /*hidden argument*/Component_GetComponent_TisToggle_t9ADD572046F831945ED0E48A01B50FEA1CA52106_m89C4B9EA41130113FE63C1D06704BB4B91AD779B_RuntimeMethod_var);
		Toggle_t9ADD572046F831945ED0E48A01B50FEA1CA52106 * L_8 = L_7;
		IL2CPP_RUNTIME_CLASS_INIT(Object_tAE11E5E46CD5C37C9F3E8950C00CD8B45666A2D0_il2cpp_TypeInfo_var);
		bool L_9 = Object_op_Equality_mBC2401774F3BE33E8CF6F0A8148E66C95D6CFF1C(L_8, (Object_tAE11E5E46CD5C37C9F3E8950C00CD8B45666A2D0 *)NULL, /*hidden argument*/NULL);
		G_B3_0 = L_8;
		if (!L_9)
		{
			G_B4_0 = L_8;
			goto IL_0068;
		}
	}
	{
		Transform_tBB9E78A2766C3C83599A8F66EDE7D1FCAFC66EDA * L_10 = Component_get_transform_m00F05BD782F920C301A7EBA480F3B7A904C07EC9(__this, /*hidden argument*/NULL);
		NullCheck(L_10);
		String_t* L_11 = Object_get_name_mA2D400141CB3C991C87A2556429781DE961A83CE(L_10, /*hidden argument*/NULL);
		String_t* L_12 = String_Concat_mB78D0094592718DA6D5DB6C712A9C225631666BE(_stringLiteralC91A3B0927A7298D2B845FB524A9A00216F7CD7F, L_11, /*hidden argument*/NULL);
		GameObject_tBD1244AD56B4E59AAD76E5E7C9282EC5CE434F0F * L_13 = Component_get_gameObject_m0B0570BA8DDD3CD78A9DB568EA18D7317686603C(__this, /*hidden argument*/NULL);
		IL2CPP_RUNTIME_CLASS_INIT(Debug_t7B5FCB117E2FD63B6838BC52821B252E2BFB61C4_il2cpp_TypeInfo_var);
		Debug_LogError_m97139CB2EE76D5CD8308C1AD0499A5F163FC7F51(L_12, L_13, /*hidden argument*/NULL);
		G_B4_0 = G_B3_0;
	}

IL_0068:
	{
		NullCheck(G_B4_0);
		ToggleEvent_t50D925F8E220FB47DA738411CEF9C57FF7E1DC43 * L_14 = G_B4_0->get_onValueChanged_21();
		UnityAction_1_tB994D127B02789CE2010397AEF756615E5F84FDC * L_15 = (UnityAction_1_tB994D127B02789CE2010397AEF756615E5F84FDC *)il2cpp_codegen_object_new(UnityAction_1_tB994D127B02789CE2010397AEF756615E5F84FDC_il2cpp_TypeInfo_var);
		UnityAction_1__ctor_m846CC5F9F2FD2F58CD1E78E7A4EB55DC5D6CA696(L_15, __this, (intptr_t)((intptr_t)ToggleLineModeUI_U3CStartU3Eb__1_0_m021522DF62D5036FE9A056B7A05262FF7C8D5495_RuntimeMethod_var), /*hidden argument*/UnityAction_1__ctor_m846CC5F9F2FD2F58CD1E78E7A4EB55DC5D6CA696_RuntimeMethod_var);
		NullCheck(L_14);
		UnityEvent_1_AddListener_mBCA646AF6B22F9F8190175F6AFF5195A9BED3FCA(L_14, L_15, /*hidden argument*/UnityEvent_1_AddListener_mBCA646AF6B22F9F8190175F6AFF5195A9BED3FCA_RuntimeMethod_var);
		return;
	}
}
// System.Void unitycoder_MobilePaint.ToggleLineModeUI::SetMode()
extern "C" IL2CPP_METHOD_ATTR void ToggleLineModeUI_SetMode_m2C8B487144B734A99D53DEA0DF9563DEFD1B5979 (ToggleLineModeUI_tB4F725C4D6DD648C397DB3AC4AAB347EC4AA94C4 * __this, const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_method (ToggleLineModeUI_SetMode_m2C8B487144B734A99D53DEA0DF9563DEFD1B5979_MetadataUsageId);
		s_Il2CppMethodInitialized = true;
	}
	{
		Toggle_t9ADD572046F831945ED0E48A01B50FEA1CA52106 * L_0 = Component_GetComponent_TisToggle_t9ADD572046F831945ED0E48A01B50FEA1CA52106_m89C4B9EA41130113FE63C1D06704BB4B91AD779B(__this, /*hidden argument*/Component_GetComponent_TisToggle_t9ADD572046F831945ED0E48A01B50FEA1CA52106_m89C4B9EA41130113FE63C1D06704BB4B91AD779B_RuntimeMethod_var);
		NullCheck(L_0);
		bool L_1 = Toggle_get_isOn_mE13D628534F60138373B3E52CC93301DE59DB616(L_0, /*hidden argument*/NULL);
		if (!L_1)
		{
			goto IL_0018;
		}
	}
	{
		MobilePaint_tC25928758E48181B341DE30F410E3EA407D005E5 * L_2 = __this->get_mobilePaint_4();
		NullCheck(L_2);
		MobilePaint_SetDrawModeLine_mF7D3E255A149F536C56F03AF0923747102446B19(L_2, /*hidden argument*/NULL);
	}

IL_0018:
	{
		return;
	}
}
// System.Void unitycoder_MobilePaint.ToggleLineModeUI::.ctor()
extern "C" IL2CPP_METHOD_ATTR void ToggleLineModeUI__ctor_m14B3E14BDCDF9624BF406BD03AFC8D250DAB805A (ToggleLineModeUI_tB4F725C4D6DD648C397DB3AC4AAB347EC4AA94C4 * __this, const RuntimeMethod* method)
{
	{
		MonoBehaviour__ctor_mEAEC84B222C60319D593E456D769B3311DFCEF97(__this, /*hidden argument*/NULL);
		return;
	}
}
// System.Void unitycoder_MobilePaint.ToggleLineModeUI::<Start>b__1_0(System.Boolean)
extern "C" IL2CPP_METHOD_ATTR void ToggleLineModeUI_U3CStartU3Eb__1_0_m021522DF62D5036FE9A056B7A05262FF7C8D5495 (ToggleLineModeUI_tB4F725C4D6DD648C397DB3AC4AAB347EC4AA94C4 * __this, bool ___U3Cp0U3E0, const RuntimeMethod* method)
{
	{
		ToggleLineModeUI_SetMode_m2C8B487144B734A99D53DEA0DF9563DEFD1B5979(__this, /*hidden argument*/NULL);
		return;
	}
}
#ifdef __clang__
#pragma clang diagnostic pop
#endif
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif
// System.Void unitycoder_MobilePaint.ToggleMode::OnMouseDown()
extern "C" IL2CPP_METHOD_ATTR void ToggleMode_OnMouseDown_mAB5E5E892709DB080A396478C22F5F62AE48838B (ToggleMode_t93881258140C0924B93E76F32A64D736B08607F9 * __this, const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_method (ToggleMode_OnMouseDown_mAB5E5E892709DB080A396478C22F5F62AE48838B_MetadataUsageId);
		s_Il2CppMethodInitialized = true;
	}
	{
		GameObject_tBD1244AD56B4E59AAD76E5E7C9282EC5CE434F0F * L_0 = __this->get_canvas_4();
		NullCheck(L_0);
		MobilePaint_tC25928758E48181B341DE30F410E3EA407D005E5 * L_1 = GameObject_GetComponent_TisMobilePaint_tC25928758E48181B341DE30F410E3EA407D005E5_mEC9B744C4448971CB528E3CFAB3EC41F435E2944(L_0, /*hidden argument*/GameObject_GetComponent_TisMobilePaint_tC25928758E48181B341DE30F410E3EA407D005E5_mEC9B744C4448971CB528E3CFAB3EC41F435E2944_RuntimeMethod_var);
		int32_t L_2 = __this->get_mode_8();
		NullCheck(L_1);
		L_1->set_drawMode_27(L_2);
		GUITexture_t2A2F300B0F9D542DADB532DEC861D1711B5C46F3 * L_3 = Component_GetComponent_TisGUITexture_t2A2F300B0F9D542DADB532DEC861D1711B5C46F3_m8BBADD3541C0470568F03947E759412155A68210(__this, /*hidden argument*/Component_GetComponent_TisGUITexture_t2A2F300B0F9D542DADB532DEC861D1711B5C46F3_m8BBADD3541C0470568F03947E759412155A68210_RuntimeMethod_var);
		Color_t119BCA590009762C7223FDD3AF9706653AC84ED2  L_4;
		memset(&L_4, 0, sizeof(L_4));
		Color__ctor_m20DF490CEB364C4FC36D7EE392640DF5B7420D7C((&L_4), (0.5f), (0.5f), (0.5f), (0.5f), /*hidden argument*/NULL);
		NullCheck(L_3);
		GUITexture_set_color_mD2A5789D387F61060B6CEAE98D5F5DB3D3AF671A(L_3, L_4, /*hidden argument*/NULL);
		GameObject_tBD1244AD56B4E59AAD76E5E7C9282EC5CE434F0F * L_5 = __this->get_otherButton1_5();
		NullCheck(L_5);
		GUITexture_t2A2F300B0F9D542DADB532DEC861D1711B5C46F3 * L_6 = GameObject_GetComponent_TisGUITexture_t2A2F300B0F9D542DADB532DEC861D1711B5C46F3_m100DA46881E26B04E4A5E2906D85B4C3C7A71E94(L_5, /*hidden argument*/GameObject_GetComponent_TisGUITexture_t2A2F300B0F9D542DADB532DEC861D1711B5C46F3_m100DA46881E26B04E4A5E2906D85B4C3C7A71E94_RuntimeMethod_var);
		Color_t119BCA590009762C7223FDD3AF9706653AC84ED2  L_7;
		memset(&L_7, 0, sizeof(L_7));
		Color__ctor_m20DF490CEB364C4FC36D7EE392640DF5B7420D7C((&L_7), (0.25f), (0.25f), (0.25f), (0.5f), /*hidden argument*/NULL);
		NullCheck(L_6);
		GUITexture_set_color_mD2A5789D387F61060B6CEAE98D5F5DB3D3AF671A(L_6, L_7, /*hidden argument*/NULL);
		GameObject_tBD1244AD56B4E59AAD76E5E7C9282EC5CE434F0F * L_8 = __this->get_otherButton2_6();
		NullCheck(L_8);
		GUITexture_t2A2F300B0F9D542DADB532DEC861D1711B5C46F3 * L_9 = GameObject_GetComponent_TisGUITexture_t2A2F300B0F9D542DADB532DEC861D1711B5C46F3_m100DA46881E26B04E4A5E2906D85B4C3C7A71E94(L_8, /*hidden argument*/GameObject_GetComponent_TisGUITexture_t2A2F300B0F9D542DADB532DEC861D1711B5C46F3_m100DA46881E26B04E4A5E2906D85B4C3C7A71E94_RuntimeMethod_var);
		Color_t119BCA590009762C7223FDD3AF9706653AC84ED2  L_10;
		memset(&L_10, 0, sizeof(L_10));
		Color__ctor_m20DF490CEB364C4FC36D7EE392640DF5B7420D7C((&L_10), (0.25f), (0.25f), (0.25f), (0.5f), /*hidden argument*/NULL);
		NullCheck(L_9);
		GUITexture_set_color_mD2A5789D387F61060B6CEAE98D5F5DB3D3AF671A(L_9, L_10, /*hidden argument*/NULL);
		int32_t L_11 = __this->get_mode_8();
		if (!L_11)
		{
			goto IL_00bf;
		}
	}
	{
		GameObject_tBD1244AD56B4E59AAD76E5E7C9282EC5CE434F0F * L_12 = __this->get_sizeGUI1_7();
		NullCheck(L_12);
		GUITexture_t2A2F300B0F9D542DADB532DEC861D1711B5C46F3 * L_13 = GameObject_GetComponent_TisGUITexture_t2A2F300B0F9D542DADB532DEC861D1711B5C46F3_m100DA46881E26B04E4A5E2906D85B4C3C7A71E94(L_12, /*hidden argument*/GameObject_GetComponent_TisGUITexture_t2A2F300B0F9D542DADB532DEC861D1711B5C46F3_m100DA46881E26B04E4A5E2906D85B4C3C7A71E94_RuntimeMethod_var);
		Color_t119BCA590009762C7223FDD3AF9706653AC84ED2  L_14;
		memset(&L_14, 0, sizeof(L_14));
		Color__ctor_m20DF490CEB364C4FC36D7EE392640DF5B7420D7C((&L_14), (0.25f), (0.25f), (0.25f), (0.5f), /*hidden argument*/NULL);
		NullCheck(L_13);
		GUITexture_set_color_mD2A5789D387F61060B6CEAE98D5F5DB3D3AF671A(L_13, L_14, /*hidden argument*/NULL);
		goto IL_00e8;
	}

IL_00bf:
	{
		GameObject_tBD1244AD56B4E59AAD76E5E7C9282EC5CE434F0F * L_15 = __this->get_sizeGUI1_7();
		NullCheck(L_15);
		GUITexture_t2A2F300B0F9D542DADB532DEC861D1711B5C46F3 * L_16 = GameObject_GetComponent_TisGUITexture_t2A2F300B0F9D542DADB532DEC861D1711B5C46F3_m100DA46881E26B04E4A5E2906D85B4C3C7A71E94(L_15, /*hidden argument*/GameObject_GetComponent_TisGUITexture_t2A2F300B0F9D542DADB532DEC861D1711B5C46F3_m100DA46881E26B04E4A5E2906D85B4C3C7A71E94_RuntimeMethod_var);
		Color_t119BCA590009762C7223FDD3AF9706653AC84ED2  L_17;
		memset(&L_17, 0, sizeof(L_17));
		Color__ctor_m20DF490CEB364C4FC36D7EE392640DF5B7420D7C((&L_17), (0.5f), (0.5f), (0.5f), (0.5f), /*hidden argument*/NULL);
		NullCheck(L_16);
		GUITexture_set_color_mD2A5789D387F61060B6CEAE98D5F5DB3D3AF671A(L_16, L_17, /*hidden argument*/NULL);
	}

IL_00e8:
	{
		GameObject_tBD1244AD56B4E59AAD76E5E7C9282EC5CE434F0F * L_18 = __this->get_sizeGUI1_7();
		GameObject_tBD1244AD56B4E59AAD76E5E7C9282EC5CE434F0F * L_19 = __this->get_sizeGUI1_7();
		NullCheck(L_19);
		int32_t L_20 = GameObject_get_layer_m0DE90D8A3D3AA80497A3A80FBEAC2D207C16B9C8(L_19, /*hidden argument*/NULL);
		NullCheck(L_18);
		GameObject_set_layer_mDAC8037FCFD0CE62DB66004C4342EA20CF604907(L_18, ((int32_t)il2cpp_codegen_subtract((int32_t)2, (int32_t)L_20)), /*hidden argument*/NULL);
		return;
	}
}
// System.Void unitycoder_MobilePaint.ToggleMode::.ctor()
extern "C" IL2CPP_METHOD_ATTR void ToggleMode__ctor_m36E541FA8ACA03BB3F1CA8D4B9CED1E0B8C3FA70 (ToggleMode_t93881258140C0924B93E76F32A64D736B08607F9 * __this, const RuntimeMethod* method)
{
	{
		MonoBehaviour__ctor_mEAEC84B222C60319D593E456D769B3311DFCEF97(__this, /*hidden argument*/NULL);
		return;
	}
}
#ifdef __clang__
#pragma clang diagnostic pop
#endif
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif
// System.Void unitycoder_MobilePaint.TogglePanZoomModeUI::Start()
extern "C" IL2CPP_METHOD_ATTR void TogglePanZoomModeUI_Start_m5EC187CE56087FBFDAD3C391C6E1AE7083DEDB7E (TogglePanZoomModeUI_t7EA98A500D67F4E63FCA50307325D99362E30F00 * __this, const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_method (TogglePanZoomModeUI_Start_m5EC187CE56087FBFDAD3C391C6E1AE7083DEDB7E_MetadataUsageId);
		s_Il2CppMethodInitialized = true;
	}
	{
		MobilePaint_tC25928758E48181B341DE30F410E3EA407D005E5 * L_0 = ((PaintManager_t8C7F3BD113E1D28F982A05D0397A369E09266BEE_StaticFields*)il2cpp_codegen_static_fields_for(PaintManager_t8C7F3BD113E1D28F982A05D0397A369E09266BEE_il2cpp_TypeInfo_var))->get_mobilePaint_5();
		__this->set_mobilePaint_4(L_0);
		MobilePaint_tC25928758E48181B341DE30F410E3EA407D005E5 * L_1 = __this->get_mobilePaint_4();
		IL2CPP_RUNTIME_CLASS_INIT(Object_tAE11E5E46CD5C37C9F3E8950C00CD8B45666A2D0_il2cpp_TypeInfo_var);
		bool L_2 = Object_op_Equality_mBC2401774F3BE33E8CF6F0A8148E66C95D6CFF1C(L_1, (Object_tAE11E5E46CD5C37C9F3E8950C00CD8B45666A2D0 *)NULL, /*hidden argument*/NULL);
		if (!L_2)
		{
			goto IL_0039;
		}
	}
	{
		Transform_tBB9E78A2766C3C83599A8F66EDE7D1FCAFC66EDA * L_3 = Component_get_transform_m00F05BD782F920C301A7EBA480F3B7A904C07EC9(__this, /*hidden argument*/NULL);
		NullCheck(L_3);
		String_t* L_4 = Object_get_name_mA2D400141CB3C991C87A2556429781DE961A83CE(L_3, /*hidden argument*/NULL);
		String_t* L_5 = String_Concat_mB78D0094592718DA6D5DB6C712A9C225631666BE(_stringLiteral18D7B45DCCC374DAC64758C817E1917534D16F3F, L_4, /*hidden argument*/NULL);
		GameObject_tBD1244AD56B4E59AAD76E5E7C9282EC5CE434F0F * L_6 = Component_get_gameObject_m0B0570BA8DDD3CD78A9DB568EA18D7317686603C(__this, /*hidden argument*/NULL);
		IL2CPP_RUNTIME_CLASS_INIT(Debug_t7B5FCB117E2FD63B6838BC52821B252E2BFB61C4_il2cpp_TypeInfo_var);
		Debug_LogError_m97139CB2EE76D5CD8308C1AD0499A5F163FC7F51(L_5, L_6, /*hidden argument*/NULL);
	}

IL_0039:
	{
		Toggle_t9ADD572046F831945ED0E48A01B50FEA1CA52106 * L_7 = Component_GetComponent_TisToggle_t9ADD572046F831945ED0E48A01B50FEA1CA52106_m89C4B9EA41130113FE63C1D06704BB4B91AD779B(__this, /*hidden argument*/Component_GetComponent_TisToggle_t9ADD572046F831945ED0E48A01B50FEA1CA52106_m89C4B9EA41130113FE63C1D06704BB4B91AD779B_RuntimeMethod_var);
		NullCheck(L_7);
		ToggleEvent_t50D925F8E220FB47DA738411CEF9C57FF7E1DC43 * L_8 = L_7->get_onValueChanged_21();
		UnityAction_1_tB994D127B02789CE2010397AEF756615E5F84FDC * L_9 = (UnityAction_1_tB994D127B02789CE2010397AEF756615E5F84FDC *)il2cpp_codegen_object_new(UnityAction_1_tB994D127B02789CE2010397AEF756615E5F84FDC_il2cpp_TypeInfo_var);
		UnityAction_1__ctor_m846CC5F9F2FD2F58CD1E78E7A4EB55DC5D6CA696(L_9, __this, (intptr_t)((intptr_t)TogglePanZoomModeUI_U3CStartU3Eb__1_0_m46CBE507BE800CCE3438034C32DAA0B562214D7D_RuntimeMethod_var), /*hidden argument*/UnityAction_1__ctor_m846CC5F9F2FD2F58CD1E78E7A4EB55DC5D6CA696_RuntimeMethod_var);
		NullCheck(L_8);
		UnityEvent_1_AddListener_mBCA646AF6B22F9F8190175F6AFF5195A9BED3FCA(L_8, L_9, /*hidden argument*/UnityEvent_1_AddListener_mBCA646AF6B22F9F8190175F6AFF5195A9BED3FCA_RuntimeMethod_var);
		return;
	}
}
// System.Void unitycoder_MobilePaint.TogglePanZoomModeUI::ToggleZoomPan()
extern "C" IL2CPP_METHOD_ATTR void TogglePanZoomModeUI_ToggleZoomPan_m5C400FF51681E0C0ED6EAFE6CD7FFC000A2D8D81 (TogglePanZoomModeUI_t7EA98A500D67F4E63FCA50307325D99362E30F00 * __this, const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_method (TogglePanZoomModeUI_ToggleZoomPan_m5C400FF51681E0C0ED6EAFE6CD7FFC000A2D8D81_MetadataUsageId);
		s_Il2CppMethodInitialized = true;
	}
	{
		MobilePaint_tC25928758E48181B341DE30F410E3EA407D005E5 * L_0 = __this->get_mobilePaint_4();
		Toggle_t9ADD572046F831945ED0E48A01B50FEA1CA52106 * L_1 = Component_GetComponent_TisToggle_t9ADD572046F831945ED0E48A01B50FEA1CA52106_m89C4B9EA41130113FE63C1D06704BB4B91AD779B(__this, /*hidden argument*/Component_GetComponent_TisToggle_t9ADD572046F831945ED0E48A01B50FEA1CA52106_m89C4B9EA41130113FE63C1D06704BB4B91AD779B_RuntimeMethod_var);
		NullCheck(L_1);
		bool L_2 = Toggle_get_isOn_mE13D628534F60138373B3E52CC93301DE59DB616(L_1, /*hidden argument*/NULL);
		NullCheck(L_0);
		MobilePaint_SetPanZoomMode_m7ED4BE8EECC07D14299CAAAFEE2655C3782CA9DA(L_0, L_2, /*hidden argument*/NULL);
		return;
	}
}
// System.Void unitycoder_MobilePaint.TogglePanZoomModeUI::.ctor()
extern "C" IL2CPP_METHOD_ATTR void TogglePanZoomModeUI__ctor_mAF12C51E34DA3D53D82035DD86F0CF1BD193AC57 (TogglePanZoomModeUI_t7EA98A500D67F4E63FCA50307325D99362E30F00 * __this, const RuntimeMethod* method)
{
	{
		MonoBehaviour__ctor_mEAEC84B222C60319D593E456D769B3311DFCEF97(__this, /*hidden argument*/NULL);
		return;
	}
}
// System.Void unitycoder_MobilePaint.TogglePanZoomModeUI::<Start>b__1_0(System.Boolean)
extern "C" IL2CPP_METHOD_ATTR void TogglePanZoomModeUI_U3CStartU3Eb__1_0_m46CBE507BE800CCE3438034C32DAA0B562214D7D (TogglePanZoomModeUI_t7EA98A500D67F4E63FCA50307325D99362E30F00 * __this, bool ___U3Cp0U3E0, const RuntimeMethod* method)
{
	{
		TogglePanZoomModeUI_ToggleZoomPan_m5C400FF51681E0C0ED6EAFE6CD7FFC000A2D8D81(__this, /*hidden argument*/NULL);
		return;
	}
}
#ifdef __clang__
#pragma clang diagnostic pop
#endif
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif
// System.Void unitycoder_MobilePaint_samples.GUIScaler::Awake()
extern "C" IL2CPP_METHOD_ATTR void GUIScaler_Awake_mF7325223C09C36114F1439CC72664B4DDF407EAC (GUIScaler_t6D470D8BFC2F4807DA1811C43EB35472B4D0C13F * __this, const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_method (GUIScaler_Awake_mF7325223C09C36114F1439CC72664B4DDF407EAC_MetadataUsageId);
		s_Il2CppMethodInitialized = true;
	}
	float V_0 = 0.0f;
	float V_1 = 0.0f;
	GUITexture_t2A2F300B0F9D542DADB532DEC861D1711B5C46F3 * V_2 = NULL;
	Rect_t35B976DE901B5423C11705E156938EA27AB402CE  V_3;
	memset(&V_3, 0, sizeof(V_3));
	{
		V_0 = (0.00208333344f);
		int32_t L_0 = Screen_get_height_mF5B64EBC4CDE0EAAA5713C1452ED2CE475F25150(/*hidden argument*/NULL);
		float L_1 = V_0;
		float L_2 = __this->get_scaleAdjust_4();
		V_1 = ((float)il2cpp_codegen_multiply((float)((float)il2cpp_codegen_multiply((float)(((float)((float)L_0))), (float)L_1)), (float)L_2));
		GUITexture_t2A2F300B0F9D542DADB532DEC861D1711B5C46F3 * L_3 = Component_GetComponent_TisGUITexture_t2A2F300B0F9D542DADB532DEC861D1711B5C46F3_m8BBADD3541C0470568F03947E759412155A68210(__this, /*hidden argument*/Component_GetComponent_TisGUITexture_t2A2F300B0F9D542DADB532DEC861D1711B5C46F3_m8BBADD3541C0470568F03947E759412155A68210_RuntimeMethod_var);
		IL2CPP_RUNTIME_CLASS_INIT(Object_tAE11E5E46CD5C37C9F3E8950C00CD8B45666A2D0_il2cpp_TypeInfo_var);
		bool L_4 = Object_op_Inequality_m31EF58E217E8F4BDD3E409DEF79E1AEE95874FC1(L_3, (Object_tAE11E5E46CD5C37C9F3E8950C00CD8B45666A2D0 *)NULL, /*hidden argument*/NULL);
		if (!L_4)
		{
			goto IL_0078;
		}
	}
	{
		GUITexture_t2A2F300B0F9D542DADB532DEC861D1711B5C46F3 * L_5 = Component_GetComponent_TisGUITexture_t2A2F300B0F9D542DADB532DEC861D1711B5C46F3_m8BBADD3541C0470568F03947E759412155A68210(__this, /*hidden argument*/Component_GetComponent_TisGUITexture_t2A2F300B0F9D542DADB532DEC861D1711B5C46F3_m8BBADD3541C0470568F03947E759412155A68210_RuntimeMethod_var);
		V_2 = L_5;
		GUITexture_t2A2F300B0F9D542DADB532DEC861D1711B5C46F3 * L_6 = V_2;
		GUITexture_t2A2F300B0F9D542DADB532DEC861D1711B5C46F3 * L_7 = V_2;
		NullCheck(L_7);
		Rect_t35B976DE901B5423C11705E156938EA27AB402CE  L_8 = GUITexture_get_pixelInset_m566DB8F4EB5F0BB244A6C27C56B2A9B9E33479F3(L_7, /*hidden argument*/NULL);
		V_3 = L_8;
		float L_9 = Rect_get_x_mC51A461F546D14832EB96B11A7198DADDE2597B7((Rect_t35B976DE901B5423C11705E156938EA27AB402CE *)(&V_3), /*hidden argument*/NULL);
		float L_10 = V_1;
		GUITexture_t2A2F300B0F9D542DADB532DEC861D1711B5C46F3 * L_11 = V_2;
		NullCheck(L_11);
		Rect_t35B976DE901B5423C11705E156938EA27AB402CE  L_12 = GUITexture_get_pixelInset_m566DB8F4EB5F0BB244A6C27C56B2A9B9E33479F3(L_11, /*hidden argument*/NULL);
		V_3 = L_12;
		float L_13 = Rect_get_y_m53E3E4F62D9840FBEA751A66293038F1F5D1D45C((Rect_t35B976DE901B5423C11705E156938EA27AB402CE *)(&V_3), /*hidden argument*/NULL);
		float L_14 = V_1;
		GUITexture_t2A2F300B0F9D542DADB532DEC861D1711B5C46F3 * L_15 = V_2;
		NullCheck(L_15);
		Rect_t35B976DE901B5423C11705E156938EA27AB402CE  L_16 = GUITexture_get_pixelInset_m566DB8F4EB5F0BB244A6C27C56B2A9B9E33479F3(L_15, /*hidden argument*/NULL);
		V_3 = L_16;
		float L_17 = Rect_get_width_m54FF69FC2C086E2DC349ED091FD0D6576BFB1484((Rect_t35B976DE901B5423C11705E156938EA27AB402CE *)(&V_3), /*hidden argument*/NULL);
		float L_18 = V_1;
		GUITexture_t2A2F300B0F9D542DADB532DEC861D1711B5C46F3 * L_19 = V_2;
		NullCheck(L_19);
		Rect_t35B976DE901B5423C11705E156938EA27AB402CE  L_20 = GUITexture_get_pixelInset_m566DB8F4EB5F0BB244A6C27C56B2A9B9E33479F3(L_19, /*hidden argument*/NULL);
		V_3 = L_20;
		float L_21 = Rect_get_height_m088C36990E0A255C5D7DCE36575DCE23ABB364B5((Rect_t35B976DE901B5423C11705E156938EA27AB402CE *)(&V_3), /*hidden argument*/NULL);
		float L_22 = V_1;
		Rect_t35B976DE901B5423C11705E156938EA27AB402CE  L_23;
		memset(&L_23, 0, sizeof(L_23));
		Rect__ctor_m50B92C75005C9C5A0D05E6E0EBB43AFAF7C66280((&L_23), ((float)il2cpp_codegen_multiply((float)L_9, (float)L_10)), ((float)il2cpp_codegen_multiply((float)L_13, (float)L_14)), ((float)il2cpp_codegen_multiply((float)L_17, (float)L_18)), ((float)il2cpp_codegen_multiply((float)L_21, (float)L_22)), /*hidden argument*/NULL);
		NullCheck(L_6);
		GUITexture_set_pixelInset_m8BFE100732874F03A136E1267124DEE2D50B32AD(L_6, L_23, /*hidden argument*/NULL);
		goto IL_00d4;
	}

IL_0078:
	{
		GUIText_t1AAED515CF7E63F24B55C5FC988555DA14DA10F1 * L_24 = Component_GetComponent_TisGUIText_t1AAED515CF7E63F24B55C5FC988555DA14DA10F1_m051AF02F5332F75F23DAD7A0E8AFA3DC70A92E62(__this, /*hidden argument*/Component_GetComponent_TisGUIText_t1AAED515CF7E63F24B55C5FC988555DA14DA10F1_m051AF02F5332F75F23DAD7A0E8AFA3DC70A92E62_RuntimeMethod_var);
		IL2CPP_RUNTIME_CLASS_INIT(Object_tAE11E5E46CD5C37C9F3E8950C00CD8B45666A2D0_il2cpp_TypeInfo_var);
		bool L_25 = Object_op_Inequality_m31EF58E217E8F4BDD3E409DEF79E1AEE95874FC1(L_24, (Object_tAE11E5E46CD5C37C9F3E8950C00CD8B45666A2D0 *)NULL, /*hidden argument*/NULL);
		if (!L_25)
		{
			goto IL_00d4;
		}
	}
	{
		GUIText_t1AAED515CF7E63F24B55C5FC988555DA14DA10F1 * L_26 = Component_GetComponent_TisGUIText_t1AAED515CF7E63F24B55C5FC988555DA14DA10F1_m051AF02F5332F75F23DAD7A0E8AFA3DC70A92E62(__this, /*hidden argument*/Component_GetComponent_TisGUIText_t1AAED515CF7E63F24B55C5FC988555DA14DA10F1_m051AF02F5332F75F23DAD7A0E8AFA3DC70A92E62_RuntimeMethod_var);
		GUIText_t1AAED515CF7E63F24B55C5FC988555DA14DA10F1 * L_27 = Component_GetComponent_TisGUIText_t1AAED515CF7E63F24B55C5FC988555DA14DA10F1_m051AF02F5332F75F23DAD7A0E8AFA3DC70A92E62(__this, /*hidden argument*/Component_GetComponent_TisGUIText_t1AAED515CF7E63F24B55C5FC988555DA14DA10F1_m051AF02F5332F75F23DAD7A0E8AFA3DC70A92E62_RuntimeMethod_var);
		NullCheck(L_27);
		Vector2_tA85D2DD88578276CA8A8796756458277E72D073D  L_28 = GUIText_get_pixelOffset_m7EF7D59B5CCB113AA0476B7B5FDF7A75363D4C24(L_27, /*hidden argument*/NULL);
		float L_29 = L_28.get_x_0();
		float L_30 = V_1;
		GUIText_t1AAED515CF7E63F24B55C5FC988555DA14DA10F1 * L_31 = Component_GetComponent_TisGUIText_t1AAED515CF7E63F24B55C5FC988555DA14DA10F1_m051AF02F5332F75F23DAD7A0E8AFA3DC70A92E62(__this, /*hidden argument*/Component_GetComponent_TisGUIText_t1AAED515CF7E63F24B55C5FC988555DA14DA10F1_m051AF02F5332F75F23DAD7A0E8AFA3DC70A92E62_RuntimeMethod_var);
		NullCheck(L_31);
		Vector2_tA85D2DD88578276CA8A8796756458277E72D073D  L_32 = GUIText_get_pixelOffset_m7EF7D59B5CCB113AA0476B7B5FDF7A75363D4C24(L_31, /*hidden argument*/NULL);
		float L_33 = L_32.get_y_1();
		float L_34 = V_1;
		Vector2_tA85D2DD88578276CA8A8796756458277E72D073D  L_35;
		memset(&L_35, 0, sizeof(L_35));
		Vector2__ctor_mEE8FB117AB1F8DB746FB8B3EB4C0DA3BF2A230D0((&L_35), ((float)il2cpp_codegen_multiply((float)L_29, (float)L_30)), ((float)il2cpp_codegen_multiply((float)L_33, (float)L_34)), /*hidden argument*/NULL);
		NullCheck(L_26);
		GUIText_set_pixelOffset_m698D3D598BDBA9C58795F151994796B1C8BC5852(L_26, L_35, /*hidden argument*/NULL);
		GUIText_t1AAED515CF7E63F24B55C5FC988555DA14DA10F1 * L_36 = Component_GetComponent_TisGUIText_t1AAED515CF7E63F24B55C5FC988555DA14DA10F1_m051AF02F5332F75F23DAD7A0E8AFA3DC70A92E62(__this, /*hidden argument*/Component_GetComponent_TisGUIText_t1AAED515CF7E63F24B55C5FC988555DA14DA10F1_m051AF02F5332F75F23DAD7A0E8AFA3DC70A92E62_RuntimeMethod_var);
		GUIText_t1AAED515CF7E63F24B55C5FC988555DA14DA10F1 * L_37 = Component_GetComponent_TisGUIText_t1AAED515CF7E63F24B55C5FC988555DA14DA10F1_m051AF02F5332F75F23DAD7A0E8AFA3DC70A92E62(__this, /*hidden argument*/Component_GetComponent_TisGUIText_t1AAED515CF7E63F24B55C5FC988555DA14DA10F1_m051AF02F5332F75F23DAD7A0E8AFA3DC70A92E62_RuntimeMethod_var);
		NullCheck(L_37);
		int32_t L_38 = GUIText_get_fontSize_mB51DAB2EF493D7EA932EEC731603B4F0867F0F46(L_37, /*hidden argument*/NULL);
		float L_39 = V_1;
		NullCheck(L_36);
		GUIText_set_fontSize_m1DD22870196D29901BD5B7691C6782E472A85FEC(L_36, (((int32_t)((int32_t)((float)il2cpp_codegen_multiply((float)(((float)((float)L_38))), (float)L_39))))), /*hidden argument*/NULL);
	}

IL_00d4:
	{
		IL2CPP_RUNTIME_CLASS_INIT(Object_tAE11E5E46CD5C37C9F3E8950C00CD8B45666A2D0_il2cpp_TypeInfo_var);
		Object_Destroy_m23B4562495BA35A74266D4372D45368F8C05109A(__this, /*hidden argument*/NULL);
		return;
	}
}
// System.Void unitycoder_MobilePaint_samples.GUIScaler::.ctor()
extern "C" IL2CPP_METHOD_ATTR void GUIScaler__ctor_mE78DBDE319555BE5F3A34B52B450F73D0B48B5ED (GUIScaler_t6D470D8BFC2F4807DA1811C43EB35472B4D0C13F * __this, const RuntimeMethod* method)
{
	{
		__this->set_scaleAdjust_4((1.0f));
		MonoBehaviour__ctor_mEAEC84B222C60319D593E456D769B3311DFCEF97(__this, /*hidden argument*/NULL);
		return;
	}
}
#ifdef __clang__
#pragma clang diagnostic pop
#endif
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif
// System.Void unitycoder_MobilePaint_samples.LoadImageFromDisk::Start()
extern "C" IL2CPP_METHOD_ATTR void LoadImageFromDisk_Start_m59F8793B7043932EA36CBA5D37E499FD1A8CCEFF (LoadImageFromDisk_t25E1AF3A9B41761AA5B2368589B30DE107BB0DFD * __this, const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_method (LoadImageFromDisk_Start_m59F8793B7043932EA36CBA5D37E499FD1A8CCEFF_MetadataUsageId);
		s_Il2CppMethodInitialized = true;
	}
	{
		MobilePaint_tC25928758E48181B341DE30F410E3EA407D005E5 * L_0 = ((PaintManager_t8C7F3BD113E1D28F982A05D0397A369E09266BEE_StaticFields*)il2cpp_codegen_static_fields_for(PaintManager_t8C7F3BD113E1D28F982A05D0397A369E09266BEE_il2cpp_TypeInfo_var))->get_mobilePaint_5();
		__this->set_mobilePaint_4(L_0);
		return;
	}
}
// System.Void unitycoder_MobilePaint_samples.LoadImageFromDisk::Update()
extern "C" IL2CPP_METHOD_ATTR void LoadImageFromDisk_Update_mE7A6B6FE5C7D4D4DF485FF5A7C01B6C2F26F581A (LoadImageFromDisk_t25E1AF3A9B41761AA5B2368589B30DE107BB0DFD * __this, const RuntimeMethod* method)
{
	{
		int32_t L_0 = __this->get_loadFileKey_5();
		bool L_1 = Input_GetKeyDown_mD82B14BB87E1C811668BD1A2CFBC0CF3D4983FEA(L_0, /*hidden argument*/NULL);
		if (!L_1)
		{
			goto IL_0013;
		}
	}
	{
		LoadImageFromDisk_LoadImageAsCanvas_m14529C87F9A3E52E4E057DCC3AE2FA5A543C965B(__this, /*hidden argument*/NULL);
	}

IL_0013:
	{
		return;
	}
}
// System.Void unitycoder_MobilePaint_samples.LoadImageFromDisk::LoadImageAsCanvas()
extern "C" IL2CPP_METHOD_ATTR void LoadImageFromDisk_LoadImageAsCanvas_m14529C87F9A3E52E4E057DCC3AE2FA5A543C965B (LoadImageFromDisk_t25E1AF3A9B41761AA5B2368589B30DE107BB0DFD * __this, const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_method (LoadImageFromDisk_LoadImageAsCanvas_m14529C87F9A3E52E4E057DCC3AE2FA5A543C965B_MetadataUsageId);
		s_Il2CppMethodInitialized = true;
	}
	ByteU5BU5D_tD06FDBE8142446525DF1C40351D523A228373821* V_0 = NULL;
	Texture2D_tBBF96AC337723E2EF156DF17E09D4379FD05DE1C * V_1 = NULL;
	{
		String_t* L_0 = Application_get_dataPath_m33D721D71C0687F0013C8953FDB0807B7B3F2A01(/*hidden argument*/NULL);
		String_t* L_1 = __this->get_imageFolder_6();
		String_t* L_2 = String_Concat_mF4626905368D6558695A823466A1AF65EADB9923(L_0, _stringLiteral42099B4AF021E53FD8FD4E056C2568D7C2E3FFA8, L_1, /*hidden argument*/NULL);
		ByteU5BU5D_tD06FDBE8142446525DF1C40351D523A228373821* L_3 = File_ReadAllBytes_mF29468CED0B7B3B7C0971ACEBB16A38683718BEC(L_2, /*hidden argument*/NULL);
		V_0 = L_3;
		Texture2D_tBBF96AC337723E2EF156DF17E09D4379FD05DE1C * L_4 = (Texture2D_tBBF96AC337723E2EF156DF17E09D4379FD05DE1C *)il2cpp_codegen_object_new(Texture2D_tBBF96AC337723E2EF156DF17E09D4379FD05DE1C_il2cpp_TypeInfo_var);
		Texture2D__ctor_m0C86A87871AA8075791EF98499D34DA95ACB0E35(L_4, 2, 2, /*hidden argument*/NULL);
		V_1 = L_4;
		Texture2D_tBBF96AC337723E2EF156DF17E09D4379FD05DE1C * L_5 = V_1;
		ByteU5BU5D_tD06FDBE8142446525DF1C40351D523A228373821* L_6 = V_0;
		ImageConversion_LoadImage_m94295492E96C38984406A23CC2A3931758ECE86B(L_5, L_6, /*hidden argument*/NULL);
		MobilePaint_tC25928758E48181B341DE30F410E3EA407D005E5 * L_7 = __this->get_mobilePaint_4();
		Texture2D_tBBF96AC337723E2EF156DF17E09D4379FD05DE1C * L_8 = V_1;
		NullCheck(L_7);
		MobilePaint_SetCanvasImage_mD9FB8536EE50E16FC25A827A84DCF2B3A6FB5D9C(L_7, L_8, /*hidden argument*/NULL);
		return;
	}
}
// System.Void unitycoder_MobilePaint_samples.LoadImageFromDisk::.ctor()
extern "C" IL2CPP_METHOD_ATTR void LoadImageFromDisk__ctor_m7F09557FF989BF261ED0BC85C6835B9B6D0F61BA (LoadImageFromDisk_t25E1AF3A9B41761AA5B2368589B30DE107BB0DFD * __this, const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_method (LoadImageFromDisk__ctor_m7F09557FF989BF261ED0BC85C6835B9B6D0F61BA_MetadataUsageId);
		s_Il2CppMethodInitialized = true;
	}
	{
		__this->set_loadFileKey_5(((int32_t)290));
		__this->set_imageFolder_6(_stringLiteralA2C598E208B87F5295AAA4420CC533C4028BE345);
		MonoBehaviour__ctor_mEAEC84B222C60319D593E456D769B3311DFCEF97(__this, /*hidden argument*/NULL);
		return;
	}
}
#ifdef __clang__
#pragma clang diagnostic pop
#endif
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif
// System.Collections.IEnumerator unitycoder_MobilePaint_samples.LoadTextureFromWeb::Start()
extern "C" IL2CPP_METHOD_ATTR RuntimeObject* LoadTextureFromWeb_Start_mF463CA246EEB425450E0D50A89468619102E1F68 (LoadTextureFromWeb_tFC746A6E41B9DB9A0D76CE18D58637FA36CA3F18 * __this, const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_method (LoadTextureFromWeb_Start_mF463CA246EEB425450E0D50A89468619102E1F68_MetadataUsageId);
		s_Il2CppMethodInitialized = true;
	}
	{
		U3CStartU3Ed__2_tEC4FB974F881789E25ED33C9CC1420A5662BF176 * L_0 = (U3CStartU3Ed__2_tEC4FB974F881789E25ED33C9CC1420A5662BF176 *)il2cpp_codegen_object_new(U3CStartU3Ed__2_tEC4FB974F881789E25ED33C9CC1420A5662BF176_il2cpp_TypeInfo_var);
		U3CStartU3Ed__2__ctor_m4C7368BC8363DB4492742CA6276F09D9099144E7(L_0, 0, /*hidden argument*/NULL);
		U3CStartU3Ed__2_tEC4FB974F881789E25ED33C9CC1420A5662BF176 * L_1 = L_0;
		NullCheck(L_1);
		L_1->set_U3CU3E4__this_2(__this);
		return L_1;
	}
}
// System.Void unitycoder_MobilePaint_samples.LoadTextureFromWeb::.ctor()
extern "C" IL2CPP_METHOD_ATTR void LoadTextureFromWeb__ctor_m86E12CD93A8D0041C153347DC90AB5C880479C91 (LoadTextureFromWeb_tFC746A6E41B9DB9A0D76CE18D58637FA36CA3F18 * __this, const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_method (LoadTextureFromWeb__ctor_m86E12CD93A8D0041C153347DC90AB5C880479C91_MetadataUsageId);
		s_Il2CppMethodInitialized = true;
	}
	{
		__this->set_url_5(_stringLiteral87D0177B26480EC93071EC19F377958DE8FCF405);
		MonoBehaviour__ctor_mEAEC84B222C60319D593E456D769B3311DFCEF97(__this, /*hidden argument*/NULL);
		return;
	}
}
#ifdef __clang__
#pragma clang diagnostic pop
#endif
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif
// System.Void unitycoder_MobilePaint_samples.LoadTextureFromWeb/<Start>d__2::.ctor(System.Int32)
extern "C" IL2CPP_METHOD_ATTR void U3CStartU3Ed__2__ctor_m4C7368BC8363DB4492742CA6276F09D9099144E7 (U3CStartU3Ed__2_tEC4FB974F881789E25ED33C9CC1420A5662BF176 * __this, int32_t ___U3CU3E1__state0, const RuntimeMethod* method)
{
	{
		Object__ctor_m925ECA5E85CA100E3FB86A4F9E15C120E9A184C0(__this, /*hidden argument*/NULL);
		int32_t L_0 = ___U3CU3E1__state0;
		__this->set_U3CU3E1__state_0(L_0);
		return;
	}
}
// System.Void unitycoder_MobilePaint_samples.LoadTextureFromWeb/<Start>d__2::System.IDisposable.Dispose()
extern "C" IL2CPP_METHOD_ATTR void U3CStartU3Ed__2_System_IDisposable_Dispose_m28FAD8E170BA51F56E60DEC08183953C2C4711B5 (U3CStartU3Ed__2_tEC4FB974F881789E25ED33C9CC1420A5662BF176 * __this, const RuntimeMethod* method)
{
	{
		return;
	}
}
// System.Boolean unitycoder_MobilePaint_samples.LoadTextureFromWeb/<Start>d__2::MoveNext()
extern "C" IL2CPP_METHOD_ATTR bool U3CStartU3Ed__2_MoveNext_m8F0E7A6565076AFD1B0EBFCEF0A2E96BBBA5DEA9 (U3CStartU3Ed__2_tEC4FB974F881789E25ED33C9CC1420A5662BF176 * __this, const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_method (U3CStartU3Ed__2_MoveNext_m8F0E7A6565076AFD1B0EBFCEF0A2E96BBBA5DEA9_MetadataUsageId);
		s_Il2CppMethodInitialized = true;
	}
	int32_t V_0 = 0;
	LoadTextureFromWeb_tFC746A6E41B9DB9A0D76CE18D58637FA36CA3F18 * V_1 = NULL;
	{
		int32_t L_0 = __this->get_U3CU3E1__state_0();
		V_0 = L_0;
		LoadTextureFromWeb_tFC746A6E41B9DB9A0D76CE18D58637FA36CA3F18 * L_1 = __this->get_U3CU3E4__this_2();
		V_1 = L_1;
		int32_t L_2 = V_0;
		if (!L_2)
		{
			goto IL_0017;
		}
	}
	{
		int32_t L_3 = V_0;
		if ((((int32_t)L_3) == ((int32_t)1)))
		{
			goto IL_004f;
		}
	}
	{
		return (bool)0;
	}

IL_0017:
	{
		__this->set_U3CU3E1__state_0((-1));
		LoadTextureFromWeb_tFC746A6E41B9DB9A0D76CE18D58637FA36CA3F18 * L_4 = V_1;
		MobilePaint_tC25928758E48181B341DE30F410E3EA407D005E5 * L_5 = ((PaintManager_t8C7F3BD113E1D28F982A05D0397A369E09266BEE_StaticFields*)il2cpp_codegen_static_fields_for(PaintManager_t8C7F3BD113E1D28F982A05D0397A369E09266BEE_il2cpp_TypeInfo_var))->get_mobilePaint_5();
		NullCheck(L_4);
		L_4->set_mobilePaint_4(L_5);
		LoadTextureFromWeb_tFC746A6E41B9DB9A0D76CE18D58637FA36CA3F18 * L_6 = V_1;
		NullCheck(L_6);
		String_t* L_7 = L_6->get_url_5();
		WWW_tA50AFB5DE276783409B4CE88FE9B772322EE5664 * L_8 = (WWW_tA50AFB5DE276783409B4CE88FE9B772322EE5664 *)il2cpp_codegen_object_new(WWW_tA50AFB5DE276783409B4CE88FE9B772322EE5664_il2cpp_TypeInfo_var);
		WWW__ctor_m855BBB40089401B7BE6DE7A19FAD81EB070A2196(L_8, L_7, /*hidden argument*/NULL);
		__this->set_U3CwwwU3E5__2_3(L_8);
		WWW_tA50AFB5DE276783409B4CE88FE9B772322EE5664 * L_9 = __this->get_U3CwwwU3E5__2_3();
		__this->set_U3CU3E2__current_1(L_9);
		__this->set_U3CU3E1__state_0(1);
		return (bool)1;
	}

IL_004f:
	{
		__this->set_U3CU3E1__state_0((-1));
		WWW_tA50AFB5DE276783409B4CE88FE9B772322EE5664 * L_10 = __this->get_U3CwwwU3E5__2_3();
		NullCheck(L_10);
		String_t* L_11 = WWW_get_error_mED42EEAAE7847167CCEEFF2098563F78A79F8C2A(L_10, /*hidden argument*/NULL);
		bool L_12 = String_IsNullOrEmpty_m06A85A206AC2106D1982826C5665B9BD35324229(L_11, /*hidden argument*/NULL);
		if (L_12)
		{
			goto IL_007a;
		}
	}
	{
		WWW_tA50AFB5DE276783409B4CE88FE9B772322EE5664 * L_13 = __this->get_U3CwwwU3E5__2_3();
		NullCheck(L_13);
		String_t* L_14 = WWW_get_error_mED42EEAAE7847167CCEEFF2098563F78A79F8C2A(L_13, /*hidden argument*/NULL);
		IL2CPP_RUNTIME_CLASS_INIT(Debug_t7B5FCB117E2FD63B6838BC52821B252E2BFB61C4_il2cpp_TypeInfo_var);
		Debug_Log_m4B7C70BAFD477C6BDB59C88A0934F0B018D03708(L_14, /*hidden argument*/NULL);
		goto IL_0090;
	}

IL_007a:
	{
		LoadTextureFromWeb_tFC746A6E41B9DB9A0D76CE18D58637FA36CA3F18 * L_15 = V_1;
		NullCheck(L_15);
		MobilePaint_tC25928758E48181B341DE30F410E3EA407D005E5 * L_16 = L_15->get_mobilePaint_4();
		WWW_tA50AFB5DE276783409B4CE88FE9B772322EE5664 * L_17 = __this->get_U3CwwwU3E5__2_3();
		NullCheck(L_17);
		Texture2D_tBBF96AC337723E2EF156DF17E09D4379FD05DE1C * L_18 = WWW_get_texture_mD513AF1C1A59301515DFBC972E4530B886842C01(L_17, /*hidden argument*/NULL);
		NullCheck(L_16);
		MobilePaint_SetMaskImage_m80E98353C9F9EF9C4A76658F6734A9375FC329D7(L_16, L_18, /*hidden argument*/NULL);
	}

IL_0090:
	{
		return (bool)0;
	}
}
// System.Object unitycoder_MobilePaint_samples.LoadTextureFromWeb/<Start>d__2::System.Collections.Generic.IEnumerator<System.Object>.get_Current()
extern "C" IL2CPP_METHOD_ATTR RuntimeObject * U3CStartU3Ed__2_System_Collections_Generic_IEnumeratorU3CSystem_ObjectU3E_get_Current_mB6AE23E47FF22269A1AC72EB6F407C64073C79C0 (U3CStartU3Ed__2_tEC4FB974F881789E25ED33C9CC1420A5662BF176 * __this, const RuntimeMethod* method)
{
	{
		RuntimeObject * L_0 = __this->get_U3CU3E2__current_1();
		return L_0;
	}
}
// System.Void unitycoder_MobilePaint_samples.LoadTextureFromWeb/<Start>d__2::System.Collections.IEnumerator.Reset()
extern "C" IL2CPP_METHOD_ATTR void U3CStartU3Ed__2_System_Collections_IEnumerator_Reset_mF33C48CFBA65054D9C7C2E59048671B782426CA8 (U3CStartU3Ed__2_tEC4FB974F881789E25ED33C9CC1420A5662BF176 * __this, const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_method (U3CStartU3Ed__2_System_Collections_IEnumerator_Reset_mF33C48CFBA65054D9C7C2E59048671B782426CA8_MetadataUsageId);
		s_Il2CppMethodInitialized = true;
	}
	{
		NotSupportedException_tE75B318D6590A02A5D9B29FD97409B1750FA0010 * L_0 = (NotSupportedException_tE75B318D6590A02A5D9B29FD97409B1750FA0010 *)il2cpp_codegen_object_new(NotSupportedException_tE75B318D6590A02A5D9B29FD97409B1750FA0010_il2cpp_TypeInfo_var);
		NotSupportedException__ctor_mA121DE1CAC8F25277DEB489DC7771209D91CAE33(L_0, /*hidden argument*/NULL);
		IL2CPP_RAISE_MANAGED_EXCEPTION(L_0, NULL, U3CStartU3Ed__2_System_Collections_IEnumerator_Reset_mF33C48CFBA65054D9C7C2E59048671B782426CA8_RuntimeMethod_var);
	}
}
// System.Object unitycoder_MobilePaint_samples.LoadTextureFromWeb/<Start>d__2::System.Collections.IEnumerator.get_Current()
extern "C" IL2CPP_METHOD_ATTR RuntimeObject * U3CStartU3Ed__2_System_Collections_IEnumerator_get_Current_m7E7E4B57D2EFB2E16BA97E01F2B4C6F4079797FB (U3CStartU3Ed__2_tEC4FB974F881789E25ED33C9CC1420A5662BF176 * __this, const RuntimeMethod* method)
{
	{
		RuntimeObject * L_0 = __this->get_U3CU3E2__current_1();
		return L_0;
	}
}
#ifdef __clang__
#pragma clang diagnostic pop
#endif
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif
// System.Void unitycoder_MobilePaint_samples.ObjectRotator::Update()
extern "C" IL2CPP_METHOD_ATTR void ObjectRotator_Update_m1BE9AA9C052408AB7C03FB4EBC9FE4F3B1B17683 (ObjectRotator_t95B32158CE027C61B581320C3C6D806CC68AC258 * __this, const RuntimeMethod* method)
{
	{
		Transform_tBB9E78A2766C3C83599A8F66EDE7D1FCAFC66EDA * L_0 = Component_get_transform_m00F05BD782F920C301A7EBA480F3B7A904C07EC9(__this, /*hidden argument*/NULL);
		float L_1 = __this->get_rotateSpeed_4();
		float L_2 = Time_get_deltaTime_m16F98FC9BA931581236008C288E3B25CBCB7C81E(/*hidden argument*/NULL);
		NullCheck(L_0);
		Transform_Rotate_mEEA80F3DA5A4C93611D7165DF54763E578477EF9(L_0, (0.0f), ((float)il2cpp_codegen_multiply((float)L_1, (float)L_2)), (0.0f), /*hidden argument*/NULL);
		return;
	}
}
// System.Void unitycoder_MobilePaint_samples.ObjectRotator::.ctor()
extern "C" IL2CPP_METHOD_ATTR void ObjectRotator__ctor_m00C2AD0227465723B3EAC04573799126D6BCC790 (ObjectRotator_t95B32158CE027C61B581320C3C6D806CC68AC258 * __this, const RuntimeMethod* method)
{
	{
		__this->set_rotateSpeed_4((10.0f));
		MonoBehaviour__ctor_mEAEC84B222C60319D593E456D769B3311DFCEF97(__this, /*hidden argument*/NULL);
		return;
	}
}
#ifdef __clang__
#pragma clang diagnostic pop
#endif
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif
// System.Void unitycoder_MobilePaint_samples.RandomPainter::Start()
extern "C" IL2CPP_METHOD_ATTR void RandomPainter_Start_mB2753D21050D108CE78F5FA44F3F7E4A4D067061 (RandomPainter_t2FDDE913E008D1D01B3534CE3173C7E05EFD3D10 * __this, const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_method (RandomPainter_Start_mB2753D21050D108CE78F5FA44F3F7E4A4D067061_MetadataUsageId);
		s_Il2CppMethodInitialized = true;
	}
	{
		MobilePaint_tC25928758E48181B341DE30F410E3EA407D005E5 * L_0 = ((PaintManager_t8C7F3BD113E1D28F982A05D0397A369E09266BEE_StaticFields*)il2cpp_codegen_static_fields_for(PaintManager_t8C7F3BD113E1D28F982A05D0397A369E09266BEE_il2cpp_TypeInfo_var))->get_mobilePaint_5();
		__this->set_mobilePaint_4(L_0);
		return;
	}
}
// System.Void unitycoder_MobilePaint_samples.RandomPainter::Update()
extern "C" IL2CPP_METHOD_ATTR void RandomPainter_Update_m8AF4D3E9E7F9F11AED1899926325803687ED9742 (RandomPainter_t2FDDE913E008D1D01B3534CE3173C7E05EFD3D10 * __this, const RuntimeMethod* method)
{
	{
		MobilePaint_tC25928758E48181B341DE30F410E3EA407D005E5 * L_0 = __this->get_mobilePaint_4();
		float L_1 = Random_get_value_mC998749E08291DD42CF31C026FAC4F14F746831C(/*hidden argument*/NULL);
		float L_2 = Random_get_value_mC998749E08291DD42CF31C026FAC4F14F746831C(/*hidden argument*/NULL);
		float L_3 = Random_get_value_mC998749E08291DD42CF31C026FAC4F14F746831C(/*hidden argument*/NULL);
		float L_4 = Random_get_value_mC998749E08291DD42CF31C026FAC4F14F746831C(/*hidden argument*/NULL);
		Color_t119BCA590009762C7223FDD3AF9706653AC84ED2  L_5;
		memset(&L_5, 0, sizeof(L_5));
		Color__ctor_m20DF490CEB364C4FC36D7EE392640DF5B7420D7C((&L_5), L_1, L_2, L_3, L_4, /*hidden argument*/NULL);
		Color32_t23ABC4AE0E0BDFD2E22EE1FA0DA3904FFE5F6E23  L_6 = Color32_op_Implicit_m52B034473369A651C8952BD916A2AB193E0E5B30(L_5, /*hidden argument*/NULL);
		NullCheck(L_0);
		L_0->set_paintColor_10(L_6);
		MobilePaint_tC25928758E48181B341DE30F410E3EA407D005E5 * L_7 = __this->get_mobilePaint_4();
		float L_8 = Random_get_value_mC998749E08291DD42CF31C026FAC4F14F746831C(/*hidden argument*/NULL);
		NullCheck(L_7);
		MobilePaint_SetBrushSize_mC98FEF3E8DFC88C63B9E5E41C3A69E861D48148E(L_7, (((int32_t)((int32_t)((float)il2cpp_codegen_multiply((float)L_8, (float)(64.0f)))))), /*hidden argument*/NULL);
		MobilePaint_tC25928758E48181B341DE30F410E3EA407D005E5 * L_9 = __this->get_mobilePaint_4();
		float L_10 = Random_get_value_mC998749E08291DD42CF31C026FAC4F14F746831C(/*hidden argument*/NULL);
		int32_t L_11 = Screen_get_width_m8ECCEF7FF17395D1237BC0193D7A6640A3FEEAD3(/*hidden argument*/NULL);
		float L_12 = Random_get_value_mC998749E08291DD42CF31C026FAC4F14F746831C(/*hidden argument*/NULL);
		int32_t L_13 = Screen_get_height_mF5B64EBC4CDE0EAAA5713C1452ED2CE475F25150(/*hidden argument*/NULL);
		NullCheck(L_9);
		MobilePaint_DrawCircle_m4169D0E1FCA5762D225B8C993C2F1C0B0BF47194(L_9, (((int32_t)((int32_t)((float)il2cpp_codegen_multiply((float)L_10, (float)(((float)((float)L_11)))))))), (((int32_t)((int32_t)((float)il2cpp_codegen_multiply((float)L_12, (float)(((float)((float)L_13)))))))), /*hidden argument*/NULL);
		MobilePaint_tC25928758E48181B341DE30F410E3EA407D005E5 * L_14 = __this->get_mobilePaint_4();
		NullCheck(L_14);
		MobilePaint_SetBrushSize_mC98FEF3E8DFC88C63B9E5E41C3A69E861D48148E(L_14, 1, /*hidden argument*/NULL);
		MobilePaint_tC25928758E48181B341DE30F410E3EA407D005E5 * L_15 = __this->get_mobilePaint_4();
		float L_16 = Random_get_value_mC998749E08291DD42CF31C026FAC4F14F746831C(/*hidden argument*/NULL);
		int32_t L_17 = Screen_get_width_m8ECCEF7FF17395D1237BC0193D7A6640A3FEEAD3(/*hidden argument*/NULL);
		float L_18 = Random_get_value_mC998749E08291DD42CF31C026FAC4F14F746831C(/*hidden argument*/NULL);
		int32_t L_19 = Screen_get_height_mF5B64EBC4CDE0EAAA5713C1452ED2CE475F25150(/*hidden argument*/NULL);
		float L_20 = Random_get_value_mC998749E08291DD42CF31C026FAC4F14F746831C(/*hidden argument*/NULL);
		int32_t L_21 = Screen_get_width_m8ECCEF7FF17395D1237BC0193D7A6640A3FEEAD3(/*hidden argument*/NULL);
		float L_22 = Random_get_value_mC998749E08291DD42CF31C026FAC4F14F746831C(/*hidden argument*/NULL);
		int32_t L_23 = Screen_get_height_mF5B64EBC4CDE0EAAA5713C1452ED2CE475F25150(/*hidden argument*/NULL);
		NullCheck(L_15);
		MobilePaint_DrawLine_mE2DA9F1350E45B98898D478E4DE962C519D7FE0D(L_15, (((int32_t)((int32_t)((float)il2cpp_codegen_multiply((float)L_16, (float)(((float)((float)L_17)))))))), (((int32_t)((int32_t)((float)il2cpp_codegen_multiply((float)L_18, (float)(((float)((float)L_19)))))))), (((int32_t)((int32_t)((float)il2cpp_codegen_multiply((float)L_20, (float)(((float)((float)L_21)))))))), (((int32_t)((int32_t)((float)il2cpp_codegen_multiply((float)L_22, (float)(((float)((float)L_23)))))))), /*hidden argument*/NULL);
		MobilePaint_tC25928758E48181B341DE30F410E3EA407D005E5 * L_24 = __this->get_mobilePaint_4();
		NullCheck(L_24);
		L_24->set_textureNeedsUpdate_97((bool)1);
		return;
	}
}
// System.Void unitycoder_MobilePaint_samples.RandomPainter::.ctor()
extern "C" IL2CPP_METHOD_ATTR void RandomPainter__ctor_mF8523BFCD730602AAECD75C48D76B0452F459697 (RandomPainter_t2FDDE913E008D1D01B3534CE3173C7E05EFD3D10 * __this, const RuntimeMethod* method)
{
	{
		MonoBehaviour__ctor_mEAEC84B222C60319D593E456D769B3311DFCEF97(__this, /*hidden argument*/NULL);
		return;
	}
}
#ifdef __clang__
#pragma clang diagnostic pop
#endif
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif
// System.Void unitycoder_MobilePaint_samples.SaveImageToFile::Start()
extern "C" IL2CPP_METHOD_ATTR void SaveImageToFile_Start_mB25E5A76789A91B110D88E200C7324D1ADFC99B2 (SaveImageToFile_tA64B2DAC4D2AF5B3E183119D7B8EB1C53770B018 * __this, const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_method (SaveImageToFile_Start_mB25E5A76789A91B110D88E200C7324D1ADFC99B2_MetadataUsageId);
		s_Il2CppMethodInitialized = true;
	}
	{
		MobilePaint_tC25928758E48181B341DE30F410E3EA407D005E5 * L_0 = ((PaintManager_t8C7F3BD113E1D28F982A05D0397A369E09266BEE_StaticFields*)il2cpp_codegen_static_fields_for(PaintManager_t8C7F3BD113E1D28F982A05D0397A369E09266BEE_il2cpp_TypeInfo_var))->get_mobilePaint_5();
		__this->set_mobilePaint_4(L_0);
		return;
	}
}
// System.Void unitycoder_MobilePaint_samples.SaveImageToFile::Update()
extern "C" IL2CPP_METHOD_ATTR void SaveImageToFile_Update_m7D6FFF7DFE53BF100BC930D0D3DE131CC2D7D391 (SaveImageToFile_tA64B2DAC4D2AF5B3E183119D7B8EB1C53770B018 * __this, const RuntimeMethod* method)
{
	{
		int32_t L_0 = __this->get_screenshotKey_5();
		bool L_1 = Input_GetKeyDown_mD82B14BB87E1C811668BD1A2CFBC0CF3D4983FEA(L_0, /*hidden argument*/NULL);
		if (!L_1)
		{
			goto IL_001a;
		}
	}
	{
		RuntimeObject* L_2 = SaveImageToFile_TakeScreenShot_mF31594A7E22C2A2E632345CEC685BDEA695A3C37(__this, /*hidden argument*/NULL);
		MonoBehaviour_StartCoroutine_mBF8044CE06A35D76A69669ADD8977D05956616B7(__this, L_2, /*hidden argument*/NULL);
	}

IL_001a:
	{
		return;
	}
}
// System.Collections.IEnumerator unitycoder_MobilePaint_samples.SaveImageToFile::TakeScreenShot()
extern "C" IL2CPP_METHOD_ATTR RuntimeObject* SaveImageToFile_TakeScreenShot_mF31594A7E22C2A2E632345CEC685BDEA695A3C37 (SaveImageToFile_tA64B2DAC4D2AF5B3E183119D7B8EB1C53770B018 * __this, const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_method (SaveImageToFile_TakeScreenShot_mF31594A7E22C2A2E632345CEC685BDEA695A3C37_MetadataUsageId);
		s_Il2CppMethodInitialized = true;
	}
	{
		U3CTakeScreenShotU3Ed__4_t64EC1BB46F6C5F44D6231D42AF034F669E966DE7 * L_0 = (U3CTakeScreenShotU3Ed__4_t64EC1BB46F6C5F44D6231D42AF034F669E966DE7 *)il2cpp_codegen_object_new(U3CTakeScreenShotU3Ed__4_t64EC1BB46F6C5F44D6231D42AF034F669E966DE7_il2cpp_TypeInfo_var);
		U3CTakeScreenShotU3Ed__4__ctor_m9D517A82491B73CEF4B25AC3332891309EA6E820(L_0, 0, /*hidden argument*/NULL);
		U3CTakeScreenShotU3Ed__4_t64EC1BB46F6C5F44D6231D42AF034F669E966DE7 * L_1 = L_0;
		NullCheck(L_1);
		L_1->set_U3CU3E4__this_2(__this);
		return L_1;
	}
}
// System.Void unitycoder_MobilePaint_samples.SaveImageToFile::.ctor()
extern "C" IL2CPP_METHOD_ATTR void SaveImageToFile__ctor_mC4D3E11B3D8376F7210FA4B7AED06F4A644A74C3 (SaveImageToFile_tA64B2DAC4D2AF5B3E183119D7B8EB1C53770B018 * __this, const RuntimeMethod* method)
{
	{
		__this->set_screenshotKey_5(((int32_t)293));
		MonoBehaviour__ctor_mEAEC84B222C60319D593E456D769B3311DFCEF97(__this, /*hidden argument*/NULL);
		return;
	}
}
#ifdef __clang__
#pragma clang diagnostic pop
#endif
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif
// System.Void unitycoder_MobilePaint_samples.SaveImageToFile/<TakeScreenShot>d__4::.ctor(System.Int32)
extern "C" IL2CPP_METHOD_ATTR void U3CTakeScreenShotU3Ed__4__ctor_m9D517A82491B73CEF4B25AC3332891309EA6E820 (U3CTakeScreenShotU3Ed__4_t64EC1BB46F6C5F44D6231D42AF034F669E966DE7 * __this, int32_t ___U3CU3E1__state0, const RuntimeMethod* method)
{
	{
		Object__ctor_m925ECA5E85CA100E3FB86A4F9E15C120E9A184C0(__this, /*hidden argument*/NULL);
		int32_t L_0 = ___U3CU3E1__state0;
		__this->set_U3CU3E1__state_0(L_0);
		return;
	}
}
// System.Void unitycoder_MobilePaint_samples.SaveImageToFile/<TakeScreenShot>d__4::System.IDisposable.Dispose()
extern "C" IL2CPP_METHOD_ATTR void U3CTakeScreenShotU3Ed__4_System_IDisposable_Dispose_m8F40388F68F920F473CFE56A27198A52383EF9C7 (U3CTakeScreenShotU3Ed__4_t64EC1BB46F6C5F44D6231D42AF034F669E966DE7 * __this, const RuntimeMethod* method)
{
	{
		return;
	}
}
// System.Boolean unitycoder_MobilePaint_samples.SaveImageToFile/<TakeScreenShot>d__4::MoveNext()
extern "C" IL2CPP_METHOD_ATTR bool U3CTakeScreenShotU3Ed__4_MoveNext_m2603AACF6ED5242C103ACE5FE55A2EF46B70D884 (U3CTakeScreenShotU3Ed__4_t64EC1BB46F6C5F44D6231D42AF034F669E966DE7 * __this, const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_method (U3CTakeScreenShotU3Ed__4_MoveNext_m2603AACF6ED5242C103ACE5FE55A2EF46B70D884_MetadataUsageId);
		s_Il2CppMethodInitialized = true;
	}
	int32_t V_0 = 0;
	SaveImageToFile_tA64B2DAC4D2AF5B3E183119D7B8EB1C53770B018 * V_1 = NULL;
	ByteU5BU5D_tD06FDBE8142446525DF1C40351D523A228373821* V_2 = NULL;
	String_t* V_3 = NULL;
	String_t* V_4 = NULL;
	String_t* V_5 = NULL;
	{
		int32_t L_0 = __this->get_U3CU3E1__state_0();
		V_0 = L_0;
		SaveImageToFile_tA64B2DAC4D2AF5B3E183119D7B8EB1C53770B018 * L_1 = __this->get_U3CU3E4__this_2();
		V_1 = L_1;
		int32_t L_2 = V_0;
		if (!L_2)
		{
			goto IL_0017;
		}
	}
	{
		int32_t L_3 = V_0;
		if ((((int32_t)L_3) == ((int32_t)1)))
		{
			goto IL_0032;
		}
	}
	{
		return (bool)0;
	}

IL_0017:
	{
		__this->set_U3CU3E1__state_0((-1));
		WaitForEndOfFrame_t75980FB3F246D6AD36A85CA2BFDF8474E5EEBCCA * L_4 = (WaitForEndOfFrame_t75980FB3F246D6AD36A85CA2BFDF8474E5EEBCCA *)il2cpp_codegen_object_new(WaitForEndOfFrame_t75980FB3F246D6AD36A85CA2BFDF8474E5EEBCCA_il2cpp_TypeInfo_var);
		WaitForEndOfFrame__ctor_m6CDB79476A4A84CEC62947D36ADED96E907BA20B(L_4, /*hidden argument*/NULL);
		__this->set_U3CU3E2__current_1(L_4);
		__this->set_U3CU3E1__state_0(1);
		return (bool)1;
	}

IL_0032:
	{
		__this->set_U3CU3E1__state_0((-1));
		SaveImageToFile_tA64B2DAC4D2AF5B3E183119D7B8EB1C53770B018 * L_5 = V_1;
		NullCheck(L_5);
		MobilePaint_tC25928758E48181B341DE30F410E3EA407D005E5 * L_6 = L_5->get_mobilePaint_4();
		NullCheck(L_6);
		Texture2D_tBBF96AC337723E2EF156DF17E09D4379FD05DE1C * L_7 = MobilePaint_GetCanvasAsTexture_m8A82C502673621890AC334E9590868DF74C0D15D(L_6, /*hidden argument*/NULL);
		ByteU5BU5D_tD06FDBE8142446525DF1C40351D523A228373821* L_8 = ImageConversion_EncodeToPNG_m8D67A36A7D81F436CDA108CC5293E15A9CFD5617(L_7, /*hidden argument*/NULL);
		V_2 = L_8;
		V_3 = _stringLiteral0E21ACCF4B52FBCAC31706043FCB375D33FBE946;
		String_t* L_9 = Application_get_dataPath_m33D721D71C0687F0013C8953FDB0807B7B3F2A01(/*hidden argument*/NULL);
		String_t* L_10 = String_Concat_mB78D0094592718DA6D5DB6C712A9C225631666BE(L_9, _stringLiteralFFB3B317C519BDE283D8101D0B219BD8A4A161FE, /*hidden argument*/NULL);
		V_4 = L_10;
		String_t* L_11 = V_4;
		String_t* L_12 = V_3;
		String_t* L_13 = String_Concat_mB78D0094592718DA6D5DB6C712A9C225631666BE(L_11, L_12, /*hidden argument*/NULL);
		V_5 = L_13;
		String_t* L_14 = V_4;
		bool L_15 = Directory_Exists_mB77956D89305E16FEFCBDFC55CCC98F03AEE4D84(L_14, /*hidden argument*/NULL);
		if (L_15)
		{
			goto IL_007c;
		}
	}
	{
		String_t* L_16 = V_4;
		Directory_CreateDirectory_m0C9CAA2ECA801C4D07EA35820DA0907402ED4D41(L_16, /*hidden argument*/NULL);
	}

IL_007c:
	{
		String_t* L_17 = V_5;
		ByteU5BU5D_tD06FDBE8142446525DF1C40351D523A228373821* L_18 = V_2;
		File_WriteAllBytes_m07F13C1CA0BD0960392C78AB99E0F19564F9B594(L_17, L_18, /*hidden argument*/NULL);
		String_t* L_19 = V_5;
		String_t* L_20 = String_Concat_mB78D0094592718DA6D5DB6C712A9C225631666BE(_stringLiteral786E544BB06C3ABF1CB01BDA08D7D3131DBD8599, L_19, /*hidden argument*/NULL);
		IL2CPP_RUNTIME_CLASS_INIT(Debug_t7B5FCB117E2FD63B6838BC52821B252E2BFB61C4_il2cpp_TypeInfo_var);
		Debug_Log_m4B7C70BAFD477C6BDB59C88A0934F0B018D03708(L_20, /*hidden argument*/NULL);
		return (bool)0;
	}
}
// System.Object unitycoder_MobilePaint_samples.SaveImageToFile/<TakeScreenShot>d__4::System.Collections.Generic.IEnumerator<System.Object>.get_Current()
extern "C" IL2CPP_METHOD_ATTR RuntimeObject * U3CTakeScreenShotU3Ed__4_System_Collections_Generic_IEnumeratorU3CSystem_ObjectU3E_get_Current_m3671E9DD6E60B82626E71A08E6A0CDA9787CACC2 (U3CTakeScreenShotU3Ed__4_t64EC1BB46F6C5F44D6231D42AF034F669E966DE7 * __this, const RuntimeMethod* method)
{
	{
		RuntimeObject * L_0 = __this->get_U3CU3E2__current_1();
		return L_0;
	}
}
// System.Void unitycoder_MobilePaint_samples.SaveImageToFile/<TakeScreenShot>d__4::System.Collections.IEnumerator.Reset()
extern "C" IL2CPP_METHOD_ATTR void U3CTakeScreenShotU3Ed__4_System_Collections_IEnumerator_Reset_m3E894B69319934EECAC34BACC0EC47DD267CEBE6 (U3CTakeScreenShotU3Ed__4_t64EC1BB46F6C5F44D6231D42AF034F669E966DE7 * __this, const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_method (U3CTakeScreenShotU3Ed__4_System_Collections_IEnumerator_Reset_m3E894B69319934EECAC34BACC0EC47DD267CEBE6_MetadataUsageId);
		s_Il2CppMethodInitialized = true;
	}
	{
		NotSupportedException_tE75B318D6590A02A5D9B29FD97409B1750FA0010 * L_0 = (NotSupportedException_tE75B318D6590A02A5D9B29FD97409B1750FA0010 *)il2cpp_codegen_object_new(NotSupportedException_tE75B318D6590A02A5D9B29FD97409B1750FA0010_il2cpp_TypeInfo_var);
		NotSupportedException__ctor_mA121DE1CAC8F25277DEB489DC7771209D91CAE33(L_0, /*hidden argument*/NULL);
		IL2CPP_RAISE_MANAGED_EXCEPTION(L_0, NULL, U3CTakeScreenShotU3Ed__4_System_Collections_IEnumerator_Reset_m3E894B69319934EECAC34BACC0EC47DD267CEBE6_RuntimeMethod_var);
	}
}
// System.Object unitycoder_MobilePaint_samples.SaveImageToFile/<TakeScreenShot>d__4::System.Collections.IEnumerator.get_Current()
extern "C" IL2CPP_METHOD_ATTR RuntimeObject * U3CTakeScreenShotU3Ed__4_System_Collections_IEnumerator_get_Current_m6842740767D84176286958B2FA5210B22A150347 (U3CTakeScreenShotU3Ed__4_t64EC1BB46F6C5F44D6231D42AF034F669E966DE7 * __this, const RuntimeMethod* method)
{
	{
		RuntimeObject * L_0 = __this->get_U3CU3E2__current_1();
		return L_0;
	}
}
#ifdef __clang__
#pragma clang diagnostic pop
#endif
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif
// System.Void unitycoder_MobilePaint_samples.SetSortingOrderAndLayer::Awake()
extern "C" IL2CPP_METHOD_ATTR void SetSortingOrderAndLayer_Awake_mEE214F4FB7872C261EF6C7CA574105EE665430A4 (SetSortingOrderAndLayer_tBB2A36BC15162AB6518A830659C7B4623AE6B8D2 * __this, const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_method (SetSortingOrderAndLayer_Awake_mEE214F4FB7872C261EF6C7CA574105EE665430A4_MetadataUsageId);
		s_Il2CppMethodInitialized = true;
	}
	{
		Renderer_t0556D67DD582620D1F495627EDE30D03284151F4 * L_0 = Component_GetComponent_TisRenderer_t0556D67DD582620D1F495627EDE30D03284151F4_m3E0C8F08ADF98436AEF5AE9F4C56A51FF7D0A892(__this, /*hidden argument*/Component_GetComponent_TisRenderer_t0556D67DD582620D1F495627EDE30D03284151F4_m3E0C8F08ADF98436AEF5AE9F4C56A51FF7D0A892_RuntimeMethod_var);
		int32_t L_1 = __this->get_sortingOrder_4();
		NullCheck(L_0);
		Renderer_set_sortingOrder_mBCE1207CDB46CB6BA4583B9C3FB4A2D28DC27D81(L_0, L_1, /*hidden argument*/NULL);
		Renderer_t0556D67DD582620D1F495627EDE30D03284151F4 * L_2 = Component_GetComponent_TisRenderer_t0556D67DD582620D1F495627EDE30D03284151F4_m3E0C8F08ADF98436AEF5AE9F4C56A51FF7D0A892(__this, /*hidden argument*/Component_GetComponent_TisRenderer_t0556D67DD582620D1F495627EDE30D03284151F4_m3E0C8F08ADF98436AEF5AE9F4C56A51FF7D0A892_RuntimeMethod_var);
		String_t* L_3 = __this->get_layerName_5();
		NullCheck(L_2);
		Renderer_set_sortingLayerName_m8DCB7B753F22739F79E065922F6201E8EDD08E8F(L_2, L_3, /*hidden argument*/NULL);
		return;
	}
}
// System.Void unitycoder_MobilePaint_samples.SetSortingOrderAndLayer::.ctor()
extern "C" IL2CPP_METHOD_ATTR void SetSortingOrderAndLayer__ctor_m0879B1433E145E2873FF6D1B8AFCC7DC466A6200 (SetSortingOrderAndLayer_tBB2A36BC15162AB6518A830659C7B4623AE6B8D2 * __this, const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_method (SetSortingOrderAndLayer__ctor_m0879B1433E145E2873FF6D1B8AFCC7DC466A6200_MetadataUsageId);
		s_Il2CppMethodInitialized = true;
	}
	{
		__this->set_layerName_5(_stringLiteral808D7DCA8A74D84AF27A2D6602C3D786DE45FE1E);
		MonoBehaviour__ctor_mEAEC84B222C60319D593E456D769B3311DFCEF97(__this, /*hidden argument*/NULL);
		return;
	}
}
#ifdef __clang__
#pragma clang diagnostic pop
#endif
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif
// UnityEngine.Vector4[] unitycoder_MobilePaint_samples.TangentSolver::Solve(UnityEngine.Mesh)
extern "C" IL2CPP_METHOD_ATTR Vector4U5BU5D_t51402C154FFFCF7217A9BEC4B834F0B726C10F66* TangentSolver_Solve_mC1A59B0DE4F71AE58060A1FA0E546917C348B7F7 (Mesh_t6106B8D8E4C691321581AB0445552EC78B947B8C * ___theMesh0, const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_method (TangentSolver_Solve_mC1A59B0DE4F71AE58060A1FA0E546917C348B7F7_MetadataUsageId);
		s_Il2CppMethodInitialized = true;
	}
	int32_t V_0 = 0;
	Vector3U5BU5D_tB9EC3346CC4A0EA5447D968E84A9AC1F6F372C28* V_1 = NULL;
	Vector3U5BU5D_tB9EC3346CC4A0EA5447D968E84A9AC1F6F372C28* V_2 = NULL;
	Vector2U5BU5D_tA065A07DFC060C1B8786BBAA5F3A6577CCEB27D6* V_3 = NULL;
	Int32U5BU5D_t2B9E4FDDDB9F0A00EC0AC631BA2DA915EB1ECF83* V_4 = NULL;
	int32_t V_5 = 0;
	Vector4U5BU5D_t51402C154FFFCF7217A9BEC4B834F0B726C10F66* V_6 = NULL;
	Vector3U5BU5D_tB9EC3346CC4A0EA5447D968E84A9AC1F6F372C28* V_7 = NULL;
	Vector3U5BU5D_tB9EC3346CC4A0EA5447D968E84A9AC1F6F372C28* V_8 = NULL;
	int32_t V_9 = 0;
	int32_t V_10 = 0;
	int32_t V_11 = 0;
	int32_t V_12 = 0;
	int32_t V_13 = 0;
	Vector3_tDCF05E21F632FE2BA260C06E0D10CA81513E6720  V_14;
	memset(&V_14, 0, sizeof(V_14));
	Vector3_tDCF05E21F632FE2BA260C06E0D10CA81513E6720  V_15;
	memset(&V_15, 0, sizeof(V_15));
	Vector3_tDCF05E21F632FE2BA260C06E0D10CA81513E6720  V_16;
	memset(&V_16, 0, sizeof(V_16));
	Vector2_tA85D2DD88578276CA8A8796756458277E72D073D  V_17;
	memset(&V_17, 0, sizeof(V_17));
	Vector2_tA85D2DD88578276CA8A8796756458277E72D073D  V_18;
	memset(&V_18, 0, sizeof(V_18));
	Vector2_tA85D2DD88578276CA8A8796756458277E72D073D  V_19;
	memset(&V_19, 0, sizeof(V_19));
	float V_20 = 0.0f;
	float V_21 = 0.0f;
	float V_22 = 0.0f;
	float V_23 = 0.0f;
	float V_24 = 0.0f;
	float V_25 = 0.0f;
	float V_26 = 0.0f;
	float V_27 = 0.0f;
	float V_28 = 0.0f;
	float V_29 = 0.0f;
	float V_30 = 0.0f;
	Vector3_tDCF05E21F632FE2BA260C06E0D10CA81513E6720  V_31;
	memset(&V_31, 0, sizeof(V_31));
	Vector3_tDCF05E21F632FE2BA260C06E0D10CA81513E6720  V_32;
	memset(&V_32, 0, sizeof(V_32));
	int32_t V_33 = 0;
	Vector3_tDCF05E21F632FE2BA260C06E0D10CA81513E6720  V_34;
	memset(&V_34, 0, sizeof(V_34));
	Vector3_tDCF05E21F632FE2BA260C06E0D10CA81513E6720  V_35;
	memset(&V_35, 0, sizeof(V_35));
	Vector4_tD148D6428C3F8FF6CD998F82090113C2B490B76E * G_B6_0 = NULL;
	Vector4_tD148D6428C3F8FF6CD998F82090113C2B490B76E * G_B5_0 = NULL;
	float G_B7_0 = 0.0f;
	Vector4_tD148D6428C3F8FF6CD998F82090113C2B490B76E * G_B7_1 = NULL;
	{
		Mesh_t6106B8D8E4C691321581AB0445552EC78B947B8C * L_0 = ___theMesh0;
		NullCheck(L_0);
		int32_t L_1 = Mesh_get_vertexCount_mE6F1153EA724F831AD11F10807ABE664CC02E0AF(L_0, /*hidden argument*/NULL);
		V_0 = L_1;
		Mesh_t6106B8D8E4C691321581AB0445552EC78B947B8C * L_2 = ___theMesh0;
		NullCheck(L_2);
		Vector3U5BU5D_tB9EC3346CC4A0EA5447D968E84A9AC1F6F372C28* L_3 = Mesh_get_vertices_m7D07DC0F071C142B87F675B148FC0F7A243238B9(L_2, /*hidden argument*/NULL);
		V_1 = L_3;
		Mesh_t6106B8D8E4C691321581AB0445552EC78B947B8C * L_4 = ___theMesh0;
		NullCheck(L_4);
		Vector3U5BU5D_tB9EC3346CC4A0EA5447D968E84A9AC1F6F372C28* L_5 = Mesh_get_normals_m3CE4668899836CBD17C3F85EB24261CBCEB3EABB(L_4, /*hidden argument*/NULL);
		V_2 = L_5;
		Mesh_t6106B8D8E4C691321581AB0445552EC78B947B8C * L_6 = ___theMesh0;
		NullCheck(L_6);
		Vector2U5BU5D_tA065A07DFC060C1B8786BBAA5F3A6577CCEB27D6* L_7 = Mesh_get_uv_m0EBA5CA4644C9D5F1B2125AF3FE3873EFC8A4616(L_6, /*hidden argument*/NULL);
		V_3 = L_7;
		Mesh_t6106B8D8E4C691321581AB0445552EC78B947B8C * L_8 = ___theMesh0;
		NullCheck(L_8);
		Int32U5BU5D_t2B9E4FDDDB9F0A00EC0AC631BA2DA915EB1ECF83* L_9 = Mesh_get_triangles_mAAAFC770B8EE3F56992D5764EF8C2EC06EF743AC(L_8, /*hidden argument*/NULL);
		V_4 = L_9;
		Int32U5BU5D_t2B9E4FDDDB9F0A00EC0AC631BA2DA915EB1ECF83* L_10 = V_4;
		NullCheck(L_10);
		V_5 = ((int32_t)((int32_t)(((int32_t)((int32_t)(((RuntimeArray *)L_10)->max_length))))/(int32_t)3));
		int32_t L_11 = V_0;
		Vector4U5BU5D_t51402C154FFFCF7217A9BEC4B834F0B726C10F66* L_12 = (Vector4U5BU5D_t51402C154FFFCF7217A9BEC4B834F0B726C10F66*)SZArrayNew(Vector4U5BU5D_t51402C154FFFCF7217A9BEC4B834F0B726C10F66_il2cpp_TypeInfo_var, (uint32_t)L_11);
		V_6 = L_12;
		int32_t L_13 = V_0;
		Vector3U5BU5D_tB9EC3346CC4A0EA5447D968E84A9AC1F6F372C28* L_14 = (Vector3U5BU5D_tB9EC3346CC4A0EA5447D968E84A9AC1F6F372C28*)SZArrayNew(Vector3U5BU5D_tB9EC3346CC4A0EA5447D968E84A9AC1F6F372C28_il2cpp_TypeInfo_var, (uint32_t)L_13);
		V_7 = L_14;
		int32_t L_15 = V_0;
		Vector3U5BU5D_tB9EC3346CC4A0EA5447D968E84A9AC1F6F372C28* L_16 = (Vector3U5BU5D_tB9EC3346CC4A0EA5447D968E84A9AC1F6F372C28*)SZArrayNew(Vector3U5BU5D_tB9EC3346CC4A0EA5447D968E84A9AC1F6F372C28_il2cpp_TypeInfo_var, (uint32_t)L_15);
		V_8 = L_16;
		V_9 = 0;
		V_10 = 0;
		goto IL_0271;
	}

IL_004f:
	{
		Int32U5BU5D_t2B9E4FDDDB9F0A00EC0AC631BA2DA915EB1ECF83* L_17 = V_4;
		int32_t L_18 = V_9;
		NullCheck(L_17);
		int32_t L_19 = L_18;
		int32_t L_20 = (L_17)->GetAt(static_cast<il2cpp_array_size_t>(L_19));
		V_11 = L_20;
		Int32U5BU5D_t2B9E4FDDDB9F0A00EC0AC631BA2DA915EB1ECF83* L_21 = V_4;
		int32_t L_22 = V_9;
		NullCheck(L_21);
		int32_t L_23 = ((int32_t)il2cpp_codegen_add((int32_t)L_22, (int32_t)1));
		int32_t L_24 = (L_21)->GetAt(static_cast<il2cpp_array_size_t>(L_23));
		V_12 = L_24;
		Int32U5BU5D_t2B9E4FDDDB9F0A00EC0AC631BA2DA915EB1ECF83* L_25 = V_4;
		int32_t L_26 = V_9;
		NullCheck(L_25);
		int32_t L_27 = ((int32_t)il2cpp_codegen_add((int32_t)L_26, (int32_t)2));
		int32_t L_28 = (L_25)->GetAt(static_cast<il2cpp_array_size_t>(L_27));
		V_13 = L_28;
		Vector3U5BU5D_tB9EC3346CC4A0EA5447D968E84A9AC1F6F372C28* L_29 = V_1;
		int32_t L_30 = V_11;
		NullCheck(L_29);
		int32_t L_31 = L_30;
		Vector3_tDCF05E21F632FE2BA260C06E0D10CA81513E6720  L_32 = (L_29)->GetAt(static_cast<il2cpp_array_size_t>(L_31));
		V_14 = L_32;
		Vector3U5BU5D_tB9EC3346CC4A0EA5447D968E84A9AC1F6F372C28* L_33 = V_1;
		int32_t L_34 = V_12;
		NullCheck(L_33);
		int32_t L_35 = L_34;
		Vector3_tDCF05E21F632FE2BA260C06E0D10CA81513E6720  L_36 = (L_33)->GetAt(static_cast<il2cpp_array_size_t>(L_35));
		V_15 = L_36;
		Vector3U5BU5D_tB9EC3346CC4A0EA5447D968E84A9AC1F6F372C28* L_37 = V_1;
		int32_t L_38 = V_13;
		NullCheck(L_37);
		int32_t L_39 = L_38;
		Vector3_tDCF05E21F632FE2BA260C06E0D10CA81513E6720  L_40 = (L_37)->GetAt(static_cast<il2cpp_array_size_t>(L_39));
		V_16 = L_40;
		Vector2U5BU5D_tA065A07DFC060C1B8786BBAA5F3A6577CCEB27D6* L_41 = V_3;
		int32_t L_42 = V_11;
		NullCheck(L_41);
		int32_t L_43 = L_42;
		Vector2_tA85D2DD88578276CA8A8796756458277E72D073D  L_44 = (L_41)->GetAt(static_cast<il2cpp_array_size_t>(L_43));
		V_17 = L_44;
		Vector2U5BU5D_tA065A07DFC060C1B8786BBAA5F3A6577CCEB27D6* L_45 = V_3;
		int32_t L_46 = V_12;
		NullCheck(L_45);
		int32_t L_47 = L_46;
		Vector2_tA85D2DD88578276CA8A8796756458277E72D073D  L_48 = (L_45)->GetAt(static_cast<il2cpp_array_size_t>(L_47));
		V_18 = L_48;
		Vector2U5BU5D_tA065A07DFC060C1B8786BBAA5F3A6577CCEB27D6* L_49 = V_3;
		int32_t L_50 = V_13;
		NullCheck(L_49);
		int32_t L_51 = L_50;
		Vector2_tA85D2DD88578276CA8A8796756458277E72D073D  L_52 = (L_49)->GetAt(static_cast<il2cpp_array_size_t>(L_51));
		V_19 = L_52;
		Vector3_tDCF05E21F632FE2BA260C06E0D10CA81513E6720  L_53 = V_15;
		float L_54 = L_53.get_x_2();
		Vector3_tDCF05E21F632FE2BA260C06E0D10CA81513E6720  L_55 = V_14;
		float L_56 = L_55.get_x_2();
		V_20 = ((float)il2cpp_codegen_subtract((float)L_54, (float)L_56));
		Vector3_tDCF05E21F632FE2BA260C06E0D10CA81513E6720  L_57 = V_16;
		float L_58 = L_57.get_x_2();
		Vector3_tDCF05E21F632FE2BA260C06E0D10CA81513E6720  L_59 = V_14;
		float L_60 = L_59.get_x_2();
		V_21 = ((float)il2cpp_codegen_subtract((float)L_58, (float)L_60));
		Vector3_tDCF05E21F632FE2BA260C06E0D10CA81513E6720  L_61 = V_15;
		float L_62 = L_61.get_y_3();
		Vector3_tDCF05E21F632FE2BA260C06E0D10CA81513E6720  L_63 = V_14;
		float L_64 = L_63.get_y_3();
		V_22 = ((float)il2cpp_codegen_subtract((float)L_62, (float)L_64));
		Vector3_tDCF05E21F632FE2BA260C06E0D10CA81513E6720  L_65 = V_16;
		float L_66 = L_65.get_y_3();
		Vector3_tDCF05E21F632FE2BA260C06E0D10CA81513E6720  L_67 = V_14;
		float L_68 = L_67.get_y_3();
		V_23 = ((float)il2cpp_codegen_subtract((float)L_66, (float)L_68));
		Vector3_tDCF05E21F632FE2BA260C06E0D10CA81513E6720  L_69 = V_15;
		float L_70 = L_69.get_z_4();
		Vector3_tDCF05E21F632FE2BA260C06E0D10CA81513E6720  L_71 = V_14;
		float L_72 = L_71.get_z_4();
		V_24 = ((float)il2cpp_codegen_subtract((float)L_70, (float)L_72));
		Vector3_tDCF05E21F632FE2BA260C06E0D10CA81513E6720  L_73 = V_16;
		float L_74 = L_73.get_z_4();
		Vector3_tDCF05E21F632FE2BA260C06E0D10CA81513E6720  L_75 = V_14;
		float L_76 = L_75.get_z_4();
		V_25 = ((float)il2cpp_codegen_subtract((float)L_74, (float)L_76));
		Vector2_tA85D2DD88578276CA8A8796756458277E72D073D  L_77 = V_18;
		float L_78 = L_77.get_x_0();
		Vector2_tA85D2DD88578276CA8A8796756458277E72D073D  L_79 = V_17;
		float L_80 = L_79.get_x_0();
		V_26 = ((float)il2cpp_codegen_subtract((float)L_78, (float)L_80));
		Vector2_tA85D2DD88578276CA8A8796756458277E72D073D  L_81 = V_19;
		float L_82 = L_81.get_x_0();
		Vector2_tA85D2DD88578276CA8A8796756458277E72D073D  L_83 = V_17;
		float L_84 = L_83.get_x_0();
		V_27 = ((float)il2cpp_codegen_subtract((float)L_82, (float)L_84));
		Vector2_tA85D2DD88578276CA8A8796756458277E72D073D  L_85 = V_18;
		float L_86 = L_85.get_y_1();
		Vector2_tA85D2DD88578276CA8A8796756458277E72D073D  L_87 = V_17;
		float L_88 = L_87.get_y_1();
		V_28 = ((float)il2cpp_codegen_subtract((float)L_86, (float)L_88));
		Vector2_tA85D2DD88578276CA8A8796756458277E72D073D  L_89 = V_19;
		float L_90 = L_89.get_y_1();
		Vector2_tA85D2DD88578276CA8A8796756458277E72D073D  L_91 = V_17;
		float L_92 = L_91.get_y_1();
		V_29 = ((float)il2cpp_codegen_subtract((float)L_90, (float)L_92));
		float L_93 = V_26;
		float L_94 = V_29;
		float L_95 = V_27;
		float L_96 = V_28;
		V_30 = ((float)((float)(1.0f)/(float)((float)il2cpp_codegen_subtract((float)((float)il2cpp_codegen_multiply((float)L_93, (float)L_94)), (float)((float)il2cpp_codegen_multiply((float)L_95, (float)L_96))))));
		float L_97 = V_29;
		float L_98 = V_20;
		float L_99 = V_28;
		float L_100 = V_21;
		float L_101 = V_30;
		float L_102 = V_29;
		float L_103 = V_22;
		float L_104 = V_28;
		float L_105 = V_23;
		float L_106 = V_30;
		float L_107 = V_29;
		float L_108 = V_24;
		float L_109 = V_28;
		float L_110 = V_25;
		float L_111 = V_30;
		Vector3__ctor_m08F61F548AA5836D8789843ACB4A81E4963D2EE1((Vector3_tDCF05E21F632FE2BA260C06E0D10CA81513E6720 *)(&V_31), ((float)il2cpp_codegen_multiply((float)((float)il2cpp_codegen_subtract((float)((float)il2cpp_codegen_multiply((float)L_97, (float)L_98)), (float)((float)il2cpp_codegen_multiply((float)L_99, (float)L_100)))), (float)L_101)), ((float)il2cpp_codegen_multiply((float)((float)il2cpp_codegen_subtract((float)((float)il2cpp_codegen_multiply((float)L_102, (float)L_103)), (float)((float)il2cpp_codegen_multiply((float)L_104, (float)L_105)))), (float)L_106)), ((float)il2cpp_codegen_multiply((float)((float)il2cpp_codegen_subtract((float)((float)il2cpp_codegen_multiply((float)L_107, (float)L_108)), (float)((float)il2cpp_codegen_multiply((float)L_109, (float)L_110)))), (float)L_111)), /*hidden argument*/NULL);
		float L_112 = V_26;
		float L_113 = V_21;
		float L_114 = V_27;
		float L_115 = V_20;
		float L_116 = V_30;
		float L_117 = V_26;
		float L_118 = V_23;
		float L_119 = V_27;
		float L_120 = V_22;
		float L_121 = V_30;
		float L_122 = V_26;
		float L_123 = V_25;
		float L_124 = V_27;
		float L_125 = V_24;
		float L_126 = V_30;
		Vector3__ctor_m08F61F548AA5836D8789843ACB4A81E4963D2EE1((Vector3_tDCF05E21F632FE2BA260C06E0D10CA81513E6720 *)(&V_32), ((float)il2cpp_codegen_multiply((float)((float)il2cpp_codegen_subtract((float)((float)il2cpp_codegen_multiply((float)L_112, (float)L_113)), (float)((float)il2cpp_codegen_multiply((float)L_114, (float)L_115)))), (float)L_116)), ((float)il2cpp_codegen_multiply((float)((float)il2cpp_codegen_subtract((float)((float)il2cpp_codegen_multiply((float)L_117, (float)L_118)), (float)((float)il2cpp_codegen_multiply((float)L_119, (float)L_120)))), (float)L_121)), ((float)il2cpp_codegen_multiply((float)((float)il2cpp_codegen_subtract((float)((float)il2cpp_codegen_multiply((float)L_122, (float)L_123)), (float)((float)il2cpp_codegen_multiply((float)L_124, (float)L_125)))), (float)L_126)), /*hidden argument*/NULL);
		Vector3U5BU5D_tB9EC3346CC4A0EA5447D968E84A9AC1F6F372C28* L_127 = V_7;
		int32_t L_128 = V_11;
		NullCheck(L_127);
		Vector3_tDCF05E21F632FE2BA260C06E0D10CA81513E6720 * L_129 = ((L_127)->GetAddressAt(static_cast<il2cpp_array_size_t>(L_128)));
		Vector3_tDCF05E21F632FE2BA260C06E0D10CA81513E6720  L_130 = V_31;
		IL2CPP_RUNTIME_CLASS_INIT(Vector3_tDCF05E21F632FE2BA260C06E0D10CA81513E6720_il2cpp_TypeInfo_var);
		Vector3_tDCF05E21F632FE2BA260C06E0D10CA81513E6720  L_131 = Vector3_op_Addition_m929F9C17E5D11B94D50B4AFF1D730B70CB59B50E((*(Vector3_tDCF05E21F632FE2BA260C06E0D10CA81513E6720 *)L_129), L_130, /*hidden argument*/NULL);
		*(Vector3_tDCF05E21F632FE2BA260C06E0D10CA81513E6720 *)L_129 = L_131;
		Vector3U5BU5D_tB9EC3346CC4A0EA5447D968E84A9AC1F6F372C28* L_132 = V_7;
		int32_t L_133 = V_12;
		NullCheck(L_132);
		Vector3_tDCF05E21F632FE2BA260C06E0D10CA81513E6720 * L_134 = ((L_132)->GetAddressAt(static_cast<il2cpp_array_size_t>(L_133)));
		Vector3_tDCF05E21F632FE2BA260C06E0D10CA81513E6720  L_135 = V_31;
		Vector3_tDCF05E21F632FE2BA260C06E0D10CA81513E6720  L_136 = Vector3_op_Addition_m929F9C17E5D11B94D50B4AFF1D730B70CB59B50E((*(Vector3_tDCF05E21F632FE2BA260C06E0D10CA81513E6720 *)L_134), L_135, /*hidden argument*/NULL);
		*(Vector3_tDCF05E21F632FE2BA260C06E0D10CA81513E6720 *)L_134 = L_136;
		Vector3U5BU5D_tB9EC3346CC4A0EA5447D968E84A9AC1F6F372C28* L_137 = V_7;
		int32_t L_138 = V_13;
		NullCheck(L_137);
		Vector3_tDCF05E21F632FE2BA260C06E0D10CA81513E6720 * L_139 = ((L_137)->GetAddressAt(static_cast<il2cpp_array_size_t>(L_138)));
		Vector3_tDCF05E21F632FE2BA260C06E0D10CA81513E6720  L_140 = V_31;
		Vector3_tDCF05E21F632FE2BA260C06E0D10CA81513E6720  L_141 = Vector3_op_Addition_m929F9C17E5D11B94D50B4AFF1D730B70CB59B50E((*(Vector3_tDCF05E21F632FE2BA260C06E0D10CA81513E6720 *)L_139), L_140, /*hidden argument*/NULL);
		*(Vector3_tDCF05E21F632FE2BA260C06E0D10CA81513E6720 *)L_139 = L_141;
		Vector3U5BU5D_tB9EC3346CC4A0EA5447D968E84A9AC1F6F372C28* L_142 = V_8;
		int32_t L_143 = V_11;
		NullCheck(L_142);
		Vector3_tDCF05E21F632FE2BA260C06E0D10CA81513E6720 * L_144 = ((L_142)->GetAddressAt(static_cast<il2cpp_array_size_t>(L_143)));
		Vector3_tDCF05E21F632FE2BA260C06E0D10CA81513E6720  L_145 = V_32;
		Vector3_tDCF05E21F632FE2BA260C06E0D10CA81513E6720  L_146 = Vector3_op_Addition_m929F9C17E5D11B94D50B4AFF1D730B70CB59B50E((*(Vector3_tDCF05E21F632FE2BA260C06E0D10CA81513E6720 *)L_144), L_145, /*hidden argument*/NULL);
		*(Vector3_tDCF05E21F632FE2BA260C06E0D10CA81513E6720 *)L_144 = L_146;
		Vector3U5BU5D_tB9EC3346CC4A0EA5447D968E84A9AC1F6F372C28* L_147 = V_8;
		int32_t L_148 = V_12;
		NullCheck(L_147);
		Vector3_tDCF05E21F632FE2BA260C06E0D10CA81513E6720 * L_149 = ((L_147)->GetAddressAt(static_cast<il2cpp_array_size_t>(L_148)));
		Vector3_tDCF05E21F632FE2BA260C06E0D10CA81513E6720  L_150 = V_32;
		Vector3_tDCF05E21F632FE2BA260C06E0D10CA81513E6720  L_151 = Vector3_op_Addition_m929F9C17E5D11B94D50B4AFF1D730B70CB59B50E((*(Vector3_tDCF05E21F632FE2BA260C06E0D10CA81513E6720 *)L_149), L_150, /*hidden argument*/NULL);
		*(Vector3_tDCF05E21F632FE2BA260C06E0D10CA81513E6720 *)L_149 = L_151;
		Vector3U5BU5D_tB9EC3346CC4A0EA5447D968E84A9AC1F6F372C28* L_152 = V_8;
		int32_t L_153 = V_13;
		NullCheck(L_152);
		Vector3_tDCF05E21F632FE2BA260C06E0D10CA81513E6720 * L_154 = ((L_152)->GetAddressAt(static_cast<il2cpp_array_size_t>(L_153)));
		Vector3_tDCF05E21F632FE2BA260C06E0D10CA81513E6720  L_155 = V_32;
		Vector3_tDCF05E21F632FE2BA260C06E0D10CA81513E6720  L_156 = Vector3_op_Addition_m929F9C17E5D11B94D50B4AFF1D730B70CB59B50E((*(Vector3_tDCF05E21F632FE2BA260C06E0D10CA81513E6720 *)L_154), L_155, /*hidden argument*/NULL);
		*(Vector3_tDCF05E21F632FE2BA260C06E0D10CA81513E6720 *)L_154 = L_156;
		int32_t L_157 = V_9;
		V_9 = ((int32_t)il2cpp_codegen_add((int32_t)L_157, (int32_t)3));
		int32_t L_158 = V_10;
		V_10 = ((int32_t)il2cpp_codegen_add((int32_t)L_158, (int32_t)1));
	}

IL_0271:
	{
		int32_t L_159 = V_10;
		int32_t L_160 = V_5;
		if ((((int32_t)L_159) < ((int32_t)L_160)))
		{
			goto IL_004f;
		}
	}
	{
		V_33 = 0;
		goto IL_0330;
	}

IL_0282:
	{
		Vector3U5BU5D_tB9EC3346CC4A0EA5447D968E84A9AC1F6F372C28* L_161 = V_2;
		int32_t L_162 = V_33;
		NullCheck(L_161);
		int32_t L_163 = L_162;
		Vector3_tDCF05E21F632FE2BA260C06E0D10CA81513E6720  L_164 = (L_161)->GetAt(static_cast<il2cpp_array_size_t>(L_163));
		V_34 = L_164;
		Vector3U5BU5D_tB9EC3346CC4A0EA5447D968E84A9AC1F6F372C28* L_165 = V_7;
		int32_t L_166 = V_33;
		NullCheck(L_165);
		int32_t L_167 = L_166;
		Vector3_tDCF05E21F632FE2BA260C06E0D10CA81513E6720  L_168 = (L_165)->GetAt(static_cast<il2cpp_array_size_t>(L_167));
		V_35 = L_168;
		IL2CPP_RUNTIME_CLASS_INIT(Vector3_tDCF05E21F632FE2BA260C06E0D10CA81513E6720_il2cpp_TypeInfo_var);
		Vector3_OrthoNormalize_mDC6E386DEE6B035A0D0CC5A76E427F1ED3899A3E((Vector3_tDCF05E21F632FE2BA260C06E0D10CA81513E6720 *)(&V_34), (Vector3_tDCF05E21F632FE2BA260C06E0D10CA81513E6720 *)(&V_35), /*hidden argument*/NULL);
		Vector4U5BU5D_t51402C154FFFCF7217A9BEC4B834F0B726C10F66* L_169 = V_6;
		int32_t L_170 = V_33;
		NullCheck(L_169);
		Vector3_tDCF05E21F632FE2BA260C06E0D10CA81513E6720  L_171 = V_35;
		float L_172 = L_171.get_x_2();
		((L_169)->GetAddressAt(static_cast<il2cpp_array_size_t>(L_170)))->set_x_0(L_172);
		Vector4U5BU5D_t51402C154FFFCF7217A9BEC4B834F0B726C10F66* L_173 = V_6;
		int32_t L_174 = V_33;
		NullCheck(L_173);
		Vector3_tDCF05E21F632FE2BA260C06E0D10CA81513E6720  L_175 = V_35;
		float L_176 = L_175.get_y_3();
		((L_173)->GetAddressAt(static_cast<il2cpp_array_size_t>(L_174)))->set_y_1(L_176);
		Vector4U5BU5D_t51402C154FFFCF7217A9BEC4B834F0B726C10F66* L_177 = V_6;
		int32_t L_178 = V_33;
		NullCheck(L_177);
		Vector3_tDCF05E21F632FE2BA260C06E0D10CA81513E6720  L_179 = V_35;
		float L_180 = L_179.get_z_4();
		((L_177)->GetAddressAt(static_cast<il2cpp_array_size_t>(L_178)))->set_z_2(L_180);
		Vector4U5BU5D_t51402C154FFFCF7217A9BEC4B834F0B726C10F66* L_181 = V_6;
		int32_t L_182 = V_33;
		NullCheck(L_181);
		Vector3_tDCF05E21F632FE2BA260C06E0D10CA81513E6720  L_183 = V_34;
		Vector3_tDCF05E21F632FE2BA260C06E0D10CA81513E6720  L_184 = V_35;
		Vector3_tDCF05E21F632FE2BA260C06E0D10CA81513E6720  L_185 = Vector3_Cross_m3E9DBC445228FDB850BDBB4B01D6F61AC0111887(L_183, L_184, /*hidden argument*/NULL);
		Vector3U5BU5D_tB9EC3346CC4A0EA5447D968E84A9AC1F6F372C28* L_186 = V_8;
		int32_t L_187 = V_33;
		NullCheck(L_186);
		int32_t L_188 = L_187;
		Vector3_tDCF05E21F632FE2BA260C06E0D10CA81513E6720  L_189 = (L_186)->GetAt(static_cast<il2cpp_array_size_t>(L_188));
		float L_190 = Vector3_Dot_m0C530E1C51278DE28B77906D56356506232272C1(L_185, L_189, /*hidden argument*/NULL);
		G_B5_0 = ((L_181)->GetAddressAt(static_cast<il2cpp_array_size_t>(L_182)));
		if ((((float)L_190) < ((float)(0.0f))))
		{
			G_B6_0 = ((L_181)->GetAddressAt(static_cast<il2cpp_array_size_t>(L_182)));
			goto IL_030d;
		}
	}
	{
		G_B7_0 = (1.0f);
		G_B7_1 = G_B5_0;
		goto IL_0312;
	}

IL_030d:
	{
		G_B7_0 = (-1.0f);
		G_B7_1 = G_B6_0;
	}

IL_0312:
	{
		G_B7_1->set_w_3(G_B7_0);
		Vector4U5BU5D_t51402C154FFFCF7217A9BEC4B834F0B726C10F66* L_191 = V_6;
		int32_t L_192 = V_33;
		NullCheck(L_191);
		int32_t L_193 = L_192;
		Vector4_tD148D6428C3F8FF6CD998F82090113C2B490B76E  L_194 = (L_191)->GetAt(static_cast<il2cpp_array_size_t>(L_193));
		Vector4_tD148D6428C3F8FF6CD998F82090113C2B490B76E  L_195 = L_194;
		RuntimeObject * L_196 = Box(Vector4_tD148D6428C3F8FF6CD998F82090113C2B490B76E_il2cpp_TypeInfo_var, &L_195);
		IL2CPP_RUNTIME_CLASS_INIT(Debug_t7B5FCB117E2FD63B6838BC52821B252E2BFB61C4_il2cpp_TypeInfo_var);
		Debug_Log_m4B7C70BAFD477C6BDB59C88A0934F0B018D03708(L_196, /*hidden argument*/NULL);
		int32_t L_197 = V_33;
		V_33 = ((int32_t)il2cpp_codegen_add((int32_t)L_197, (int32_t)1));
	}

IL_0330:
	{
		int32_t L_198 = V_33;
		int32_t L_199 = V_0;
		if ((((int32_t)L_198) < ((int32_t)L_199)))
		{
			goto IL_0282;
		}
	}
	{
		Vector4U5BU5D_t51402C154FFFCF7217A9BEC4B834F0B726C10F66* L_200 = V_6;
		return L_200;
	}
}
// System.Void unitycoder_MobilePaint_samples.TangentSolver::.ctor()
extern "C" IL2CPP_METHOD_ATTR void TangentSolver__ctor_m29AAB8829E8FDCB2182C8355BFB55603E5A21DDD (TangentSolver_t655698722F48FC1DDDB372D35BC32042835C9FE8 * __this, const RuntimeMethod* method)
{
	{
		MonoBehaviour__ctor_mEAEC84B222C60319D593E456D769B3311DFCEF97(__this, /*hidden argument*/NULL);
		return;
	}
}
#ifdef __clang__
#pragma clang diagnostic pop
#endif
