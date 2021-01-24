resource "azurerm_app_service_plan" "app_service_plan" {
  location            = var.location
  name                = var.service_plan_name
  resource_group_name = azurerm_resource_group.resource_group.name
  kind                = "Linux"
  reserved            = true
  sku {
    size = "B1"
    tier = "Basic"
  }
}

resource "azurerm_app_service" "app_service" {
  app_service_plan_id = azurerm_app_service_plan.app_service_plan.id
  location            = var.location
  name                = var.web_app_name
  resource_group_name = azurerm_resource_group.resource_group.name
  
  site_config {
    dotnet_framework_version  = "v5.0"
  }
}