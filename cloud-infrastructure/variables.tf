variable "prefix" {
  type    = "string"
  default = "communications-app"
}

variable "location" {
  type    = "string"
  default = "centralus"
}

variable "agent_count" {
  default     = 1
  description = "The number of agents in the cluster"
}

variable "dns_prefix" {
  description = "DNS prefix for the AKS cluster"
}

variable "client_id" {
  description = "client id for cluster"
}

variable "client_secret" {
  description = "client secret for cluster"
}

variable "failover_location" {
  type        = "string"
  default     = "eastus"
  description = "The fail over location for cosmos db"
}

variable "sql_password" {
    type = "string"
    description = "Azure SQL Server Password"
}
variable "service_principal_pw" {}
variable "tenant_id" {}

variable "sql_allowed_ips" {
  type = "list"
}
