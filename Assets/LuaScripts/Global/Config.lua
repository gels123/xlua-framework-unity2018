--[[
-- added by wsh @ 2017-11-30
-- Lua全局配置
--]]

local Config = {}

-- 是否调试模式(真机出包时关闭)
Config.Debug = CS.AppConfig:IsDebug()
-- 是否调试模式(真机出包时关闭)
Config.Editor = CS.AppConfig:IsEditor()
-- AssetBundle
Config.UseAssetBundle = false

return Config