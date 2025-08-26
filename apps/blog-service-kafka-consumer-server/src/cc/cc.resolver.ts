import * as graphql from "@nestjs/graphql";
import { CcService } from "./cc.service";

export class CcResolver {
  constructor(protected readonly service: CcService) {}
}
