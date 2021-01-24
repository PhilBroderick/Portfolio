variable "subscription_id" {
  description = "The Id for the Azure subscription"
  type        = string
}

variable "tenant_id" {
  description = "The Id for the Azure tenant"
  type        = string
}

variable "client_id" {
  description = "The id of the service principal to allow Terraform to apply resources"
  type        = string
}

variable "client_secret" {
  description = "The secret value associated with the service principal"
  type        = string
}
variable "location" {
  description = "location to deploy resources into"
  type        = string
}

variable "rg_name" {
  description = "resource group name to deploy resources into"
  type        = string
}

variable "service_plan_name" {
  description = "name of the app service plan"
  type        = string
}

variable "web_app_name" {
  description = "name of the app service"
  type        = string 
}